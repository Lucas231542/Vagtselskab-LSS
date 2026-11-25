
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor.Vagtselskab.Repositories;
using VagtLib;

namespace Razor.Vagtselskab.Pages
{
    public class VagtModel : PageModel
    {
        private readonly VagtRepo _vagtRepo;

        public VagtModel(VagtRepo vagtRepo)
        {
            _vagtRepo = vagtRepo;
        }

        [BindProperty]
        public Vagt Vagt { get; set; }

        // Opret vagt
        public IActionResult OnPostOpret()
        {
            _vagtRepo.Add(Vagt);

            return RedirectToPage();
        }

        // Rediger vagt
        public IActionResult OnPostRediger()
        {
            var eksisterendeVagt = _vagtRepo.GetById(Vagt.VagtId);

            if (eksisterendeVagt == null)
            {
                return NotFound();
            }

            eksisterendeVagt.Medarbejder = Vagt.Medarbejder;
            eksisterendeVagt.StartTid = Vagt.StartTid;
            eksisterendeVagt.SlutTid = Vagt.SlutTid;

            _vagtRepo.Update(eksisterendeVagt);

            return RedirectToPage();
        }

        // Slet vagt
        public IActionResult OnPostSlet(int id)
        {
            var vagt = _vagtRepo.GetById(id);

            if (vagt == null)
            {
                return NotFound();
            }

            _vagtRepo.Delete(id);

            return RedirectToPage();
        }
    }
}
