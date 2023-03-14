using System.ComponentModel.DataAnnotations;

namespace PacientesRegister.Models.ViewModels
{
    public class TipoSangreViewModel
    {
        [Required]
        public string TipoSangre { get; set; } 
    }
}
