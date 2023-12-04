using System.Collections.Generic;
using FinalProyect.Models;

namespace FinalProyect.Services
{
    public interface IConferenciaService
    {
        List<Conferencia> ObtenerTodas();
        Conferencia ObtenerPorId(int conferenciaId);

        string ObtenerNombreConferencia(int conferenciaId);
    }
}
