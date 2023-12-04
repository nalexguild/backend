// Services/IAsistenciaService.cs
public interface IAsistenciaService
{
    void RegistrarAsistencia(int conferenciaId, int participanteId, bool confirmacionAsistencia);

    List<Participante> ObtenerAsistentesPorConferenciaId(int conferenciaId);
}
