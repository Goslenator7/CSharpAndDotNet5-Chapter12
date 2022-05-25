using System;
using static System.Console;
using Packt.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LinqWithEFCore
{
    class Program
    {
        static void FilterAndSort()
        {
            using (var db = new Northwind())
            {
                var query = db.Products
                    //query is a DbSet<Product>
                    .Where(product => product.UnitPrice < 10M)
                    //query is now an IQueryable<Product>
                    .OrderByDescending(product => product.UnitPrice);

                WriteLine("Products that cost less than $10: ");
                foreach (var item in query)
                {
                    WriteLine($"{item.ProductID}: {item.ProductName} costs {item.UnitPrice:$#,##0.00}");
                }
                WriteLine();
            }
        }

        static void Main(string[] args)
        {
            FilterAndSort();
        }
    }
}
