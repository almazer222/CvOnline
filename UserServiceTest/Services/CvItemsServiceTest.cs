using CvOnline.API.Dtos;
using CvOnline.API.Dtos.CvItmDto;
using CvOnline.Domain.Models;
using CvOnline.Domain.Models.CV_Items;
using CvOnline.Domain.Repositories;
using CvOnline.Infrastructure.Migrations;
using CvOnline.Service.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserServiceTest.Services
{
    [TestClass]
    public class CvItemsServiceTest
    {
        /// <summary>
        /// Test to get CvItems
        /// </summary>
        [TestMethod]
        public void GetCvItemsById()
        {
            var cvItemsRepository = new Mock<ICvItemsRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();

            //SetUp
            unitOfWork.Setup(x => x.CvItemRepository).Returns(() => cvItemsRepository.Object);

            var cvItemsService = new CvItemService(unitOfWork.Object);

            var id = 4;

            var cvItemsReturned = cvItemsService.GetCvItemByIdAsync(id);

            //On vérifie au moins que la methode GetCvItemsByIdAsync a été appelé une fois.
            cvItemsRepository.Verify(c => c.GetCvItemsByIdAsync(It.IsAny<int>()), Times.AtLeastOnce);
        }

        /// <summary>
        /// Test to add cv items
        /// </summary>
        [TestMethod]
        public void CreateCvItems()
        {
            var cvItemsRepository = new Mock<ICvItemsRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();

            //SetUp
            unitOfWork.Setup(x => x.CvItemRepository).Returns(() => cvItemsRepository.Object);

            var cvItemsService = new CvItemService(unitOfWork.Object);

            CV cvItems = new CV();

            Identity identity = new Identity
            {
                FirstName = "Test",
                LastName = "toto",
                KindOfWork = "Test etude",
                Address = new Address
                {
                    Street = "euezhu",
                    Number = 444,
                    Box = "aaaaa",
                    PostalCode = 7700,
                    Town = "kkkk",
                    Contry = "aaaaa"
                }
            };

            List<Skill> skills = new List<Skill>
            { new Skill
            {
                Name = "Langue",
                SkillItems = new List<SkillItem>
                   {
                        new SkillItem
                        {
                             Name = "tot",
                        }
                   }
            }
            };

            List<Social> socials = new List<Social> { new Social {  Name = "test" , Url="url"} };
            List<Education> educations = new List<Education> { new Education { Degres = "aa", EndDate = new DateTime(), KindOfStudy = "aaa", School = "School", StartDate = new DateTime() } };
            List<Interest> interests = new List<Interest> { new Interest {  Name = "aaa", Description= "aaaa"} };
            List<Certification> certifications = new List<Certification> { new Certification { Name = "aaa" } };
            List<Experiance> experiances = new List<Experiance> { new Experiance { Id = 1, Description = "fff", EndDate = DateTime.Now, StartDate = DateTime.Now, Poste = "Here", Title = "Title" } };
          
            cvItems.Experiances = experiances;
            cvItems.Skills = skills;
            cvItems.Socials = socials;
            cvItems.Identities = identity;
            cvItems.Interests = interests;
            cvItems.Educations = educations;
            cvItems.Certifications = certifications;


            var cvItemsReturned = cvItemsService.CreateCvItemAsync(cvItems);

            //On vérifie au moins que la methode Add a été appelé une fois.
            cvItemsRepository.Verify(c => c.AddAsync(It.IsAny<CV>()), Times.AtLeastOnce);
        }
    }
}