using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Moq;
using tp2JordanCoutureLafranchise.Controllers;
using tp2JordanCoutureLafranchise.Models;
using tp3JordanCoutureLafranchise.Services;
using Xunit;

namespace DirecteurGeneralController_Test
{
    public class HomeController_Test
    {

        private Mock<IParentService> _ParentServiceMock;
        private Mock<ParentService> _ParentService;
        private Mock<IStringLocalizer<HomeController>> _localizer;
        private HomeController _Controller;

        public HomeController_Test() 
        {
            _ParentServiceMock = new Mock<IParentService>();
            _localizer=new Mock<IStringLocalizer<HomeController>>();
            _Controller = new HomeController(_ParentServiceMock.Object, _localizer.Object);

        }



        [Fact]
        public void Index_VerifierGetAllAppelé()
        {
            //arrange
            _Controller.Index();

            //assert
            _ParentServiceMock.Verify(x => x.GetAllAsync(), Times.Once);

        }

        [Fact]
        public async Task CreateCheck_ModelStateValid_ReturnView()
        {


            //act
            var parent = new Parent { ParentId = 1 };
            var result = await _Controller.Create(parent);

            //assert
            // Vérifier que CreateAsync n'est appelé qu'une seule fois
            _ParentServiceMock.Verify(x => x.CreateAsync(It.IsAny<Parent>()), Times.Once());

            // Vérifiez que c'est bien une redirection
            Assert.IsType<RedirectToActionResult>(result);

            // Vérifier que le nom de la vue est correspondant
            // Vérifier que le nom du contrôleur est correspondant
            var viewResult = result as RedirectToActionResult;
            Assert.Equal("index", viewResult.ActionName);
        }


        [Fact]
        public async Task CreateCheck_ModelStateInvalid_ReturnView()
        {
            //arrange
            _Controller.ModelState.AddModelError("test", "test");

            //act
            var parent = new Parent { ParentId = 1 };
            var result = await _Controller.Create(parent) as ViewResult;

            var viewresult= result as ViewResult;
           
            //assert
            // Vérifier que CreateAsync n'est appelé qu'une seule fois
            _ParentServiceMock.Verify(x => x.CreateAsync(It.IsAny<Parent>()), Times.Never());

            // Vérifiez que c'est bien une redirection
            Assert.IsType<ViewResult>(viewresult);

            // Vérifier que le nom de la vue est correspondant
            Assert.Equal(null, viewresult.ViewName);
            //Assert.Equal("Create", viewresult.ViewName);
        }

    }
}