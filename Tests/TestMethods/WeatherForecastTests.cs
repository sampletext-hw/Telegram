using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using WebAPI.BusinessLogic;
using WebAPI.Controllers;
using WebAPI.DataAccess;
using WebAPI.DataRepository;

namespace Tests.TestMethods
{
    public class WeatherForecastTests
    {
        private Mock<IEntityRepository<WeatherForecast>> weatherRepositoryMock;
        private Mock<WeatherForecastService> weatherServiceMock;
        private List<WeatherForecast> weatherForecasts;

        [SetUp]
        public void Setup()
        {
            //Set up the mock
            weatherRepositoryMock = new Mock<IEntityRepository<WeatherForecast>>();
            weatherServiceMock    = new Mock<WeatherForecastService>(weatherRepositoryMock.Object);
            weatherForecasts      = new List<WeatherForecast>();
            weatherForecasts.Add(new WeatherForecast() { Id = 1, Date = DateTime.Now, Summary = "Hello", TemperatureC = 10 });
            weatherForecasts.Add(new WeatherForecast() { Id = 2, Date = DateTime.Now, Summary = "World", TemperatureC = 20 });
            weatherForecasts.Add(new WeatherForecast() { Id = 3, Date = DateTime.Now, Summary = "!", TemperatureC     = 30 });
        }

        [Test]
        public void TestGetAll()
        {
            //Act
            weatherRepositoryMock.Setup(a => a.GetAllQueryable()).Returns(weatherForecasts.AsQueryable());

            weatherServiceMock.Setup(s => s.GetAllForecasts()).Returns(weatherRepositoryMock.Object.GetAllQueryable().ToList());
            var weatherForecastService = weatherServiceMock.Object;

            //Arrange
            var weatherForecastController = new WeatherForecastController(weatherForecastService);
            var allForecastsEnumerable    = weatherForecastController.Get();
            var allForecastsList          = allForecastsEnumerable.ToList();

            //Arrest
            Assert.IsTrue(allForecastsList.Count == 3);
            Assert.That(allForecastsList[0].Id == 1);
            Assert.That(allForecastsList[0].Summary == "Hello");
            Assert.That(allForecastsList[0].TemperatureC == 10);
            Assert.That(allForecastsList[1].Id == 2);
            Assert.That(allForecastsList[1].Summary == "World");
            Assert.That(allForecastsList[1].TemperatureC == 20);
            Assert.That(allForecastsList[2].Id == 3);
            Assert.That(allForecastsList[2].Summary == "!");
            Assert.That(allForecastsList[2].TemperatureC == 30);
        }
    }
}