using AutoMapper;

namespace CleanArch.Application.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg => {
                cfg.AddProfile(new ViewModelToDomainProfiles());
                cfg.AddProfile(new DomainProfileToViewModel());
            });
        }

    }
}
