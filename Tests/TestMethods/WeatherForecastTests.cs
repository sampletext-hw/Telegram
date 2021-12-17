using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using WebAPI.BusinessLogic;
using WebAPI.DataAccess;
using WebAPI.DataRepository;

namespace Tests.TestMethods
{
    public class WeatherForecastTests
    {
        private Mock<IEntityRepository<WeatherForecast>> weatherRepositoryMock;
        private List<WeatherForecast> weatherForecasts;

        [SetUp]
        public void Setup()
        {
            //Set up the mock
            weatherRepositoryMock = new Mock<IEntityRepository<WeatherForecast>>();
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

            //Arrange
            var weatherForecastService = new WeatherForecastService(weatherRepositoryMock.Object);
            var allForecasts           = weatherForecastService.GetAllForecasts();

            //Arrest
            Assert.IsTrue(allForecasts.Count == 3);
            Assert.That(allForecasts[0].Id == 1);
            Assert.That(allForecasts[0].Summary == "Hello");
            Assert.That(allForecasts[0].TemperatureC == 10);
            Assert.That(allForecasts[1].Id == 2);
            Assert.That(allForecasts[1].Summary == "World");
            Assert.That(allForecasts[1].TemperatureC == 20);
            Assert.That(allForecasts[2].Id == 3);
            Assert.That(allForecasts[2].Summary == "!");
            Assert.That(allForecasts[2].TemperatureC == 30);
        }
    }
}