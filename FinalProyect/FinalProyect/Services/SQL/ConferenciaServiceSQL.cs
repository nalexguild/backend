using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using FinalProyect.Models;

namespace FinalProyect.Services
{
    public class ConferenciaServiceSQL : IConferenciaService
    {
        private readonly ApplicationDbContext dbContext;

        public ConferenciaServiceSQL(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Conferencia> ObtenerTodas()
        {
            return dbContext.Conferencias.AsNoTracking().ToList();
        }

        public Conferencia ObtenerPorId(int conferenciaId)
        {
            return dbContext.Conferencias.FirstOrDefault(c => c.Id == conferenciaId);
        }

        public string ObtenerNombreConferencia(int conferenciaId)
        {
            var conferencia = dbContext.Conferencias.FirstOrDefault(c => c.Id == conferenciaId);
            return conferencia != null ? conferencia.Titulo : null;
        }
    }
}
