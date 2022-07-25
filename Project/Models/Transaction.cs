using namespace Project.Models.Categories
namespace Project.Models
{
    public class Transaction
    {
        public string Id { get; set; }
        public string benName { get; set; }
        public DirectionEnum Direction { get; set; }
        public DateTime TransactionDate { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public TransactionKindEnum TransactionKind { get; set; }
        public string Kind { get; set; }
        public Category Category { get; set; }
    }
}
