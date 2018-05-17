using System;
using System.Collections.Generic;
using System.Linq;
using DAL.EF;
using DAL.Entities;

namespace TestOneToMany
{
    class Program
    {
        static void Main(string[] args)
        {
            DataContext dataContext = new DataContext("Server=(localdb)\\mssqllocaldb;Database=Theatre;Trusted_Connection=True;");
            
            Theatre theatre = new Theatre() { Name = "First" };

            Hall hall = new Hall() { Name = "Green", Theatre = theatre };


            List<Place> places = new List<Place>()
            {
                new Place() { Buyed = true, Hall = hall, Number = 1, NumberRow = 1, },
                new Place() { Buyed = true, Hall = hall, Number = 2, NumberRow = 1, },
                new Place() { Buyed = true, Hall = hall, Number = 3, NumberRow = 1, }
            };
            
            Order order = new Order() { Places = places };

            using (dataContext)
            {
                dataContext.Orders.Add(order);
                dataContext.SaveChanges();

                List<Place> places1 = dataContext.Places.Where(p => p.OrderId == order.OrderId).ToList();

                Console.WriteLine(places1.Count);
            }
        }
    }
}
