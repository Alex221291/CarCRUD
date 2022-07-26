﻿using System.ComponentModel.DataAnnotations;

namespace CarCRUD.Models
{
    public class Cars
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите имя!!!")]
        public string? Name { get; set; }
        public string? Model { get; set; }
        public string? Color { get; set; }
        public string? Type { get; set; }
    }
}
