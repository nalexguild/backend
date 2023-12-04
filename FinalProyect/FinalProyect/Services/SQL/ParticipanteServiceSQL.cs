using Microsoft.EntityFrameworkCore;

namespace FinalProyect.Services
{
    public class ParticipanteServiceSQL : IParticipanteService
    {
        private readonly ApplicationDbContext dbContext;

        public ParticipanteServiceSQL(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Participante> ObtenerTodos()
        {
            return dbContext.Participantes.ToList();
        }

        public void Agregar(Participante participante) {

            dbContext.Participantes.Add(participante);
            dbContext.SaveChanges();
        }

        public Participante ObtenerPorId(int id)
        {
            return dbContext.Participantes.Find(id);
        }

        public void Actualizar(Participante participante)
        {
            var participanteExistente = dbContext.Participantes.Find(participante.Id);

            if (participanteExistente != null)
            {
                dbContext.Entry(participanteExistente).CurrentValues.SetValues(participante);
                dbContext.SaveChanges();
            }
            
        }
    }
}
