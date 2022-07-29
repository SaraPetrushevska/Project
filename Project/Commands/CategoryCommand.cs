using System;
using System.ComponentModel.DataAnnotations;

using Project.Database.Entities;
using System.ComponentModel.DataAnnotations;

namespace Project.Commands
{
    public class CategoriesCommand
    {
        [Required]
        public string Code { get; set; }
        public string? ParentCode { get; set; }
        public string Name { get; set; }
    }
}