using System.ComponentModel.DataAnnotations;

namespace IluminaRJApi.Models
{
    public class Fundo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome do fundo deve ser informado.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O CNPJ do fundo deve ser informado.")]
        public string CNPJ { get; set; }
        [Required(ErrorMessage = "O contato do fundo deve ser informado.")]
        public string Contato { get; set; }

    }
}
