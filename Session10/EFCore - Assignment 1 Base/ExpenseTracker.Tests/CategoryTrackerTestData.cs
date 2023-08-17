using ExpenseTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Tests
{
    public class CategoryTrackerTestData
    {
        public static IEnumerable<Category> CategoryData()
        {
            return new List<Category>
            {
                new Category
                {
                    Name = "Category1",
                    Description = "Category1"
                },

                new Category
            {
                Name = "Category2",
                Description = "Category2"
            }
        };

    }
};
}

