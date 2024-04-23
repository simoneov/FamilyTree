namespace FamilyTree.Models
{
    public class PersonPerson
    {
        public Person? Child { get; set; }
        public  int? ChildId { get; set; }
        public Person? Parent { get; set; }
        public int? ParentId { get; set; }
    }
}
