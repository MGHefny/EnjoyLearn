using AutoMapper;
using learnApp.Data;
using learnApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace learnApp
{
    public  static class AutoMapperConfig
    {
        public static IMapper Mapper { get; private set; }

        public static void Init()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<category, categoryModel>()
                    .ForMember(dst => dst.Id, src => src.MapFrom(e => e.id))
                    .ForMember(dst => dst.name, src => src.MapFrom(e => e.category_name))
                    .ForMember(dst => dst.ParentId, src => src.MapFrom(e => e.category2.parent_id))
                    .ForMember(dst => dst.ParentName, src => src.MapFrom(e => e.category2.category_name))
                .ReverseMap();

                cfg.CreateMap<instractor, TrainerModel>().ReverseMap();

                /*cfg.CreateMap<course_t, courseModel>()
                .ForMember(dst => dst.trainerName, src => src.MapFrom(e => e.instractor.instractor_name))
                .ForMember(dst => dst.category_Name, src => src.MapFrom(e => e.category.category_name))
                .ReverseMap();*/

            });

            Mapper = config.CreateMapper();
        }
    }
}