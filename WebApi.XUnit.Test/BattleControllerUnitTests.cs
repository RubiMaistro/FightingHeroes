using AutoMapper;
using FakeItEasy;
using WebApi.Controllers;
using WebApi.Interfaces.Repositories;
using WebApi.Interfaces.Services;
using WebApi.Models;

namespace WebApi.XUnit.Test
{
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
        [Fact]
        public void Post_WithValidArgument_CreateBattle()
        {
            // Arrange
            var battles = A.Fake<ICollection<Battle>>();
            var battleList = A.Fake<List<Battle>>();
            A.CallTo(() => _mapper.Map<List<Battle>>(battles)).Returns(battleList);
            var battle = new BattleController(_repository, _battleHandling);

            //Act
            var result = battle.Get(2);

            ////Assert
            //result.Should().NotBeNull();
            //result.Should().BeOfType(typeof(OkObjectResult));
        }
    }
}