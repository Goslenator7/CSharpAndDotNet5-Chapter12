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
                    .OrderByDescending(product => product.UnitPrice)
                    // query is now an IOrderedQueryable<Product>
                    .Select(product => new // anonymous type
                     {
                        product.ProductID,
                        product.ProductName,
                        product.UnitPrice
                     });

                WriteLine("Products that cost less than $10: ");
                foreach (var item in query)
                {
                    WriteLine($"{item.ProductID}: {item.ProductName} costs {item.UnitPrice:$#,##0.00}");
                }
                WriteLine();
            }
        }

        static void JoinCategoriesAndProducts()
        {
            using (var db = new Northwind())
            {
                // join every product to its category
                var queryJoin = db.Categories.Join(
                    inner: db.Products,
                    outerKeySelector: category => category.CategoryID,
                    innerKeySelector: product => product.CategoryID,
                    resultSelector: (c, p) =>
                        new {c.CategoryName, p.ProductName, p.ProductID })
                    .OrderBy(cp => cp.CategoryName);

                foreach (var item in queryJoin)
                {
                    WriteLine($"{item.ProductID}: {item.ProductName} is in {item.CategoryName}");
                }
            }
        }

        static void GroupJoinCategoriesAndProducts()
        {
            using (var db = new Northwind())
            {
                // group all products by their category
                var queryGroup = db.Categories.AsEnumerable().GroupJoin(
                    inner: db.Products,
                    outerKeySelector: category => category.CategoryID,
                    innerKeySelector: product => product.CategoryID,
                    resultSelector: (c, matchingProducts) => new
                    {
                        c.CategoryName,
                        Products = matchingProducts.OrderBy(p => p.ProductName)
                    });

                foreach (var item in queryGroup)
                {
                    WriteLine($"{item.CategoryName} has {item.Products.Count()}");

                    foreach (var product in item.Products)
                    {
                        WriteLine($" {product.ProductName}");
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            //FilterAndSort();
            //JoinCategoriesAndProducts();
            GroupJoinCategoriesAndProducts();
        }
    }
}
