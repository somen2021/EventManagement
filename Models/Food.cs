using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.Models
{
    public class Food
    {
        [Key]
        public int FoodID { get; set; }

        [Required(ErrorMessage = "FoodType Required")]
        [Display(Name = "Food Type")]
        public string FoodType { get; set; }
        public string Createdby { get; set; }
        public DateTime? Createdate { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Enter only numeric number")]
        [Required(ErrorMessage = "FoodCost Required")]
        public int? FoodCost { get; set; }

        [Display(Name = "Meal Type")]
        [Required(ErrorMessage = "MealType Required")]
        public string MealType { get; set; }

        [NotMapped]
        public string FoodTypeName { get; set; }

        [NotMapped]
        public string MealTypeName { get; set; }
    }
}
