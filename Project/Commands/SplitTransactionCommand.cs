using Project.Models;

namespace Project.Commands
{
    public class SplitTransactionCommand
    {
        public int Id { get; set; }
        public Transaction Transaction { get; set; }
        public Category Category { get; set; }
        public int Split { get; set; }
    }
}
