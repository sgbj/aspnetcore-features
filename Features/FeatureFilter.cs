using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Reflection;

namespace Features
{
    public class FeatureFilter : IActionFilter
    {
        private readonly IFeatureService _service;

        public FeatureFilter(IFeatureService service)
        {
            _service = service;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionDescriptor is ControllerActionDescriptor descriptor)
            {
                var features = descriptor.ControllerTypeInfo.GetCustomAttributes<FeatureAttribute>(inherit: true)
                    .Concat(descriptor.MethodInfo.GetCustomAttributes<FeatureAttribute>(inherit: true));
                if (!features.All(feature => _service.IsEnabled(feature.Name)))
                {
                    context.Result = new NotFoundResult();
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
