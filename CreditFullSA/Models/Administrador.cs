using System.ComponentModel.DataAnnotations;

namespace CreditFullSA.Models
{
    public class Administrador
    {
        [Key]
        public string email { get; set; }
        
        public string Nombre { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set;}
    }
}
