using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;

namespace APIAssessment.Model
{
    public class Fruits
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        
        public int Id { get; set; }
        public string Name { get; set; }        
        public string Family { get; set; }
        public string Genus { get; set; }
        public string Order { get; set; }
        public List<Nutritions> Nutritions { get; set; }
    }
}
