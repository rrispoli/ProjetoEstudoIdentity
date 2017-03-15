using System.Collections.Generic;

namespace ProjetoEstudoIdentity.Infra.CrossCutting.Identity.Model
{
    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        //public ICollection<SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }
}