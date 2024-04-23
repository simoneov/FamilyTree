namespace FamilyTree.Models
{
    public class Wedding
    {
        public DateTime WeddingDate { get; set; }
        public DateTime? Divorce { get; set; }
        public int Id { get; set; }
        public Person? Husband { get; set; }
        public int? HusbandId { get; set; }
        public Person? Wife { get; set; }
        public int? WifeId { get; set; }
    }
}
