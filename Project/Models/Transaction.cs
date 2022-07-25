﻿namespace Project.Models
{
    public class Transaction
    {
        public string Id { get; set; }
        public string benName { get; set; }
        public DirectionEnum Direction { get; set; }
        public string TransactionDate { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public TransactionKindEnum TransactionKind { get; set; }
        public string Kind { get; set; }
        public MCCEnum Mcc { get; set; }
        public Category Category { get; set; }
    }
}
