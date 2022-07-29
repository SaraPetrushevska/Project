
using Project.Database.Entities;
using System.ComponentModel.DataAnnotations;

namespace Project.Commands
{
    public class TransactionCommand
    {
        [Required]
        public string Id { get; set; }
        public string? benName { get; set; }
        public string TransactionDate { get; set; }
        public DirectionEnum Direction { get; set; }
        public float Amount { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public MCCEnum Mcc { get; set; }
        public string Kind { get; set; }

    }
}
