using System.ComponentModel.DataAnnotations;

namespace IluminaRJApi.Data.Dtos
{
    public class CreateEmpresaDto
    {
        [Required(ErrorMessage = "O nome da empresa deve ser informado.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O tipo da empresa deve ser informado.")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "O contato da empresa deve ser informado.")]
        public string Contato { get; set; }
        [Required(ErrorMessage = "O CNPJ da empresa deve ser informado.")]
        public string CNPJ { get; set; }
        [Required(ErrorMessage = "O estado da empresa deve ser informado.")]
        public string Estado { get; set; }
    }
}
