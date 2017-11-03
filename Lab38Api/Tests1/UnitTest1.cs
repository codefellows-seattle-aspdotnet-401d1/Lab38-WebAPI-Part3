using Lab38Api.Controllers;
using Lab38Api.Data;
using Lab38Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using Xunit;

namespace Tests1
{
    public class UnitTest1
    {
        [Fact]
        public void TestGetTask()
        {
            //Arrange
            BirthdayPlan PlanA = new BirthdayPlan
            {
                Task = "Get Cake from costco"
            };

            //Act
            string test = PlanA.Task;

            //Assert
            Assert.Equal(test, "Get Cake from costco");
        }

        [Fact]
        public void TestGetIsDone()
        {
            //Arrange
            BirthdayPlan PlanC = new BirthdayPlan
            {
                IsComplete = false
            };

            //Act
            bool test = PlanC.IsComplete;

            //Assert
            Assert.Equal(test, false);
        }

        [Fact]
        public void TestSetTask()
        {
            //Arrange
            BirthdayPlan PlanD = new BirthdayPlan
            {
                //Act
                Task = "Stressing out over data structures"
            };

            //Assert
            Assert.Equal(PlanD.Task, "Stressing out over data structures");

        }

        [Fact]
        public void TestDbStatus()
        {
            var options = new DbContextOptionsBuilder<BirthdayPlanDbContext>()
                .UseInMemoryDatabase(databaseName: "getStatusCode")
                .Options;

            using (var context = new BirthdayPlanDbContext(options))
            {
                var controller = new TaskController(context);

                BirthdayPlan birthdayPlan = new BirthdayPlan();
                birthdayPlan.Task = "Unit Test Task";
                birthdayPlan.IsComplete = true;
                birthdayPlan.BirthdayID = 1;

                var result = controller.Post(birthdayPlan);

                CreatedAtActionResult Caar = (CreatedAtActionResult)result.Result;

                Assert.StrictEqual(HttpStatusCode.Created, (HttpStatusCode)Caar.StatusCode.Value);
            }
        }

        [Fact]
        public void DatabaseContent()
        {

            var options = new DbContextOptionsBuilder<BirthdayPlanDbContext>()
                .UseInMemoryDatabase(databaseName: "getStatusCode")
                .Options;

            using (var context = new BirthdayPlanDbContext(options))
            {
                var controller = new TaskController(context);

                BirthdayPlan birthdayPlan = new BirthdayPlan();
                birthdayPlan.Task = "Unit Test Task";
                birthdayPlan.IsComplete = true;
                birthdayPlan.BirthdayID = 1;

                var result = controller.Post(birthdayPlan);

                var find = context.BirthdayPlan.FirstOrDefaultAsync(t => t.Task == birthdayPlan.Task);

                int number = context.BirthdayPlan.Local.Count;

                Assert.Equal(1, number);
            }

        }
        [Fact]
        public void TestListStatus()
        {
            var options = new DbContextOptionsBuilder<BirthdayPlanDbContext>()
                .UseInMemoryDatabase(databaseName: "getStatusCode")
                .Options;

            using (var context = new BirthdayPlanDbContext(options))
            {
                var controller = new ListController(context);

                Birthday birthday = new Birthday();
                birthday.Name = "Unit Test List";

                var result = controller.Post(birthday);

                CreatedAtActionResult Caar = (CreatedAtActionResult)result.Result;

                Assert.StrictEqual(HttpStatusCode.Created, (HttpStatusCode)Caar.StatusCode.Value);
            }
        }
    }
}
