using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HistoryApiSample.Models
{
    public class SelectorViewModel
    {
        [Display(Name = "select a make")]
        public string SelectedMake { get; set; }
        public IEnumerable<SelectListItem> Makes { get; set; }

        [Display(Name = "select a model")]
        public string SelectedModel { get; set; }
        public IEnumerable<SelectListItem> Models { get; set; }
    }
}