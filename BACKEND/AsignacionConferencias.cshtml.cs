using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FinalProyect.Models;
using FinalProyect.Services;

namespace FinalProyect.Pages
{
    public class AsignacionConferenciasModel : PageModel
    {
        private readonly IConferenciaService _conferenciaService;
        private readonly IParticipanteService _participanteService;
        private readonly IAsistenciaService _asistenciaService;

        public AsignacionConferenciasModel(IConferenciaService conferenciaService, IParticipanteService participanteService, IAsistenciaService asistenciaService)
        {
            _conferenciaService = conferenciaService;
            _participanteService = participanteService;
            _asistenciaService = asistenciaService;
        }

        [BindProperty]
        public int ConferenciaId { get; set; }

        [BindProperty]
        public string NombreConferencia { get; set; }

        [BindProperty]
        public int NuevoParticipanteId { get; set; }

        [BindProperty]
        public bool ConfirmacionAsistencia { get; set; }

        public List<Participante> Participantes { get; set; }

        public IActionResult OnGet(int conferenciaId)
        {
            ConferenciaId = conferenciaId;
            Participantes = _participanteService.ObtenerTodos() ?? new List<Participante>();
            NombreConferencia = _conferenciaService.ObtenerNombreConferencia(conferenciaId) ?? "Nombre no encontrado";

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _asistenciaService.RegistrarAsistencia(ConferenciaId, NuevoParticipanteId, ConfirmacionAsistencia);
                Console.WriteLine("Asistencia registrada correctamente.");

                return RedirectToPage("/UsuariosEnConferencia", new { conferenciaId = ConferenciaId });
            }

            Participantes = _participanteService.ObtenerTodos() ?? new List<Participante>();
            Console.WriteLine("Error de validación. Permaneciendo en la misma página.");

            return Page();
        }
    }
}
