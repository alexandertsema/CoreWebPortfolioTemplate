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
                ViewModels.ViewModels.Course>();
            CreateMap
                <ViewModels.ViewModels.Course,
                Storage.Entities.Entities.Course>();

            CreateMap
               <Storage.Entities.Entities.PortfolioItem,
               ViewModels.ViewModels.PortfolioItem>();
            CreateMap
                <ViewModels.ViewModels.PortfolioItem,
                Storage.Entities.Entities.PortfolioItem>();

            CreateMap
               <Storage.Entities.Entities.PortfolioItemCategory,
               ViewModels.ViewModels.PortfolioItemCategory>();
            CreateMap
                <ViewModels.ViewModels.PortfolioItemCategory,
                Storage.Entities.Entities.PortfolioItemCategory>();

            CreateMap
               <Storage.Entities.Entities.Reference,
               ViewModels.ViewModels.Reference>();
            CreateMap
                <ViewModels.ViewModels.Reference,
                Storage.Entities.Entities.Reference>();

            CreateMap
               <Storage.Entities.Entities.ReferenceAuthor,
               ViewModels.ViewModels.ReferenceAuthor>();
            CreateMap
                <ViewModels.ViewModels.ReferenceAuthor,
                Storage.Entities.Entities.ReferenceAuthor>();

            CreateMap
               <Storage.Entities.Entities.Resume,
               ViewModels.ViewModels.Resume>();
            CreateMap
                <ViewModels.ViewModels.Resume,
                Storage.Entities.Entities.Resume>();

            CreateMap
              <Storage.Entities.Entities.School,
              ViewModels.ViewModels.School>();
            CreateMap
                <ViewModels.ViewModels.School,
                Storage.Entities.Entities.School>();

            CreateMap
              <Storage.Entities.Entities.Skill,
              ViewModels.ViewModels.Skill>();
            CreateMap
                <ViewModels.ViewModels.Skill,
                Storage.Entities.Entities.Skill>();

            CreateMap
              <Storage.Entities.Entities.SkillCategory,
              ViewModels.ViewModels.SkillCategory>();
            CreateMap
                <ViewModels.ViewModels.SkillCategory,
                Storage.Entities.Entities.SkillCategory>();

            CreateMap
              <Storage.Entities.Entities.Summary,
              ViewModels.ViewModels.Summary>();
            CreateMap
                <ViewModels.ViewModels.Summary,
                Storage.Entities.Entities.Summary>();
        }
    }
}