using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VagtLib;

namespace Razor.Vagtselskab.Pages
{
    public class RegBrugereModel : PageModel
    {
        private readonly IBrugerRepo _brugerRepo;

        public RegBrugereModel(IBrugerRepo brugerRepo)
        {
            _brugerRepo = brugerRepo;
        }

        public List<Bruger> RegBrugere { get; set; } = new();

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("ErLoggetInd") != "true")
            {
                return RedirectToPage("/LogIn");
            }

            RegBrugere = _brugerRepo.GetAll();
            return Page();
        }

        public IActionResult OnPostLogUd()
        {
            HttpContext.Session.Clear();

            Response.Cookies.Delete("BrugerNavn"); // sletter HuskMig cookie

            return RedirectToPage("/LogIn");
        }
    }
}

