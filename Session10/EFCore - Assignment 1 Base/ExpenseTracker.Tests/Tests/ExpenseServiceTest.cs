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
    public class ExpenseServiceTest : IClassFixture<ExpenseFixture>
    {

        //TODO
        //Fill in the steps for every test
        //1. Create a unique dbcontextoption 
        //2. Setup a new database with fresh data for every test
        //3. Test respective method in the ExpenseService.cs 
        //4. Do atleast 1 assertion using fluent assertions

        //GOAL: This test should run in parallel with CategoryServiceTest

        private readonly ExpenseFixture _expenseFixture;
        public ExpenseServiceTest(ExpenseFixture expenseFixture)
        {
            _expenseFixture = expenseFixture;
        }

        [Fact]
        public void GetAllExpenses_ShouldReturnAllExpenses()
        {
            //Arrange
            //1
            using var context = _expenseFixture.CreateContext();
            //2
            var service = new ExpenseService(context);


            //Act
            //3
            var expenses = service.GetAll().ToList();
            //3;

            //Assert
            //4 Assert that there should be expenses retrieved
            expenses.Should().NotBeNull();
        }

        [Fact]
        public void GetAllOrderedByAmount_ExpensesShouldBeInAscendingOrder()
        {
            //Arrange
            //1
            using var context = _expenseFixture.CreateContext();
            //2
            var service = new ExpenseService(context);
            var result = service.GetAllOrderedByAmount().OrderBy(x => x.ItemAmount).ToList().ElementAt(0);


            //Act
            //3
            var expenses = service.GetAllOrderedByAmount().ToList();
            //3

            //Assert
            //4 Assert that expenses should be in ascending order
            expenses.Should().NotBeNull();
            var firstItem = expenses.First();
            firstItem.Should().BeEquivalentTo(result);
        }

        [Fact]
        public void GetSingleExpense_ShouldReturnRequested()
        {
            //Arrange
            using var context = _expenseFixture.CreateContext();
            //2
            var service = new ExpenseService(context);
            int id = 1;
            var result = service.GetAll().FirstOrDefault(x => x.ExpenseId == id);

            //Act
            //3
            var expense = service.GetSingle(id);
            //3

            //Assert
            //4 Assert that expense returned is the one requested
            expense.Should().BeEquivalentTo(result);
        }

        [Fact]
        public void AddExpense_ShouldSuccessfullyAddExpense()
        {
            //Arrange
            using var context = _expenseFixture.CreateContext();
            //2
            var service = new ExpenseService(context);
            var newExpense = new Expense
            {
                DatePurchased = DateTime.Now,
                Item = "fishball",
                ItemAmount = 5,
                CategoryId = 1
            };

            //Act
            //3
            var expense = service.Add(newExpense);
            context.ChangeTracker.Clear();
            //3

            //Assert
            //4 Assert that expense was added
            expense.Should().NotBeNull();
            var itemName = context.Expenses.Single(x => x.ItemAmount == newExpense.ItemAmount).Item;
            itemName.Should().Be(newExpense.Item);
        }

        [Fact]
        public void DeleteExpense_ShouldSuccessfullyDeleteExpense()
        {
            //Arrange
            using var context = _expenseFixture.CreateContext();
            //2
            var service = new ExpenseService(context);
            var itemToDelete = new Expense
            {
                ExpenseId = 1
            };

            //Act
            //3
            service.Delete(itemToDelete);
            //3

            //Assert
            //4 Assert that expense was deleted
            var expense = context.Expenses.Any(x => x.ExpenseId == 1);
            expense.Should().BeFalse();
        }
    }
}
