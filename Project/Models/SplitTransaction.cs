namespace Project.Models
{
    public class SplitTransaction
    {

        public int Id { get; set; }
        public Transaction Transaction { get; set; }
        public Category Category { get; set; }
        public int Split { get; set; }
    }
}
