using APIAssessment.Controllers;
using APIAssessment.DTOs;
using APIAssessment.Model;
using APIAssessment.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace APIAssessmentTests
{
    public class FruitTestController
    {
        private readonly Mock<IFruitService> fruitService;
        public FruitTestController()
        {
            fruitService = new Mock<IFruitService>();
        }

        [Fact]
        public void GetAllFruitsTest()
        {
            //arrange
            var fruitsList = GetFruitsData();
            fruitService.Setup(x => x.GetFruitsList())
                .Returns(fruitsList);
            var fruitsController = new FruitController(fruitService.Object);

            //act
            var fruitsResult = fruitsController.GetAllFruits();
            var controllerResult = fruitsResult as OkObjectResult;
            
            //assert
            Assert.NotNull(fruitsResult);            
            Assert.True(fruitsList.Equals(controllerResult.Value));
        }

        [Fact]
        public void SaveFruitTest()
        {
            //arrange
            var FruitList = GetFruitsDataDto();
            fruitService.Setup(x => x.SaveFruits(FruitList[0]))
                .Returns(GetResonse());
            var fruitController = new FruitController(fruitService.Object);

            //act
            var fruitsResult = fruitController.SaveFruit(FruitList[0]);
            var controllerResult = fruitsResult as OkObjectResult;

            //assert
            Assert.NotNull(controllerResult);            
            Assert.True(((Response)controllerResult.Value).IsSuccess);
        }

        private List<Fruits> GetFruitsData()
        {
            List<Fruits> fruitsData = new List<Fruits>(){
            new Fruits
                { 
                    Genus="Musa",
                    Name="Banana",
                    Id=1,
                    Family="Musaceae",
                    Order="Zingiberales",
                    Nutritions = new List<Nutritions>(){
                       new Nutritions{
                            Carbohydrates=22,
                            Protein=0,
                            Fat=0.2f,
                            Calories=96,
                            Sugar=17.2f
                       }
                    }                   
                },
                new Fruits
                {
                    Genus="Fragaria",
                    Name="Strawberry",
                    Id=2,
                    Family="Rosaceae",
                    Order="Rosales",
                    Nutritions = new List<Nutritions>(){
                       new Nutritions{
                            Carbohydrates=5.5f,
                            Protein=0,
                            Fat=0.4f,
                            Calories=29,
                            Sugar=5.4f
                       }
                    }
                }
            };           

            return fruitsData;
        }

        private List<FruitsDto> GetFruitsDataDto()
        {
            List<FruitsDto> fruitsData = new List<FruitsDto>(){
            new FruitsDto
                {
                    Genus="Musa",
                    Name="Banana",                    
                    Family="Musaceae",
                    Order="Zingiberales",
                    Nutritions = new List<NutritionsDto>(){
                       new NutritionsDto{
                            Carbohydrates=22,
                            Protein=0,
                            Fat=0.2f,
                            Calories=96,
                            Sugar=17.2f
                       }
                    }
                }
            };

            return fruitsData;
        }

        private Response GetResonse()
        {
            var response = new Response() {
                IsSuccess = true,
                Messsage = "Fruit Inserted Successfully"
            };

            return response;
        }
    }
}
