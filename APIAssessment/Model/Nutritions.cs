using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIAssessment.Model
{
    public class Nutritions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int Id { get; set; }
        public float Carbohydrates { get; set; }
        public float Protein { get; set; }
        public float Fat { get; set; }
        public float Calories { get; set; }
        public float Sugar { get; set; }
        //Adding Foreign Key Constraints for Fruits               
        [JsonIgnore]
        public int FruitsId { get; set; } 
        [JsonIgnore]
        public Fruits Fruits { get; set; }
    }
}
