using Microsoft.AspNetCore.Mvc.Rendering;
using tp2JordanCoutureLafranchise.Models;

namespace tp2JordanCoutureLafranchise.ViewModels
{
    public class EnfantVM
    {
        public virtual Enfant Enfant { get; set; }

        public IEnumerable<SelectListItem>? ParentSelectList { get; set; }
    }
}
