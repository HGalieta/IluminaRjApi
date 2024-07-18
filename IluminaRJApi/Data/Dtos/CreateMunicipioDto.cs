using System.ComponentModel.DataAnnotations;

namespace IluminaRJApi.Data.Dtos
{
    public class CreateMunicipioDto
    {
        [Required(ErrorMessage = "O nome do município deve ser informado.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O total de pontos de luz do município deve ser informado.")]
        public int TotalPontos { get; set; }
        [Required(ErrorMessage = "O total de pontos de luz com lâmpadas de LED do município deve ser informado.")]
        public int PontosLed { get; set; }
        [Required(ErrorMessage = "O status de arrecadação de CIP/COSIP pelo município deve ser informado como sim ou não.")]
        public Boolean ArrecadaCip { get; set; }
        [Required(ErrorMessage = "O gasto total, em R$, do município com iluminação pública deve ser informado.")]
        public float GastoIp { get; set; }
    }
}
