using FamilyTree.Enums;

namespace FamilyTree.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Sex Sex { get; set; }
        public virtual ICollection<PersonPerson>? Children { get; set; }
        public virtual ICollection<PersonPerson>? Parents { get; set; }
        public virtual ICollection<Wedding>? Wives { get; set; }
        public virtual ICollection<Wedding>? Husbands { get; set; }

    }
}
