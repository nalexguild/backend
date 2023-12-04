using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using FinalProyect.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalProyect.Pages
{
    public class ConferenciasModel : PageModel
    {
        private readonly IConferenciaService _conferenciaService;

        public ConferenciasModel(IConferenciaService conferenciaService)
        {
            _conferenciaService = conferenciaService;
        }

        public List<Conferencia> Conferencias { get; set; }

        public IActionResult OnGet()
        {
            Conferencias = _conferenciaService.ObtenerTodas() ?? new List<Conferencia>();
            return Page();
        }
    }
}
