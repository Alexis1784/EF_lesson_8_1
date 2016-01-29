using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EF_lesson_8_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Phone p = new Phone { Name = "Nokia Lumia 930", Price = 13000 };

            SaveObjectsAsync(p).Wait();
            
            Phone p2 = new Phone { Name = "iPhone 6", Price = 33000 };
            DbCommandAsync(p2).Wait();
            
            Task t = GetObjectsAsync();
            t.Wait();

            

            Console.Read();
        }
        public static async Task GetObjectsAsync()
        {
            using (MobileContext db = new MobileContext())
            {
                await db.Phones.ForEachAsync(p =>
                {
                    Console.WriteLine("{0} ({1})", p.Name, p.Price);
                });
            }
        }

        private static async Task SaveObjectsAsync(Phone p)
        {
            using (MobileContext db = new MobileContext())
            {
                db.Phones.Add(p);
                await db.SaveChangesAsync();
            }
        }
        private static async Task DbCommandAsync(Phone p)
        {
            using (MobileContext db = new MobileContext())
            {
                System.Data.SqlClient.SqlParameter name = new System.Data.SqlClient.SqlParameter("name", p.Name);
                System.Data.SqlClient.SqlParameter price = new System.Data.SqlClient.SqlParameter("price", p.Price);
                await db.Database.ExecuteSqlCommandAsync("INSERT INTO Phones (Name, Price) VALUES (@name, @price)", name, price);
            }
        }
    }
}
