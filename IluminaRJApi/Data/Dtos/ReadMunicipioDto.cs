namespace IluminaRJApi.Data.Dtos
{
    public class ReadMunicipioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int TotalPontos { get; set; }
        public int PontosLed { get; set; }
        public Boolean ArrecadaCip { get; set; }
        public float GastoIp { get; set; }
        public Boolean ChamamentoAberto { get; set; }
        public DateTime HoraDaConsulta { get; } = DateTime.Now;
    }
}
