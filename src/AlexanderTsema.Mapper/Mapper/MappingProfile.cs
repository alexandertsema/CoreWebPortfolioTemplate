using System.Collections.Generic;
using AutoMapper;

namespace AlexanderTsema.Mapper.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap
                <Storage.Entities.Entities.Certificate, 
                ViewModels.ViewModels.Certificate>();
            CreateMap
                <ViewModels.ViewModels.Certificate, 
                Storage.Entities.Entities.Certificate>();

            CreateMap
                <Storage.Entities.Entities.Content,
                ViewModels.ViewModels.Content>();
            CreateMap
                <ViewModels.ViewModels.Content,
                Storage.Entities.Entities.Content>();

            CreateMap
                <Storage.Entities.Entities.Course,
                ViewModels.ViewModels.Course>().MaxDepth(2);
            CreateMap
                <ViewModels.ViewModels.Course,
                Storage.Entities.Entities.Course>().MaxDepth(2);

            CreateMap
            <Storage.Entities.Entities.PortfolioItem,
                ViewModels.ViewModels.PortfolioItem>().MaxDepth(2);
            CreateMap
                <ViewModels.ViewModels.PortfolioItem,
                Storage.Entities.Entities.PortfolioItem>().MaxDepth(2);

            CreateMap
            <Storage.Entities.Entities.PortfolioItemCategory,
                ViewModels.ViewModels.PortfolioItemCategory>().MaxDepth(2);
//                .ForMember(x => x.PortfolioItems, y => y.Ignore());
            CreateMap
                <ViewModels.ViewModels.PortfolioItemCategory,
                Storage.Entities.Entities.PortfolioItemCategory>().MaxDepth(2);

            CreateMap
               <Storage.Entities.Entities.Reference,
               ViewModels.ViewModels.Reference>().MaxDepth(2);
            CreateMap
                <ViewModels.ViewModels.Reference,
                Storage.Entities.Entities.Reference>().MaxDepth(2);

            CreateMap
               <Storage.Entities.Entities.ReferenceAuthor,
               ViewModels.ViewModels.ReferenceAuthor>().MaxDepth(2);
            CreateMap
                <ViewModels.ViewModels.ReferenceAuthor,
                Storage.Entities.Entities.ReferenceAuthor>().MaxDepth(2);

            CreateMap
               <Storage.Entities.Entities.Resume,
               ViewModels.ViewModels.Resume>();
            CreateMap
                <ViewModels.ViewModels.Resume,
                Storage.Entities.Entities.Resume>();

            CreateMap
              <Storage.Entities.Entities.School,
              ViewModels.ViewModels.School>().MaxDepth(2);
            CreateMap
                <ViewModels.ViewModels.School,
                Storage.Entities.Entities.School>().MaxDepth(2);

            CreateMap
              <Storage.Entities.Entities.Skill,
              ViewModels.ViewModels.Skill>().MaxDepth(2);
            CreateMap
                <ViewModels.ViewModels.Skill,
                Storage.Entities.Entities.Skill>().MaxDepth(2);

            CreateMap
              <Storage.Entities.Entities.SkillCategory,
              ViewModels.ViewModels.SkillCategory>().MaxDepth(2);
            CreateMap
                <ViewModels.ViewModels.SkillCategory,
                Storage.Entities.Entities.SkillCategory>().MaxDepth(2);

            CreateMap
              <Storage.Entities.Entities.Summary,
              ViewModels.ViewModels.Summary>();
            CreateMap
                <ViewModels.ViewModels.Summary,
                Storage.Entities.Entities.Summary>();
        }
    }
}