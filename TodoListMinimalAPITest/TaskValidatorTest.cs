using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.VisualBasic;
using System.Diagnostics;
using TodoListMinimalAPI.Data;
using TodoListMinimalAPI.Endpoints;
using TodoListMinimalAPI.Validators;

namespace TodoListMinimalAPITest
{
    public class TaskValidatorTest
    {
        [Fact]
        public void Valid_ShouldBeEmpty()
        {
            //Arrange
            TaskModel model = new()
            {
                Title = "Valid title",
                Subject = "Valid subject",
                Description = "Valid description",
                Grade = 5,
                DueDate = DateOnly.FromDateTime(DateTime.Now)
            };

            //Act
            var actual = TaskValidator.Valid(model);

            //Assert
            Assert.Empty(actual);
        }

        [Fact]
        public void Valid_ShouldNotBeEmpty()
        {
            var response = new TaskModel()
            {
                Title = "",
                Subject = "",
                Description = "Valid description",
                Grade = 5,
                DueDate = DateOnly.FromDateTime(DateTime.Now)
            };

            //Act
            var teste = TaskValidator.Valid(response);

            //Assert
            Assert.NotEmpty(teste);
        }

    }
}
