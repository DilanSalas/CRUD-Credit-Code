using System.ComponentModel.DataAnnotations;

namespace CreditFullSA.Models
{
    public class Credito

    {

        [Key]
        public int numeroSolicitud { get; set; }

        [Required(ErrorMessage = "Debe ingresar su numero de cedula")]
        public int cedula { get; set; }
        [Required(ErrorMessage = "Debe ingresar su nombre completo")]
        [DataType(DataType.Text)]
        [StringLength(200)]
        public string nombreCompleto { get; set; }
        [Required(ErrorMessage = "Debe ingresar el email")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required(ErrorMessage = "Debe ingresar la direccion")]
        [DataType(DataType.Text)]
        [StringLength(200)]
        public string direccion { get; set; }
        [Required(ErrorMessage = "Debe ingresar la lineaCredito")]
        [DataType(DataType.Text)]
        [StringLength(200)]
        public string lineaCredito { get; set; }
        [Required(ErrorMessage = "Debe ingresar el monto a solicitar")]
        public decimal montoSolicitar { get; set; }
        [Required(ErrorMessage = "Debe ingresar el plazo")]
        [DataType(DataType.Text)]
        [StringLength(200)]
        public string plazo { get; set; }
        [Required(ErrorMessage = "Debe ingresar la fecha")]
        [DataType(DataType.DateTime)]
        public DateTime fecha { get; set; }
        public decimal montoInteres { get; set; }

        public char estado { get; set; }


    }
}
