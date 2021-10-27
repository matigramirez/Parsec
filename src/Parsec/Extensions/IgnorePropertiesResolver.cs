using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Parsec.Extensions
{
    public class IgnorePropertiesResolver : CamelCasePropertyNamesContractResolver
    {
        private IEnumerable<string> IgnoredProps { get; }

        public IgnorePropertiesResolver(IEnumerable<string> ignoredProps = null)
        {
            if (ignoredProps == null)
            {
                IgnoredProps = new List<string>();
            }
            else
            {
                IgnoredProps = ignoredProps.Select(prop => prop.ToCamelCase());
            }
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var allProps = base.CreateProperties(type, memberSerialization);

            if (!IgnoredProps.Any())
                return allProps;

            return allProps.Where(p => !IgnoredProps.Contains(p.PropertyName)).ToList();
        }
    }
}
