﻿namespace IluminaRJApi.Data.Dtos
{
    public class ReadFundoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Contato { get; set; }
        public DateTime HoraDaConsulta { get; } = DateTime.Now;
    }
}
