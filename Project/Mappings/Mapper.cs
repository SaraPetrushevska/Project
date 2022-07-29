using AutoMapper;
using Project.Commands;
using Project.Database.Entities;
using Project.Models;

namespace Product.Mappings
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<TransactionEntity, Project.Models.Transaction>()
                .ForMember(d => d.Id, opts => opts.MapFrom(s => s.Id));

            CreateMap<PagedSortedList<TransactionEntity>, PagedSortedList<Project.Models.Transaction>>();

            CreateMap<TransactionCommand, TransactionEntity>()
                .ForMember(d => d.Id, opts => opts.MapFrom(s => s.Id));

            CreateMap<CategoryEntity, Project.Models.Category>()
               .ForMember(d => d.Code, opts => opts.MapFrom(s => s.Code));
            CreateMap<CategoryCommand, CategoryEntity>()
               .ForMember(d => d.Code, opts => opts.MapFrom(s => s.Code));
        }
    }
}