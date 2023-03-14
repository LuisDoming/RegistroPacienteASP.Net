using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace PacientesRegister.Models.ViewModels
{
    public class PacienteViewModel
    {
        public String Clavepaciente { get; set; }
        public String Apellidos { get; set; }
        public String NombrePac { get; set; }
        public String DireccionPac { get; set; }
        public String TelefonoCasa { get; set; }
        public String TelefonoCelular { get; set; }
        [EmailAddress]
        public String EmailPac { get; set; }
        public int SexoPac { get; set; }
        [Required]
        public int Activo { get; set; }
        [Required]
        public int TipoSangreID { get; set; }
    }
}
