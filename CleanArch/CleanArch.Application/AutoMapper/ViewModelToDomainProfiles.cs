using AutoMapper;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Commands;


namespace CleanArch.Application.AutoMapper
{
    public class ViewModelToDomainProfiles : Profile
    {
        public ViewModelToDomainProfiles()
        {
            CreateMap<ProductViewModel, CreateProductCommand>()
                .ConvertUsing(p => new CreateProductCommand(p.Id, p.Name, p.Description, p.Quantity, p.Price));
        }
    }
}
