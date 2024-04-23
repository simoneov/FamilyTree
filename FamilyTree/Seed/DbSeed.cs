using FamilyTree.Data;
using FamilyTree.Enums;
using FamilyTree.Models;
using System.Buffers;
using System.Reflection.PortableExecutable;

namespace FamilyTree.Seed
{
    public class DbSeed
    {
        private readonly AppDbContext _context;

        public DbSeed(AppDbContext context)
        {
            _context = context;
        }

        public void doSeed()
        {
            _context.Weddings.RemoveRange(_context.Weddings);
            _context.PeoplePeople.RemoveRange(_context.PeoplePeople);
            _context.People.RemoveRange(_context.People);
            List<Person> persons = new()
            {
                new Person
                {   
                    Name = "Valter",
                    Surname = "Copetti",
                    Sex = Sex.M
                },
                new Person
                {
                    Name = "Carla",
                    Surname = "Nicoloso",
                    Sex = Sex.F
                },
                new Person
                {
                    Name = "Remo",
                    Surname = "Venturini",
                    Sex = Sex.M
                },
                new Person
                {
                    Name = "Sara",
                    Surname = "Di Poi",
                    Sex = Sex.F
                },
                new Person
                {
                    Name = "Simone",
                    Surname = "Copetti",
                    Sex = Sex.M,
                },
                new Person
                {
                    Name = "Federica",
                    Surname = "Copetti",
                    Sex = Sex.F
                },
                new Person
                {
                    Name = "Enrico",
                    Surname = "Venturini",
                    Sex = Sex.M}
            };


            List<PersonPerson> peopleRelations = new()
            {
                new PersonPerson
                {
                   Child= persons.ElementAt(4),
                   Parent= persons.ElementAt(0)
                },
                new PersonPerson
                {
                   Child= persons.ElementAt(4),
                   Parent= persons.ElementAt(1)
                },
                new PersonPerson
                {
                   Child= persons.ElementAt(5),
                   Parent= persons.ElementAt(0)
                },
                new PersonPerson
                {
                   Child= persons.ElementAt(5),
                   Parent= persons.ElementAt(1)
                },
                new PersonPerson
                {
                   Child= persons.ElementAt(6),
                   Parent= persons.ElementAt(2)
                },
                new PersonPerson
                {
                   Child= persons.ElementAt(6),
                   Parent= persons.ElementAt(3)
                }
            };

            _context.People.AddRange(persons);
            _context.PeoplePeople.AddRange(peopleRelations);

            _context.SaveChanges();


        }
    }
}
