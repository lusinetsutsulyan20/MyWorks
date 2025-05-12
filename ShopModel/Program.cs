using System.Reflection;
using System.Reflection.Metadata;
using System.Threading.Tasks.Dataflow;
using Microsoft.VisualBasic;

class Program
{
    public static void Main(string[] args)
    {
        var categories = new List<Category>
        {
            new Category(1, "Books"),
            new Category(2, "Electronics"),
            new Category(3, "Clothing"),
            new Category(4, "Home & Kitchen"),
            new Category(5, "Toys")
        };

        var products = new List<Product>
        {
            new Product(1, "C# Programming Book", 29.99, 1),
            new Product(2, "JavaScript for Beginners", 24.99, 1),
            new Product(3, "Blender", 59.99, 4),
            new Product(4, "Smartphone", 499.99, 2),
            new Product(5, "Laptop", 999.99, 2),
            new Product(6, "Tablet", 199.99, 2),
            new Product(7, "T-Shirt", 14.99, 3),
            new Product(8, "Jeans", 39.99, 3),
            new Product(9, "Jacket", 89.99, 3),
            new Product(10, "Lego Set", 89.99, 5),
            new Product(11, "Action Figure", 19.99, 5),
            new Product(12, "Cooking Pot", 34.99, 4),
            new Product(13, "Electric Kettle", 24.99, 4),
            new Product(14, "Data Structures Book", 34.99, 1),
            new Product(15, "Monitor", 149.99, 2),
            new Product(16, "Keyboard", 49.99, 2),
            new Product(17, "Microwave", 99.99, 4)
        };

        var sections = new List<Marketing>
        {
            new Marketing(1, "Holiday Sale"),
            new Marketing(2, "Buy One Get One"),
            new Marketing(3, "Summer Clearance"),
            new Marketing(4, "New Arrivals Launch"),
            new Marketing(5, "Back to School Promo")
        };

        var employees = new List<Employee>
        {
            new Employee(1, "Alice Johnson", 55000m, 1),
            new Employee(2, "Bob Smith", 62000m, 2),
            new Employee(3, "Catherine Lee", 58000m, 1),
            new Employee(4, "David Brown", 70000m, 3),
            new Employee(5, "Eva Green", 64000m, 2),
            new Employee(6, "Frank Moore", 75000m, 4),
            new Employee(7, "Grace Hall", 53000m, 1),
            new Employee(8, "Henry Scott", 60000m, 3),
            new Employee(9, "Isabella Adams", 72000m, 4),
            new Employee(10, "Jack Turner", 50000m, 2)
        };

        var users = new List<User>
        {
            new User(1, "Anna"),
            new User(2, "Brian"),
            new User(3, "Carla"),
            new User(4, "Derek"),
            new User(5, "Emily")
        };
        var orders = new List<Order>
        {
            new Order(1, 1, OrderStatus.Pending),
            new Order(2, 1, OrderStatus.Deliveried),
            new Order(3, 2, OrderStatus.OnTheWay),
            new Order(4, 3, OrderStatus.Deliveried),
            new Order(5, 3, OrderStatus.Pending),
            new Order(6, 3, OrderStatus.OnTheWay),
            new Order(7, 4, OrderStatus.PaymentRejected),
            new Order(8, 5, OrderStatus.Deliveried)
        };

        var orderDetails = new List<OrderDetails>
        {
            new OrderDetails(1, 1, 1, 1),    // User 1
            new OrderDetails(2, 1, 2, 2),    // User 1
            new OrderDetails(3, 2, 3, 1),    // User 1
            new OrderDetails(4, 3, 4, 1),    // User 2
            new OrderDetails(5, 4, 5, 1),    // User 3
            new OrderDetails(6, 5, 6, 2),    // User 3
            new OrderDetails(7, 5, 7, 1),    // User 3
            new OrderDetails(8, 6, 8, 3),    // User 3
            new OrderDetails(9, 7, 9, 1),    // User 4
            new OrderDetails(10, 8, 10, 1),  // User 5
            new OrderDetails(11, 2, 11, 2),  // User 1
            new OrderDetails(12, 5, 12, 1),  // User 3
            new OrderDetails(13, 6, 13, 1),  // User 3
            new OrderDetails(14, 6, 14, 2),  // User 3
            new OrderDetails(15, 6, 15, 1)   // User 3
        };


// Գտնել այն user-ներին, որոնք գոնե մեկ պատվեր արել են (հուշում join-ը, արդեն իսկ ներառում է միայն պատվեր արածներին)
// Տպել յուրաքանչյուր աշխատակցի անունը և department-ի անունը, որտեղ աշխատում են
// Այն ապրանքները, որոնք որևէ պատվերի մեջ եղել են ավելի քան 2 հատ քանակով
// Յուրաքանչյուր user-ի համար ցույց տալ նրա կատարած պատվերների քանակը
// Գտնել ամենաշատ պատվերներ արած մարդու անունը
// Գտնել ամենաթանկ պատվերը կատարած userին
// 3 ամենահաճախ պատվիրված ապրանքները
// Ապրանքներ, որոնք երբևէ չեն պատվիրվել (կարող եք օգտվել Any մեթոդից)
// Յուրաքանչյուր userի անունը և իր ծախսած ընդհանուր գումարը պատվերներում



//// Գտնել այն user-ներին, որոնք գոնե մեկ պատվեր արել են (հուշում join-ը, արդեն իսկ ներառում է միայն պատվեր արածներին)

        var HasOrder =  from order in orders 
                        join user in users on order.userId equals user.Id
                        select user.Name;

        foreach(var item in HasOrder)
        {
            Console.WriteLine(item);
        }
                        

// Տպել յուրաքանչյուր աշխատակցի անունը և department-ի անունը, որտեղ աշխատում են

        // var employeeDepartment = from employee in employees
        //                         join s in sections on employee.sectionId equals s.Id
        //                         select new 
        //                         {
        //                             Department = s.Name,
        //                             Employee = employee.Name
        //                         };

        // foreach(var item in employeeDepartment)
        // {
        //     Console.WriteLine(item);
        // }

        var employeeDepartment = from e in employees
                                group e by e.sectionId into g
                                 
                                join s in sections on g.Key equals s.Id
                                select new 
                                {
                                    Department = s.Name,
                                    Employees = g.Select(emp => emp.Name).ToList()
                                };

        foreach (var item in employeeDepartment)
        {
            Console.WriteLine($"Department = {item.Department}, Employees = [{string.Join(", ", item.Employees)}]");
        }


// // Այն ապրանքները, որոնք որևէ պատվերի մեջ եղել են ավելի քան 2 հատ քանակով

        var manyOrsers =    from o in orderDetails
                            where o.count > 2
                            group o by o.productId into g
                            join p in products on g.Key equals p.Id
                            select p.Name;

        foreach (var item in manyOrsers)
        {
            Console.WriteLine(item);
        }


// Յուրաքանչյուր user-ի համար ցույց տալ նրա կատարած պատվերների քանակը

    var userOrders =    from o in orders 
                        group o by o.userId into g
                        join u in users on g.Key equals u.Id
                        select new
                        {
                            User = u.Name,
                            OrsersCount = g.Count()
                        };

    foreach(var item in userOrders)
    {
        Console.WriteLine($"User = {item.User}, Orders count = {item.OrsersCount}");
    }


// Գտնել ամենաշատ պատվերներ արած մարդու անունը

        var userWithMostOrders =    (from o in orders
                                    group o by o.userId into g
                                    where g.Count() == 
                                        (from o in orders
                                        group o by o.userId into k
                                        select k.Count())
                                        .Max()
                                    join u in users on g.Key equals u.Id
                                    select u.Name).First();

        Console.WriteLine(userWithMostOrders);

// Գտնել ամենաթանկ պատվերը կատարած userին

        var userWithMostExpenciveOrder =    (from u in users 
                                            where u.Id ==
                                                (from o in orderDetails
                                                where o.productId == 
                                                    (from p in products
                                                    where p.Price ==
                                                        (from pr in products
                                                        select pr.Price).Max()
                                                    select p.Id).First()
                                                join or in orders on o.orderId equals or.Id
                                                select or.userId).First()
                                            select u.Name).First();

        Console.WriteLine(userWithMostExpenciveOrder);
                                            

// 3 ամենահաճախ պատվիրված ապրանքները

        var oftenOrder =    from or in orderDetails
                            group or by or.productId into g
                            orderby g.Sum(o => o.count) descending
                            select new
                            {
                                ProductId = g.Key,
                                TotalCount = g.Sum(o => o.count)
                            };

        var oftenOrderProducts =    (from o in oftenOrder
                                    join p in products on o.ProductId equals p.Id
                                    select p.Name).Take(3);

        foreach(var item in oftenOrderProducts)
        {
            Console.WriteLine(item);
        }



// Ապրանքներ, որոնք երբևէ չեն պատվիրվել (կարող եք օգտվել Any մեթոդից)
        var notOrders = from p in products
                        where !orderDetails.Any(o => o.productId == p.Id)
                        select p.Name;

         foreach(var item in notOrders)
        {
            Console.WriteLine(item);
        }

// Յուրաքանչյուր userի անունը և իր ծախսած ընդհանուր գումարը պատվերներում

        var userWithPurchuase = from o in orders
                                join or in orderDetails on o.Id equals or.orderId
                                join u in users on o.userId equals u.Id
                                join p in products on or.productId equals p.Id
                                group new { or, p } by u.Name into g
                                select new
                                {
                                    User = g.Key,
                                    Purchuase = g.Sum(x => x.or.count * x.p.Price)
                                };

        foreach(var item in userWithPurchuase)
        {
            Console.WriteLine($"User name: {item.User}, User's purchuase: {item.Purchuase}");
        }

    }
}