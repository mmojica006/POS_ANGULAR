using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using POS.Application.Dtos.Request;
using POS.Application.Interfaces;
using POS.Utilities.Static;

namespace POS.Test.Category
{
    [TestClass]
    public class CategoryApplicationTest
    {
        private static WebApplicationFactory<Program> _factory = null;
        private static IServiceScopeFactory? _scopefactory = null; 

        [ClassInitialize]
        public static void Initialize(TestContext _testContext)
        {
            _factory = new CustomWebapplicationFactory();
            _scopefactory = _factory.Services.GetService<IServiceScopeFactory>();

        }

        [TestMethod]
        public async Task RegisterCategory_WhenSendingNullValuesOrEmpty_ValidationErrors()
        {
            using var scope = _scopefactory?.CreateScope();
            var context = scope?.ServiceProvider.GetService<ICategoryApplication>();
            //Arrange Preparar una solicitud
            var name = "";
            var descripcion = "";
            var state = 1;
            var expected = ReplyMessage.MESSAGE_VALIDATE;

            //Actuar 
            var result = await context!.RegisterCategory(new CategoryRequestDto()
            {
                Name = name,
                Description = descripcion,
                State = state
            });
            var current = result.Message;

            //Assert aprobado o no aprobado
            Assert.AreEqual(expected, current);
        }

        [TestMethod]
        public async Task RegisterCategory_WhenSendingCorrectValues_RegisteredSuccessfully()
        {
            using var scope = _scopefactory?.CreateScope();
            var context = scope?.ServiceProvider.GetService<ICategoryApplication>();
            //Arrange
            var name = "Nuevo Registro";
            var descripcion = "Nueva Descripción";
            var state = 1;
            var expected = ReplyMessage.MESSAGE_SAVE;

            //Actuar
            var result = await context!.RegisterCategory(new CategoryRequestDto()
            {
                Name = name,
                Description = descripcion,
                State = state
            });
            var current = result.Message;

            //Assert aprobado o no aprobado
            Assert.AreEqual(expected, current);

        }
    }
}
