using System;

namespace CenedQualificando.Web.Admin.Shared
{
    public class StateContainer
    {
        private string tituloPagina { get; set; }
        public string TituloPagina 
        { 
            get => tituloPagina;
            set
            {
                tituloPagina = value;
                NotifyStateChanged();
            } 
        }

        public event Action OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
