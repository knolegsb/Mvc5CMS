﻿//using System.Web.ModelBinding;

using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Mvc5CMS.Models
{
    public class PostModelBinder : DefaultModelBinder
    {
        protected override object GetPropertyValue(ControllerContext controllerContext,
            ModelBindingContext bindingContext, System.ComponentModel.PropertyDescriptor propertyDescriptor,
            IModelBinder propertyBinder)
        {
            if (propertyDescriptor.Name != "Tags")
            {
                return base.GetPropertyValue(controllerContext, bindingContext, propertyDescriptor, propertyBinder);
            }

            var tags = bindingContext.ValueProvider.GetValue("Tags").AttemptedValue;

            if (string.IsNullOrWhiteSpace(tags))
            {
                return new List<string>();
            }

            return tags.Split(new[] {','}).Select(t => t.Trim()).ToList();
        }
    }
}