using AutoMapper;
using CvOnline.API.Dtos;
using CvOnline.API.Dtos.CvItmDto;
using CvOnline.API.Helper;
using CvOnline.API.Validation;
using CvOnline.Domain.Models;
using CvOnline.Domain.Models.CV_Items;
using CvOnline.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CvOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CvItemController : ControllerBase
    {
        private readonly ICvItemService _cvItemService;


        private readonly SystemSettings _systemSettings;
        private readonly IMapper _mappingService;

        public CvItemController(ICvItemService cvItemService,
                              IMapper mappingService,
                              IOptions<SystemSettings> options)
        {
            _systemSettings = options.Value;
            _cvItemService = cvItemService;
            _mappingService = mappingService;
        }

        [HttpGet("GetCvItem")]
        public async Task<IActionResult> GetCvItemsByIdAsync(int id)
        {
            if (id == 0)
                return BadRequest("The id mustn't be null or empty");
            try
            {
                var cvItem = await _cvItemService.GetCvItemByIdAsync(id);
                if (cvItem == null)
                    return BadRequest("Any Cv identification's associated with a Cv.");

                var cvItemResult = _mappingService.Map<CV, CvItemsDto>(cvItem);

                return Ok(cvItemResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateCvItemsAsync(CvItemsDto cvItemsDto)
        {
            ValidationHelper.ValidationInputDataNotNull(cvItemsDto);

            cvItemsDto.Experiances.Where(e => e.EndDate == null).Select(e => e.EndDate = DateHelper.GetEmptyDateWhenNullDate(e.EndDate)).ToList();
            cvItemsDto.Experiances.Where(e => e.StartDate == null).Select(e => e.StartDate = DateHelper.GetEmptyDateWhenNullDate(e.StartDate)).ToList();

            cvItemsDto.Educations.Where(e => e.EndDate == null).Select(e => e.EndDate = DateHelper.GetEmptyDateWhenNullDate(e.EndDate)).ToList();
            cvItemsDto.Educations.Where(e => e.StartDate == null).Select(e => e.StartDate = DateHelper.GetEmptyDateWhenNullDate(e.StartDate)).ToList();

            try
            {
                var errors = await ValidationHelper.ValidationInputData(cvItemsDto);
                if (errors.Any()) return BadRequest(errors);

                var cvItems = _mappingService.Map<CvItemsDto, CV>(cvItemsDto);

                await _cvItemService.CreateCvItemAsync(cvItems);

                return Ok(cvItems);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
