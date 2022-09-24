namespace FastFood.Core.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Core.ViewModels.Categories;
    using FastFood.Models;
    using FastFood.Services.Models.Categories;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            //Categories
            this.CreateMap<CreateCategoryDto, Category>();
            this.CreateMap<CreateCategoryInputModel, CreateCategoryDto>()
                .ForMember(x => x.Name, y => y.MapFrom(x => x.CategoryName));
            this.CreateMap<Category, ListCategoryDto>();
            this.CreateMap<ListCategoryDto, CategoryAllViewModel>();
        }
    }
}
