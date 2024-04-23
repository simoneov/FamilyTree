using FamilyTree.Dto;
using FamilyTree.Models;

namespace FamilyTree.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person> showMother(int id);
        Task<Person> showFather(int id);
        Task<List<Person>> showSiblings(int id);
        Task<dynamic> getAll();
        Task deletePerson(int id);
        Task setWedding(WeddingDivorceDto wedding);
        Task divorce(WeddingDivorceDto divorce);
    }


}
