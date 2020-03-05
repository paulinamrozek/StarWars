using AutoMapper;
using Characters;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace StarWars.Test.Controllers
{
    public class CharacterControllerTests
    {
        private Mock<IRepositoryManager> _repositoryManagerMock;
        private Mock<ILoggerManager> _loggerManagerMock;
        private Mock<IMapper> _mapperMock;
        private Mock<ICharacterService> _characterServiceMock;
        private CharacterController _characterController;

        public CharacterControllerTests()
        {
            _repositoryManagerMock = new Mock<IRepositoryManager>();
            _mapperMock = new Mock<IMapper>();
            _characterServiceMock = new Mock<ICharacterService>();
            _loggerManagerMock = new Mock<ILoggerManager>();
            _characterController = new CharacterController(_repositoryManagerMock.Object, _loggerManagerMock.Object, _mapperMock.Object, _characterServiceMock.Object);
        }
        #region GetCharacters
        [Fact]
        public void Task_GetCharacters_Return_OkResult()
        {
            //Arange
            var characterParameters = new CharacterParameters()
            {
                PageNumber = 1,
                PageSize = 1
            };
            _repositoryManagerMock.Setup(m => m.Character.GetAllCharacters(characterParameters));       
            
            //Act
            var result = _characterController.GetCharacters(characterParameters);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        #endregion
        #region GetCharacter
        [Fact]
        public void Task_GetCharacter_Return_OkResult()
        {
            var character = new Character();
            _repositoryManagerMock.Setup(m => m.Character.GetCharacter(1)).Returns(character);
            _characterServiceMock.Setup(m => m.CharacterExists(character)).Returns(true);
            var characterById = _characterController.GetCharacter(1);

            Assert.IsType<OkObjectResult>(characterById);
        }
        [Fact]
        public void Task_GetCharacter_Return_NotFound()
        {
            int id = 1;
            Character character = new Character();
            _characterServiceMock.Setup(m => m.CharacterExists(character)).Returns(false);
            _repositoryManagerMock.Setup(m => m.Character.GetCharacter(id));

            var result = _characterController.GetCharacter(id);

            Assert.IsType<NotFoundResult>(result);
        }
        #endregion
    }
}
