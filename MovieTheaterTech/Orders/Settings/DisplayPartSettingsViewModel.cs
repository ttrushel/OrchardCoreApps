using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Orders.Settings
{
    public class DisplayPartSettingsViewModel
    {
        public string MySetting { get; set; }

        [BindNever]
        public DisplayPartSettings DisplayPartSettings { get; set; }
    }
}
