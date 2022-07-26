using System.ComponentModel.DataAnnotations;

namespace CarCRUD.ModelView
{
    public class MotoViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите имя!!!")]
        public string? Name { get; set; }
        
        public int DataBuild { get; set; }
    }
}
