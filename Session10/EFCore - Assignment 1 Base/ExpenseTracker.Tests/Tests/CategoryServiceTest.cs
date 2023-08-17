using ExpenseTracker.Data;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Infrastructure.Services;
using ExpenseTracker.Tests.Fixture;
using ExpenseTracker.Tests.Helper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Tests.Tests
{
    public class CategoryServiceTest : IClassFixture<CategoryFixture>
    {
        //TODO
        //Fill in the steps for every test
        //1. Create a unique dbcontextoption 
        //2. Setup a new database with fresh data for every test
        //3. Test respective method in the CategoryService.cs 
        //4. Do atleast 1 assertion using fluent assertions

        //GOAL: This test should run in parallel with ExpenseServiceTest

        private readonly CategoryFixture _categoryFixture;

        public CategoryServiceTest(CategoryFixture categoryFixture)
        {
            _categoryFixture = categoryFixture;
        }

        [Fact]
        public void GetAllCategories_ShouldReturnAllCategories()
        {
            //Arrange
            using var context = _categoryFixture.CreateContext();
            //2
            var service = new CategoryService(context);


            //Act
            //3
            var categories = service.GetAll().ToList();
            //3;

            //Assert
            //4 Assert that there should be expenses retrieved
            categories.Should().NotBeNull();
        }


        [Fact]
        public void GetSingleCategory_ShouldReturnRequested()
        {
            //Arrange
            using var context = _categoryFixture.CreateContext();
            //2
            var service = new CategoryService(context);
            int id = 1;
            var result = service.GetAll().FirstOrDefault(x => x.CategoryId == id);

            //Act
            //3
            var category = service.GetSingle(id);
            //3

            //Assert
            //4 Assert that expense returned is the one requested
            category.Should().BeEquivalentTo(result);
        }

        [Fact]
        public void AddCategory_ShouldSuccessfullyAddCategory()
        {
            //Arrange
            using var context = _categoryFixture.CreateContext();
            //2
            var service = new CategoryService(context);
            var newCategory = new Category
            {
                Description = "Food",
                Name = "Fishball",
            };

            //Act
            //3
            var category = service.Add(newCategory);
            context.ChangeTracker.Clear();
            //3

            //Assert
            //4 Assert that expense was added
            category.Should().NotBeNull();
            var categoryDescription = context.Categories.Single(x => x.Name == newCategory.Name).Description;
            categoryDescription.Should().Be(newCategory.Description);
        }

        [Fact]
        public void DeleteCategory_ShouldSuccessfullyDeleteCategory()
        {
            //Arrange
            using var context = _categoryFixture.CreateContext();
            //2
            var service = new CategoryService(context);
            var itemToDelete = new Category
            {
                CategoryId = 1
            };

            //Act
            //3
            service.Delete(itemToDelete);
            //3

            //Assert
            //4 Assert that expense was deleted
            var category = context.Categories.Any(x => x.CategoryId == 1);
            category.Should().BeFalse();
        }
    }
}
