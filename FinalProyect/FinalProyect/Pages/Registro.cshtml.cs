using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FinalProyect.Models;

namespace FinalProyect.Pages
{
    public class RegistroModel : PageModel
    {
        private readonly IParticipanteService participanteService;

        [BindProperty]
        public Participante NuevoParticipante { get; set; }

        public RegistroModel(IParticipanteService participanteService)
        {
            this.participanteService = participanteService;
        }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (!NuevoParticipante.AceptaTerminos)
                {
                    ModelState.AddModelError("NuevoParticipante.AceptaTerminos", "");
                    return Page();
                }

                participanteService.Agregar(NuevoParticipante);
                return RedirectToPage("/ListadoParticipantes");
            }

            
            return Page();
        }

    }
}
