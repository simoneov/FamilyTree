using FamilyTree.Data;
using FamilyTree.Dto;
using FamilyTree.Enums;
using FamilyTree.Exceptions;
using FamilyTree.Migrations;
using FamilyTree.Models;
using FamilyTree.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FamilyTree.Repositories.Implementations
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _db;
        public PersonRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Person> showFather(int id)
        {
            return await Task.Run(() => {
                return (Person)_db.People.Where(x =>x.Parents != null).Select(a => new
                {
                    PersonId = a.Id,
                    Father = a.Parents!.Select(b => b.Parent).SingleOrDefault(c => c.Sex == Sex.M)
                }).SingleOrDefault(d => d.PersonId == id).Father ?? new Person();
            });

            
        }

        public async Task<Person> showMother(int id)
        {

            return await Task.Run(() => {
                return (Person)_db.People.Where(x => x.Parents != null).Select(a => new
                {
                    PersonId = a.Id,
                    Mother = a.Parents!.Select(b => b.Parent).SingleOrDefault(c => c.Sex == Sex.F)
                }).SingleOrDefault(d => d.PersonId == id).Mother ?? new Person();
            } );
        }

        public async Task<List<Person>> showSiblings(int id)
        {

            return await Task.Run(() => {
                return (List<Person>)_db.People.Where(p => p.Parents != null).Select
            (a => new
            {
                PersonId = a.Id,
                Siblings = a.Parents!.First().Parent.Children!.Where(b => b.Child.Id != id).Select(c => c.Child)
            }
            ).FirstOrDefault(a => a.PersonId == id).Siblings ?? new List<Person>();
            });
        }

        public async Task<dynamic> getAll()
        {
            var people = await _db.People.Select(a => 
            new
            {
                Person = a.Id,
                Parents = a.Parents.Select(b =>b.Parent),
                Children = a.Children.Select(b => b.Child)
            }).ToListAsync();

            return people == null ? new List<Person>() : people;
        }

        public async Task deletePerson(int id)
        {
            await Task.Run(() => 
            {
                if (_db.People.FirstOrDefault(a => a.Id == id) != null) 
                {
                    _db.PeoplePeople.RemoveRange(_db.PeoplePeople.Where(a => a.ChildId == id || a.ParentId == id));
                    _db.People.Remove(_db.People.FirstOrDefault(a => a.Id == id));
                }
                
            });
            
            await _db.SaveChangesAsync();
        }

        public async Task setWedding(WeddingDivorceDto wedding)
        {
            if (wedding.WeddingDivorceDate == null || wedding.HusbandId == null || wedding.WifeId == null || wedding.WeddingDivorceDate >= DateTime.Now || _db.People.FirstOrDefault(b => b.Id == wedding.WifeId)==null || _db.People.FirstOrDefault(b => b.Id == wedding.HusbandId) == null)
                throw new InvalidWeddingException("Invalid wedding data");
            
            if (_db.Weddings.FirstOrDefault(b => b.WifeId == wedding.WifeId && b.HusbandId == wedding.HusbandId) != null && _db.Weddings.FirstOrDefault(b => b.WifeId == wedding.WifeId && b.HusbandId == wedding.HusbandId).Divorce == null)
                throw new SecondWeddingWithoutDivorceWithSameWifeException("This man is already married with this girl");
            
            _db.Weddings.Add(new Models.Wedding
            { 
                WifeId = wedding.WifeId,
                HusbandId = wedding.HusbandId,
                WeddingDate= wedding.WeddingDivorceDate
            });
            await _db.SaveChangesAsync();

        }
        
        public async Task divorce(WeddingDivorceDto? divorce)
        {

            Models.Wedding? marriageToEnd = await Task.Run(() => (Models.Wedding?)_db.Weddings.FirstOrDefault(b => b.WifeId == divorce.WifeId && b.HusbandId == divorce.HusbandId && b.Divorce == null));
            marriageToEnd.Divorce = divorce?.WeddingDivorceDate;

            await _db.SaveChangesAsync();
        }
    }
}
