using System.ComponentModel.DataAnnotations;
using WebEscuelaMVC.Validations;

namespace WebEscuelaMVC.Models
{
    public class Aula
    {
        public int Id { get; set; }

        [Required]
        [NumeroMayor100]
        public int Numero { get; set; }

        [Required]
        public string Estado { get; set; }


    }
}
