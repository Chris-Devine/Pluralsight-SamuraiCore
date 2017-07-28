using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using SamuraiCoreApp.Data;
using SamuraiCoreApp.Domain;

namespace CoreUI
{
    class Program
    {
        private static SamuraiContext _context = new SamuraiContext();

        static void Main(string[] args)
        {
            InsertSamurai();
            InsertMultipleSamurais();
            SimpleSamauraiQuery();
            MoreQueries();
            RetrieveAndUpdateSamurai();
            RetrieveAndUpdateMultipleSamurais();
            MultipleOperations();
            DeleteWhileTracked();
            DeleteMany();



            Console.Read();
        }

        private static void InsertSamurai()
        {
            var samurai = new Samurai {Name = "Code Ninja"};
            using (var context = new SamuraiContext())
            {
                context.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());
                context.Samurais.Add(samurai);
                context.SaveChanges();
            };
        }
        private static void InsertMultipleSamurais()
        {
            var samurai1 = new Samurai { Name = "Code Ninja 1" };
            var samurai2 = new Samurai { Name = "Code Ninja 2" };
            using (var context = new SamuraiContext())
            {
                context.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());
                context.Samurais.AddRange(new List<Samurai> { samurai1, samurai2 });
                context.SaveChanges();
            };
        }

        private static void SimpleSamauraiQuery()
        {
            using (var context = new SamuraiContext())
            {
                var samurais = context.Samurais.ToList();
                foreach (var samurai in samurais)
                {
                    Console.WriteLine(samurai.Name);
                }
            };
        }

        private static void MoreQueries()
        {
            var name = "Code Ninja";
            var samurais = _context.Samurais.Where(s => s.Name == name);
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }

            var samuraiFirst = _context.Samurais.FirstOrDefault(s => s.Name == name);
            Console.WriteLine(samuraiFirst.Name);
        }

        private static void RetrieveAndUpdateSamurai()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Name += "Master Code Ninja";
            _context.SaveChanges();
        }

        private static void RetrieveAndUpdateMultipleSamurais()
        {
            var samurai = _context.Samurais.ToList();
            samurai.ForEach(s => s.Name = "Code Ninja Master");
            _context.SaveChanges();
        }

        private static void MultipleOperations()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Name += "Master Code Ninja";
            _context.Samurais.Add(new Samurai {Name = "Sneaky Ninja"});
            _context.SaveChanges();
        }

        private static void DeleteWhileTracked()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            _context.Remove(samurai);
            // alternates
            //_context.Remove(samurai);
            //_context.Entry(samurai).State = EntityState.Deleted;
            //_context.Samurais.Remove(_context.Samurais.Find(1));

            _context.SaveChanges();
        }

        private static void DeleteMany()
        {
            var samurais = _context.Samurais.Where(s => s.Name.Contains("Master"));
            _context.Samurais.RemoveRange(samurais);
            //Alternate: _context.RemoveRange(samurais);
            _context.SaveChanges();
        }

    }
}