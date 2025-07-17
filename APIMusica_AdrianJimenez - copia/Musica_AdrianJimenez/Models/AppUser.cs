using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musica_AdrianJimenez.Models
{
    public partial class AppUser : IdentityUser
    {

        //Nombre, Apellido, codigoPostal
        [Required]
        [DisplayName("Nombre")]
        public string nombre { get; set; }

        [Required]
        [DisplayName("Apellidos")]
        public string? apellidos { get; set; }

        [Required]
        [DisplayName("CodigoPostal")]
        public string? codigoPostal { get; set; }

        [Required]
        [DisplayName("Roles")]
        public List<string>? roles { get; set; } 

        public string? password { get; set; }
    }
}
