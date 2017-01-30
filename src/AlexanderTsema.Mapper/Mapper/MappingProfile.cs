using System.Collections.Generic;
using AutoMapper;

namespace AlexanderTsema.Mapper.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
//            CreateMap<AlexanderTsema.Storage.Entities.Entities.BaseEntity, AlexanderTsema.ViewModels.ViewModels.BaseViewModel>()
//                .Include<AlexanderTsema.Storage.Entities.Entities.Certificate, AlexanderTsema.ViewModels.ViewModels.Certificate>();
            CreateMap
                <AlexanderTsema.Storage.Entities.Entities.Certificate, 
                AlexanderTsema.ViewModels.ViewModels.Certificate>();
//            CreateMap
//                <IEnumerable<AlexanderTsema.Storage.Entities.Entities.Certificate>,
//                IEnumerable<AlexanderTsema.ViewModels.ViewModels.Certificate>>();

            CreateMap<AlexanderTsema.ViewModels.ViewModels.Certificate, AlexanderTsema.Storage.Entities.Entities.Certificate>();
        }
    }
}