using Microsoft.AspNetCore.Mvc.Rendering;
using tp2JordanCoutureLafranchise.Models;
using tp3JordanCoutureLafranchise.Models;

namespace tp2JordanCoutureLafranchise.ViewModels
{
    public class EnfantVM
    {
        public virtual Enfant Enfant { get; set; }

        public IEnumerable<SelectListItem>? ParentSelectList { get; set; }

        public List<int>? SelectedEntraineurIds { get; set; }
        public IEnumerable<SelectListItem>? AvailableEntraineurs { get; set; }
    }
}
