namespace IluminaRJApi.Data.Dtos
{
    public class ReadEmpresaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Contato { get; set; }
        public DateTime HoraDaConsulta { get; } = DateTime.Now;
    }
}
