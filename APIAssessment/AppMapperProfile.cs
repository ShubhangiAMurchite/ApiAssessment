using APIAssessment.DTOs;
using APIAssessment.Model;
using AutoMapper;

namespace APIAssessment
{
    public class AppMapperProfile:Profile
    {
        public AppMapperProfile()
        {
            CreateMap<FruitsDto, Fruits>();
            CreateMap<NutritionsDto, Nutritions>();
        }
    }
}
