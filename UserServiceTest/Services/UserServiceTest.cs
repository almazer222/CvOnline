using CvOnline.Domain.Models;
using CvOnline.Domain.Repositories;
using CvOnline.Service.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace UserServiceTest.Services
{
    [TestClass]
    public class UserServiceTest
    {
        /// <summary>
        /// Test de suppresion d'un utilisateur.
        /// </summary>
        [TestMethod]
        public void GetUserById()
        {
            var userRepository = new Mock<IUserRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();

            //SetUp
            unitOfWork.Setup(x => x.UserRepository).Returns(() => userRepository.Object);

            var userService = new UserService(unitOfWork.Object);

            var userId = 1002;

            var userReturned = userService.GetUserByIdAsync(userId);

            //Assert

            //On vérifie au moins que la methode Add a été appelé une fois.
            userRepository.Verify(u => u.GetUserByIdAsync(It.IsAny<int>()), Times.AtLeastOnce);
        }


        /// <summary>
        /// Test d'authentification d'un utilisateur.
        /// </summary>
        [TestMethod]
        public void AuthentificateOfUser()
        {
            var userRepository = new Mock<IUserRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();

            //SetUp
            unitOfWork.Setup(x => x.UserRepository).Returns(() => userRepository.Object);

            var userService = new UserService(unitOfWork.Object);

            //Créer les différents objets 
            var email = "TestEmail@gmail.com";
            var password = "Azerty1234";

            var userReturned = userService.AuthentificateAsync(email, password);

            //Assert

            //On vérifie au moins que la methode Add a été appelé une fois.
            userRepository.Verify(u => u.AuthentificateAsync(It.IsAny<string>(), It.IsAny<string>()), Times.AtLeastOnce);
        }

        /// <summary>
        /// Test de suppresion d'un utilisateur.
        /// </summary>
        [TestMethod]
        public async Task RemoveUserById()
        {
            var userRepository = new Mock<IUserRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();

            //SetUp
            unitOfWork.Setup(x => x.UserRepository).Returns(() => userRepository.Object);

            var userService = new UserService(unitOfWork.Object);

            //Créer les différents objets 
            var user = new User
            {
                LastName = "TestName",
                FirstName = "TestPrenom",
                Email = "TestEmail@gmail.com",
                PhoneNumber = "099782662"
            };

            await userService.RemoveUserAsync(user);

            //Assert

            //On vérifie au moins que la methode Add a été appelé une fois.
            userRepository.Verify(u => u.Remove(It.IsAny<User>()), Times.AtLeastOnce);
        }


        /// <summary>
        /// Test de création d'un utilisateur.
        /// </summary>
        [TestMethod]
        public void CreateUserWithEntrepriseAndAddress_ReturnCreateNewUser()
        {
            //Arange
            var userRepository = new Mock<IUserRepository>();
            var entrepriseRepository = new Mock<IRepository<Entreprise>>();
            var addressRepository = new Mock<IRepository<Address>>();

            var unitOfWork = new Mock<IUnitOfWork>();

            //SetUp
            unitOfWork.Setup(x => x.UserRepository).Returns(() => userRepository.Object);
            unitOfWork.Setup(x => x.EntrepriseRepository).Returns(() => entrepriseRepository.Object);
            unitOfWork.Setup(x => x.AddressRepository).Returns(() => addressRepository.Object);

            var userService = new UserService(unitOfWork.Object);

            //Créer les différents objets 
            var user = new User
            {
                LastName = "TestName",
                FirstName = "TestPrenom",
                Email = "TestEmail@gmail.com",
                PhoneNumber = "099782662"
            };

            string password = "MotDePassePourTestUnitaire1234";

            var entreprise = new Entreprise
            {
                Name = "testEntreprise"
            };

            var address = new Address
            {
                Street = "Rue du test",
                Number = 11,
                Box = "1A",
                PostalCode = 7729,
                Town = "Tournai",
                Contry = "Belgique"
            };

            var userReturned = userService.CreateUserWithEntrepriseAndAddressAsync(user, password, entreprise, address);

            //Assert

            //On vérifie au moins que la methode Add a été appelé une fois.
            userRepository.Verify(u => u.CreateAsync(It.IsAny<User>(), It.IsAny<string>()), Times.AtLeastOnce);
            entrepriseRepository.Verify(c => c.AddAsync(It.IsAny<Entreprise>()), Times.AtLeastOnce);
            addressRepository.Verify(c => c.AddAsync(It.IsAny<Address>()), Times.AtLeastOnce);
        }
    }
}
