using System.Collections.Generic;

namespace APIAssessment.DTOs
{
    public class FruitsDto
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Genus { get; set; }
        public string Order { get; set; }
        public List<NutritionsDto> Nutritions { get; set; }
    }
}
