using Microsoft.EntityFrameworkCore;
using System.Linq;

public class AsistenciaServiceSQL : IAsistenciaService
{
    private readonly ApplicationDbContext _dbContext;

    public AsistenciaServiceSQL(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void RegistrarAsistencia(int conferenciaId, int participanteId, bool confirmacionAsistencia)
    {
        var asistenciaExistente = _dbContext.Asistencias
            .FirstOrDefault(a => a.ConferenciaId == conferenciaId && a.ParticipanteId == participanteId);

        if (asistenciaExistente != null)
        {
            asistenciaExistente.ConfirmacionAsistencia = confirmacionAsistencia;
        }
        else
        {
            var nuevaAsistencia = new Asistencia
            {
                ConferenciaId = conferenciaId,
                ParticipanteId = participanteId,
                ConfirmacionAsistencia = confirmacionAsistencia
            };

            _dbContext.Asistencias.Add(nuevaAsistencia);
        }

        _dbContext.SaveChanges();
    }
    public List<Participante> ObtenerAsistentesPorConferenciaId(int conferenciaId)
    {
        return _dbContext.Asistencias
            .Include(a => a.Participante)
            .Where(a => a.ConferenciaId == conferenciaId && a.ConfirmacionAsistencia)
            .Select(a => a.Participante)
            .ToList();
    }
}
