namespace Project.Models

{
    public class Category
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string ParentCode { get; set; }
    }
}

//select code  count id transaction
//from category, transaction
//where category.code = transactio.category 
//group by category.code
