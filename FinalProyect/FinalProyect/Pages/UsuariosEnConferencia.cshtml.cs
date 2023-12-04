using System.Collections.Generic;
using FinalProyect.Models;
using FinalProyect.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalProyect.Pages
{
    public class UsuariosEnConferenciaModel : PageModel
    {
        private readonly IAsistenciaService _asistenciaService;

        public UsuariosEnConferenciaModel(IAsistenciaService asistenciaService)
        {
            _asistenciaService = asistenciaService;
        }

        public List<Participante> UsuariosEnConferencia { get; set; }

        public IActionResult OnGet(int conferenciaId)
        {
            
            UsuariosEnConferencia = _asistenciaService.ObtenerAsistentesPorConferenciaId(conferenciaId) ?? new List<Participante>();

            return Page();
        }
    }
}
