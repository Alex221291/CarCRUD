using System.ComponentModel.DataAnnotations;

namespace CarCRUD.Models
{
    public class Motos
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите имя!!!")]
        public string? Name { get; set; }
        
        public int DataBuild { get; set; }
        [Required(ErrorMessage = "Введите модель!!!")]
        public string? Model { get; set; }
    }
}
