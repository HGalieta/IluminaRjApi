﻿using IluminaRJApi.Models;
using Microsoft.EntityFrameworkCore;

namespace IluminaRJApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts)
            : base(opts) { }

        public DbSet<Municipio> Municipios { get; set; }
    }
}