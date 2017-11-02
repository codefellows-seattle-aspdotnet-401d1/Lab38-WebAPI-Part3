using lab36_miya.Controllers;
using lab36_miya.Data;
using lab36_miya.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void GetReturnsOKWithIntArgument()
        {
            //Arrange
            //var testContext = new Lab36DbContext(new UnitTest1());
            var controller = new CoursesController(new TestDbContext(TestModel));

            //Act
            var result = controller.Get(1);
            ObjectResult statusCode = (ObjectResult) result;

            //Assert
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode) statusCode.StatusCode.Value);
        }

        [Fact]
        public void IDIsAnInt()
        {
            //Arrange
            var newID = new RequiredCoursework();

            //Act
            var result = newID.ID;

            //Assert
            Assert.IsType(typeof(int), result);
        }

        [Fact]
        public void ClassPropertyIsAString()
        {
            //Arrange
            var firstPeriod = new RequiredCoursework();

            //Act
            var result = firstPeriod.Class;

            //Assert
            Assert.IsType(typeof(string), result);
        }
    }
}
