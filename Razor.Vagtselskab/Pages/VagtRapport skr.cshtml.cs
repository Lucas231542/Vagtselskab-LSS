using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using VagtLib;
using System.Text.Json;

namespace Razor.Vagtselskab.Pages
{
    public class VagtRapport_skrModel : PageModel
    {
        private readonly IVagtRapportRepo _vagtRapportRepo;

        public List<VagtRapport> VagtRapporter { get; set; } = new();

        public VagtRapport_skrModel(IVagtRapportRepo vagtRapportRepo)
        {
            _vagtRapportRepo = vagtRapportRepo;
        }

        [BindProperty]
        [Required(ErrorMessage = "Rapport er påkrævet. Mindst 40 tegn")]
        public VagtRapport VagtRapport { get; set; }

        int? brugerId = HttpContext.Session.GetInt32("BrugerId");


        public void OnGet()
        {
        }
    }
}
