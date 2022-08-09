using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrchardCore.ContentManagement;
using Orders.Models;
using Orders.Settings;

namespace Orders.ViewModels
{
    public class DisplayPartViewModel
    {
        public string MySetting { get; set; }

        public bool Show { get; set; }

        [BindNever]
        public ContentItem ContentItem { get; set; }

        [BindNever]
        public DisplayPart DisplayPart { get; set; }

        [BindNever]
        public DisplayPartSettings Settings { get; set; }
    }
}
