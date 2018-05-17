using DAL.EF;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace InitializeDataBase
{
    class Init
    {
        public void Initialize()
        {
            using (DataContext db = new DataContext(new DbContextOptionsBuilder<DataContext>()
                .UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = Theatre; Trusted_Connection = True; MultipleActiveResultSets = true").Options))
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                Theatre theatre = new Theatre() { Name = "London theatre", Img = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3b/Palace_Theatre_-_London.jpg/1200px-Palace_Theatre_-_London.jpg" };
                Theatre theatre2 = new Theatre() { Name = "Paris theatre", Img = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/41/Paris_theatre_de_la_Renaissance.jpg/1200px-Paris_theatre_de_la_Renaissance.jpg" };
                Play play = new Play() { Name = "Romeo&Julietta", Theatre = theatre, Img = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/55/Romeo_and_juliet_brown.jpg/220px-Romeo_and_juliet_brown.jpg" };
                Play play2 = new Play() { Name = "Romeo&Julietta", Theatre = theatre2, Img = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/55/Romeo_and_juliet_brown.jpg/220px-Romeo_and_juliet_brown.jpg" };
                Hall hall = new Hall() { Name = "Green Hall", Play = play };
                Hall hall2 = new Hall() { Name = "Green Hall", Play = play2 };
                List<Place> places = new List<Place>()
                {
                    new Place() { Buyed = false, Number = 1, Hall = hall },
                    new Place() { Buyed = false, Number = 2, Hall = hall },
                    new Place() { Buyed = false, Number = 3, Hall = hall },
                    new Place() { Buyed = false, Number = 4, Hall = hall },
                    new Place() { Buyed = false, Number = 5, Hall = hall },
                    new Place() { Buyed = false, Number = 6, Hall = hall },
                    new Place() { Buyed = false, Number = 7, Hall = hall },
                    new Place() { Buyed = false, Number = 8, Hall = hall },
                    new Place() { Buyed = false, Number = 9, Hall = hall },
                    new Place() { Buyed = false, Number = 10, Hall = hall },
                    new Place() { Buyed = false, Number = 11, Hall = hall },
                    new Place() { Buyed = false, Number = 12, Hall = hall },
                };

                List<Place> places2 = new List<Place>()
                {
                    new Place() { Buyed = false, Number = 1, Hall = hall2 },
                    new Place() { Buyed = false, Number = 2, Hall = hall2 },
                    new Place() { Buyed = false, Number = 3, Hall = hall2 },
                    new Place() { Buyed = false, Number = 4, Hall = hall2 },
                    new Place() { Buyed = false, Number = 5, Hall = hall2 },
                    new Place() { Buyed = false, Number = 6, Hall = hall2 },
                    new Place() { Buyed = false, Number = 7, Hall = hall2 },
                    new Place() { Buyed = false, Number = 8, Hall = hall2 },
                    new Place() { Buyed = false, Number = 9, Hall = hall2 },
                    new Place() { Buyed = false, Number = 10, Hall = hall2 },
                    new Place() { Buyed = false, Number = 11, Hall = hall2 },
                    new Place() { Buyed = false, Number = 12, Hall = hall2 },
                };
                db.Theatres.Add(theatre);
                db.Theatres.Add(theatre2);
                db.Halls.Add(hall);
                db.Halls.Add(hall2);
                db.Plays.Add(play);
                db.Plays.Add(play2);
                db.Places.AddRange(places);
                db.Places.AddRange(places2);

                db.SaveChanges();
            }
        }
    }
}