using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            // PrintAllProducts();
            // PrintAllCustomers();
            // Exercise1();
            // Exercise2();
            // Exercise3();
            // Exercise4();
            // Exercise5();
            // Exercise6();
            // Exercise7();
            // Exercise8();
            // Exercise9();
            // Exercise10();
            // Exercise11();
            // Exercise12();
            // Exercise13();
            // Exercise14();
            // Exercise15();
            // Exercise16();
            // Exercise17();
            // Exercise18();
            // Exercise19();


            Exercise26();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            var filtered = DataLoader.LoadProducts();
            filtered = filtered.Where(p => p.UnitsInStock < 1).ToList();
            PrintProductInformation(filtered);
            Console.WriteLine(filtered);
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            var InStockAndOver3 = DataLoader.LoadProducts();
            InStockAndOver3 = InStockAndOver3.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3).ToList();
            PrintProductInformation(InStockAndOver3);
        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            var WashingtonCustomers = DataLoader.LoadCustomers();
            WashingtonCustomers = WashingtonCustomers.Where(p => p.Region == "WA").ToList();
            PrintCustomerInformation(WashingtonCustomers);
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            var allProducts = DataLoader.LoadProducts();
            var onlyName = from product in allProducts
                           select new { product.ProductName };

            foreach (var product in onlyName)
            {
                Console.WriteLine(product);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            var priceUp25 = DataLoader.LoadProducts().Select(p => new
            {
                p.ProductID,
                p.ProductName,
                UnitPrice = (p.UnitPrice * 1.25M),
                p.UnitsInStock
            });

            

            foreach (var product in priceUp25 )
            {
                Console.WriteLine("{0},{1},{2},{3}", product.ProductID, product.ProductName, product.UnitPrice, product.UnitsInStock);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
       
                          
                var productNameAndCategoryOnly = DataLoader.LoadProducts().Select(p => new
                {
                    ProductName = p.ProductName.ToUpper(),
                    ProductCategory = p.Category.ToUpper()
                });

                string line = "{0,-35} {1,-15}";
                Console.WriteLine(line, "Product Name", "Category");
                Console.WriteLine("========================================================");

                foreach (var product in productNameAndCategoryOnly)
                {
                    Console.WriteLine(line, product.ProductName, product.ProductCategory);
                }
            }

            /// <summary>
            /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
            /// be set to true if the Units in Stock is less than 3
            /// 
            /// Hint: use a ternary expression
            /// </summary>
            static void Exercise7()
        {
            var reOrderedAdded = DataLoader.LoadProducts().Select(p => new
            {
                p.Category,
                p.ProductID,
                p.ProductName,
                p.UnitPrice,
                p.UnitsInStock,
                ReOrder = p.UnitsInStock < 3 ? "true" : ""
            });
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6} {5,10:c}";
            Console.WriteLine(line, "Product Category", "Product ID", "Product Name", "Unit Price", "Units in Stock", "ReOrder");
            Console.WriteLine("========================================================");

            foreach (var product in reOrderedAdded)
            {
                Console.WriteLine(line, product.Category, product.ProductID, product.ProductName, product.UnitPrice, product.UnitsInStock, product.ReOrder);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            var stockValue = DataLoader.LoadProducts().Select(p => new
            {
                p.Category,
                p.ProductID,
                p.ProductName,
                p.UnitPrice,
                p.UnitsInStock,
                stockValue = p.UnitsInStock * p.UnitPrice
            });
            string line = "{0,-15} {1,-15} {2,-15} {3,15} {4,-10} {5,-10}";
            Console.WriteLine(line, "Product Category", "Product ID", "Product Name", "Unit Price", "Units in Stock", "Stock Value");
            Console.WriteLine("========================================================");

            foreach (var product in stockValue)
            {
                Console.WriteLine(line, product.Category, product.ProductID, product.ProductName, product.UnitPrice, product.UnitsInStock, product.stockValue);
            }
        }
    

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            var onlyEven = DataLoader.NumbersA.Where(number => number % 2 != 1);
            Console.Write("The even numbers are: ");

            foreach (var number in onlyEven)
            {
                Console.Write("{0} ", number);
            }
            Console.WriteLine("");
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {
            // join customer and order tables ?
            // (where Order.Total < 500)
            // print customers
        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            {
                var first3Odd = DataLoader.NumbersC.Where(number => number % 2 == 1).Take(3);
                
                foreach (var number in first3Odd)
                {
                    Console.WriteLine(number);
                }
                
            }
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            {
                var skipFirst3 = DataLoader.NumbersB;

                foreach (var number in skipFirst3.Skip(3))
                {
                    Console.WriteLine(number);
                }

            }
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        //static void Exercise13()
        //{
        //    {
        //        var recentWAOrders = DataLoader.LoadCustomers().Select (c => new
        //        {
        //            c.CompanyName,
        //            c.Orders;
        //        }
        //    foreach (var customer in recentWAOrders)
        //    {
        //        Console.WriteLine(c.Comapny, c.Orders.Take(1));
        //    }
        //    }
        //}

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            var upUntil6 = DataLoader.NumbersC;

            foreach (var number in upUntil6)
            {
                if (number < 6)
                {
                    Console.WriteLine(number);
                }
                if (number >=6)
                {
                    break;
                }
            }

        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        //static void Exercise15()
        //{
        //    var afterMod3 = DataLoader.NumbersC;

        //    foreach (var number in afterMod3)
        //    {
        //        if (number % 3 != 0)
        //        {
        //            Skip(number);
        //        }
        //        else
        //        {
        //            Console.WriteLine(number);
        //        }
        //    }
        //}

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        //static void Exercise16()
        //{
        //    var productAlphabeticalOrder = DataLoader.LoadProducts()
        //                    .Where() 
        //                    .OrderBy(p => p.ProductName).ToList();
        //    Console.WriteLine(productAlphabeticalOrder);

        //}

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        //static void Exercise17()
        //{
        //    var productDescendingOrder = DataLoader.LoadProducts()
        //                     .Where()
        //                    .OrderByDescending(p => p.UnitsInStock);
        //    Console.WriteLine(productDescendingOrder);
        //}

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {

        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            var reverseNumbers = DataLoader.NumbersC;
            reverseNumbers = reverseNumbers.Reverse().ToArray();

            foreach(var number in reverseNumbers)
            {
                Console.Write(number);
            }
            Console.WriteLine();
          
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        //static void Exercise20()
        //{
        //    var groupProductsByCategory = DataLoader.LoadProducts();
        //    var groupProductsByCategory = from category in Product
        //                                  group category by category.Product

        //}

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21() //DO NOT DO
        {

        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {

        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {

        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {

        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {

        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            var countOdds = DataLoader.NumbersA;
            int oddCount = 0;
            int evenCount = 0;

            foreach(var number in countOdds)
            {
                if(number % 2 == 1)
                {
                    oddCount++;
                }
                else
                {
                    evenCount++;
                }     
            }
            Console.WriteLine("There was {0} odd numbers and {1} even numbers.",oddCount,evenCount);
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {

        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {

        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {

        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {

        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {

        }
    }
}
