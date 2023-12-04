using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FinalProyect.Models;
using FinalProyect.Services;

namespace FinalProyect.Pages
{
    public class EditarParticipanteModel : PageModel
    {
        private readonly IParticipanteService _participanteService;

        [BindProperty]
        public Participante Participante { get; set; }

        public EditarParticipanteModel(IParticipanteService participanteService)
        {
            _participanteService = participanteService;
        }

        public IActionResult OnGet(int id)
        {
            Participante = _participanteService.ObtenerPorId(id);

            if (Participante == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _participanteService.Actualizar(Participante);
                return RedirectToPage("/ListadoParticipantes");
            }

            
            return Page();
        }
    }
}
