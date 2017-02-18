using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Features
{
    [HtmlTargetElement(Attributes = nameof(Feature))]
    public class FeatureTagHelper : TagHelper
    {
        private readonly IFeatureService _service;

        public FeatureTagHelper(IFeatureService service)
        {
            _service = service;
        }

        public string Feature { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!_service.IsEnabled(Feature))
            {
                output.SuppressOutput();
            }
        }
    }
}
