using FamilyTree.Data;
using FamilyTree.Enums;
using FamilyTree.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectFamilyTree
{
    public static class Utilities
    {
        public static void InitializeDbForTests(AppDbContext db)
        {
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

            db.People.AddRange(persons);
            db.PeoplePeople.AddRange(peopleRelations);

            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(AppDbContext db)
        {
            db.Weddings.RemoveRange(db.Weddings);
            db.PeoplePeople.RemoveRange(db.PeoplePeople);
            db.People.RemoveRange(db.People); 
            InitializeDbForTests(db);
        }

    }
}
