using AutoMapper;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.AutoMapper
{
    public class DomainProfileToViewModel : Profile
    {
        public DomainProfileToViewModel()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }
}
