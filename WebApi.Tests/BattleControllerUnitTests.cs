using AutoMapper;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;
using WebApi.Interfaces.Repositories;
using WebApi.Interfaces.Services;

namespace WebApi.Tests
{
    [TestClass]
    public class BattleControllerUnitTests
    {
        private readonly IBattleHandlingService _battleHandling;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public BattleControllerUnitTests()
        {
            _battleHandling = A.Fake<IBattleHandlingService>();
            _repository = A.Fake<IRepositoryWrapper>();
            _mapper = A.Fake<IMapper>();
        }
        
        [DataRow(1)]
        [TestMethod]
        public void Post_WithInvalidArgument_BadRequest (int numberOfHeroes)
        {
            // Arrange
            var battle = new BattleController(_repository, _battleHandling);

            // Act
            var result = battle.Post(numberOfHeroes);
            BadRequestObjectResult actual = result as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(actual);
        }

        
    }
}