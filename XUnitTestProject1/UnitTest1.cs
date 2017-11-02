using lab36_miya.Controllers;
using lab36_miya.Data;
using lab36_miya.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var options = new DbContextOptionsBuilder<Lab36DbContext>()
            .UseInMemoryDatabase(databaseName: "getStatusCode")
            .Options;

            //Arrange

            using (var context = new Lab36DbContext(options))
            {

                var controller = new CoursesController(context);

                //Act
                var result = controller.Get(2);
                ObjectResult sc = (ObjectResult)result;

                //Assert
                Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)sc.StatusCode.Value);
            }
        }

        //failing
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

        [Fact]
        public void StatusCodeCreated()
        {
            var options = new DbContextOptionsBuilder<Lab36DbContext>()
                .UseInMemoryDatabase(databaseName: "ReturnCreated")
                .Options;

            using (var context = new Lab36DbContext(options))
            {

                var controller = new CoursesController(context);

                RequiredCoursework requiredCoursework = new RequiredCoursework();

                requiredCoursework.ID = 13;
                requiredCoursework.Class = "runningTest";
                requiredCoursework.IsComplete = true;

            
                var result = controller.Post(requiredCoursework);

                CreatedAtActionResult caar = (CreatedAtActionResult)result.Result;
                //ObjectResult ok = (ObjectResult)result;

                Assert.Equal(HttpStatusCode.Created, (HttpStatusCode)caar.StatusCode.Value);
            }
        }
        //test status codes
        [Fact]
        public void DatabaseHasContent()
        {
            var options = new DbContextOptionsBuilder<Lab36DbContext>()
                .UseInMemoryDatabase(databaseName: "GetStatusCode")
                .Options;


            using (var context = new Lab36DbContext(options))
            {
                var controller = new CoursesController(context);

                RequiredCoursework rc = new RequiredCoursework();
                rc.ID = 13;
                rc.Class = "runningTest";
                rc.IsComplete = true;

                var result = controller.Post(rc);

                var find = context.RequiredCoursework.FirstOrDefaultAsync(f => f.Class == rc.Class);
                int number = context.RequiredCoursework.Local.Count;
            }
        }

        [Fact]
        public void TestLists()
        {
            var options = new DbContextOptionsBuilder<Lab36DbContext>()
                .UseInMemoryDatabase(databaseName: "GetStatusCode")
                .Options;


            using (var context = new Lab36DbContext(options))
            {
                var controller = new MajorsController(context);

                Majors focus = new Majors();
                focus.ID = 13;
                focus.Name = "A new Major list";
               
                var result = controller.Post(focus);

                var find = context.Majors.FirstOrDefaultAsync(f => f.Name == focus.Name);
                int number = context.Majors.Local.Count;
            }
        }
    }
}
