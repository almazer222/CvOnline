using AutoMapper;
using CvOnline.API.Helper;
using CvOnline.API.Dtos;
using CvOnline.API.Validation;
using CvOnline.Domain.Models;
using CvOnline.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace CvOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IAddressService _addressService;
        private readonly IEntrepriseService _entrepriseService;


        private readonly SystemSettings _systemSettings;
        private readonly IMapper _mappingService;

        public UserController(IUserService userService,
                              IAddressService addressService,
                              IEntrepriseService entrepriseService,
                              IMapper mappingService, 
                              IOptions<SystemSettings> options)
        {
            _systemSettings = options.Value;
            _userService = userService;
            _addressService = addressService;
            _entrepriseService = entrepriseService;
            _mappingService = mappingService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            try
            {
                if (id == 0) return BadRequest("Idification invalid");

                var user = await _userService.GetUserByIdAsync(id);

                if (user == null) return NotFound("User not found");

                var entreprise = await _entrepriseService.GetEntrepriseByIdAsync(user.EntrepriseId);
                if(entreprise != null)
                {
                    var address = await _addressService.GetAddressByIdAsync(entreprise.AddressId);

                    user.Entreprise = entreprise;
                    user.Entreprise.Address = address;
                }

                var userRessource = _mappingService.Map<User, UserDto>(user);

                return Ok(new { userRessource });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost("Authenticate")]
        public async Task<IActionResult> AuthentificateAsync(AuthenticateDto authenticateRessource)
        {
            try
            {
                var validation = await new SaveAuthenticateRessourceValidator().ValidateAsync(authenticateRessource);

                if (!validation.IsValid) return BadRequest(validation.Errors);

                var user = await _userService.AuthentificateAsync(authenticateRessource.Email, authenticateRessource.Password);

                if (user == null) return BadRequest(new { message = "Email or password is incorrect" });

                var newUserRessource = _mappingService.Map<User, UserDto>(user);

                newUserRessource.Token = TokenHelper.CreateToken(_systemSettings.Secret, user.Id);

                return Ok(new
                {
                    newUserRessource
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(UserDto userRessource)
        {
            try
            {
                var validation = await new SaveUserRessourceValidator().ValidateAsync(userRessource);
                if (!validation.IsValid) return BadRequest(validation.Errors);

                validation = await new SaveEntrepriseRessourceValidator().ValidateAsync(userRessource.Entreprise);
                if (!validation.IsValid) return BadRequest(validation.Errors);

                validation = await new SaveAddressRessourceValidator().ValidateAsync(userRessource.Entreprise.Address);
                if (!validation.IsValid) return BadRequest(validation.Errors);


                var user = _mappingService.Map<UserDto, User>(userRessource);
                var entreprise = _mappingService.Map<EntrepriseDto, Entreprise>(userRessource.Entreprise);
                var address = _mappingService.Map<AddressDto, Address>(userRessource.Entreprise.Address);

                var newUser = await _userService.CreateUserWithEntrepriseAndAddressAsync(user, userRessource.Password, entreprise, address);

                var newUserRessource = _mappingService.Map<User, UserDto>(user);
                var newEntrepriseRessource = _mappingService.Map<Entreprise, EntrepriseDto>(user.Entreprise);
                var newAddressRessource = _mappingService.Map<Address, AddressDto>(user.Entreprise.Address);

                newUserRessource.Token = TokenHelper.CreateToken(_systemSettings.Secret, user.Id);
                newUserRessource.Entreprise = newEntrepriseRessource;
                newUserRessource.Entreprise.Address = newAddressRessource;

                return Ok(new
                {
                    newUserRessource
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveUserAsync(int id)
        {
            try
            {
                if (id == 0) return BadRequest("Idification invalid.");

                var user = await _userService.GetUserByIdAsync(id);

                if (user == null) return NotFound("User not found.");

                await _userService.RemoveUserAsync(user);

                return Ok("User was deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
