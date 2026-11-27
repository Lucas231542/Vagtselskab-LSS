using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using VagtLib;
using static VagtLib.IVagtRapportRepo;

namespace Razor.Vagtselskab.Pages
{
    public class VagtRapport_skrModel : PageModel
    {
        private readonly IVagtRapportRepo _vagtRapportRepo;
        private readonly ITildeleVagtRepo _tildeleVagtRepo;

        public List<VagtRapport> VagtRapporter { get; set; } = new();

        public VagtRapport_skrModel(IVagtRapportRepo vagtRapportRepo, ITildeleVagtRepo tildeleVagtRepo)
        {
            _vagtRapportRepo = vagtRapportRepo;
            _tildeleVagtRepo = tildeleVagtRepo;
        }

        [BindProperty]
        [Required(ErrorMessage = "Rapport er påkrævet. Mindst 40 tegn")]
        public VagtRapport VagtRapport { get; set; }

    
        public List<Vagt> Vagter { get; set; } = new();
        public IActionResult OnGet()
        {
            int? brugerId = HttpContext.Session.GetInt32("BrugerId");
            if (brugerId == null)
            {
                // Redirect to login page or handle the case when BrugerId is not found in session
                return RedirectToPage("/Login");
                
            }
            Vagter = _tildeleVagtRepo.HentMineVagter((int)brugerId);
            return Page();
        }

        public IActionResult OnPostSkrivRapport(int vagtId)
        {
        int brugerId = HttpContext.Session.GetInt32("BrugerId").Value;

            VagtRapport.BrugerId = brugerId;
            VagtRapport.VagtId = vagtId;

            _vagtRapportRepo.CreateVagtRapport(VagtRapport);

            return Page();
        }
    }

}
