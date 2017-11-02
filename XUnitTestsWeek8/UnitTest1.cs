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
        //test Pokemon GET
        [Fact]
        public void PokemonGetStatusCodeOK()
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

        [Fact]
        //test ListType GET
        public void TypeListGetStatusCodeOK()
        {
            var options = new DbContextOptionsBuilder<PokemonDbContext>()
            .UseInMemoryDatabase(databaseName: "getStatusCode")
            .Options;

            //Arrange
            using (var context = new PokemonDbContext(options))
            {
                var controller = new TypeListController(context);

                //Act
                var result = controller.Get("test");
                ObjectResult sc = (ObjectResult)result;

                //Assert
                Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)sc.StatusCode.Value);
            }
        }

        //test Pokemon POST
        [Fact]
        public void TestPostPokemon()
        {
            var options = new DbContextOptionsBuilder<PokemonDbContext>()
            .UseInMemoryDatabase(databaseName: "getStatusCode")
            .Options;

            //Arrange
            using (var context = new PokemonDbContext(options))
            {
                var controller = new PokemonController(context);
                Pokemon testPokemon = new Pokemon();
                testPokemon.Species = "test";
                testPokemon.Type = "test";

                //Act
                var result = controller.Post(testPokemon);
                CreatedAtActionResult caar = (CreatedAtActionResult)result.Result;
                

                //Assert
                Assert.Equal(HttpStatusCode.Created, (HttpStatusCode)caar.StatusCode);
            }
        }

        //test ListType POST
        [Fact]
        public void TestPostTypeList()
        {
            var options = new DbContextOptionsBuilder<PokemonDbContext>()
            .UseInMemoryDatabase(databaseName: "getStatusCode")
            .Options;

            //Arrange
            using (var context = new PokemonDbContext(options))
            {
                var controller = new TypeListController(context);
                TypeList testLiist = new TypeList();
                testLiist.Type = "test";

                //Act
                var result = controller.Post(testLiist);
                CreatedAtActionResult caar = (CreatedAtActionResult)result.Result;


                //Assert
                Assert.Equal(HttpStatusCode.Created, (HttpStatusCode)caar.StatusCode);
            }
        }

    }
}
