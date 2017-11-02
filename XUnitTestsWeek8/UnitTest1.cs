using System;
using Week8Project.Data;
using Week8Project.Controllers;
using Week8Project.Models;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace XUnitTestsWeek8
{
    public class UnitTest1
    {

        [Fact]
        public void TestGetSpecies()
        {
            //Arrange
            Pokemon testMon = new Pokemon();
            testMon.Species = "Pikachu";
            //Act
            string testString = testMon.Species;

            //Assert
            Assert.Equal(testMon.Species, "Pikachu");

        }

        [Fact]
        public void TestGetType()
        {
            //Arrange
            Pokemon testMon = new Pokemon();
            testMon.Type = "Grass";
            //Act
            string testString = testMon.Type;

            //Assert
            Assert.Equal(testMon.Type, "Grass");

        }

        [Fact]
        public void TestSetSpecies()
        {
            //Arrange
            Pokemon testMon = new Pokemon();

            //Act
            testMon.Species = "Pikachu";

            //Assert
            Assert.Equal(testMon.Species, "Pikachu");

        }

        [Fact]
        public void TestSetType()
        {
            //Arrange
            Pokemon testMon = new Pokemon();
       
            //Act
            testMon.Type = "Grass";

            //Assert
            Assert.Equal(testMon.Type, "Grass");

        }

        // Reference for InMemory Databases: https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/in-memory
        //Test taken from class example
        [Fact]
        public void GetStatusCodeOK()
        {
            var options = new DbContextOptionsBuilder<PokemonDbContext>()
            .UseInMemoryDatabase(databaseName: "getStatusCode")
            .Options;

            //Arrange
            using (var context = new PokemonDbContext(options))
            {
                var controller = new PokemonController(context);

                //Act
                var result = controller.Get(5);
                ObjectResult sc = (ObjectResult)result;

                //Assert
                Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)sc.StatusCode.Value);
            }

        }
    }
}
