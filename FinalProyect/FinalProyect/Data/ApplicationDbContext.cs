// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Conferencia> Conferencias { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }


}