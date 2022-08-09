using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Showings.Settings
{
    public class DisplayPartSettingsViewModel
    {
        public string MySetting { get; set; }

        [BindNever]
        public DisplayPartSettings DisplayPartSettings { get; set; }
    }
}
