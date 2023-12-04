using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

    namespace FinalProyect.Pages {
    public class ListadoParticipantesModel : PageModel
    {
        private readonly IParticipanteService _participanteService;

        public ListadoParticipantesModel(IParticipanteService participanteService)
        {
            _participanteService = participanteService;
        }

        public List<Participante> Participantes { get; set; }

        public IActionResult OnGet()
        {
            Participantes = _participanteService.ObtenerTodos() ?? new List<Participante>();
            return Page();
        }
    }
    }
