using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Parsec.Extensions;

/// <summary>
/// Custom resolver for the Newtonsoft.Json library. It allows to filter undesired property names
/// and forces json property names to follow the camelCase naming convention.
/// </summary>
public class PropertyFilterCamelCaseResolver : CamelCasePropertyNamesContractResolver
{
    private IEnumerable<string> _ignoredProps { get; }

    public PropertyFilterCamelCaseResolver(IEnumerable<string> ignoredProps = null)
    {
        if (ignoredProps == null)
        {
            _ignoredProps = new List<string>();
        }
        else
        {
            _ignoredProps = ignoredProps.Select(prop => prop.ToCamelCase());
        }
    }

    protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
    {
        var allProps = base.CreateProperties(type, memberSerialization);

        if (!_ignoredProps.Any())
            return allProps;

        return allProps.Where(p => !_ignoredProps.Contains(p.PropertyName)).ToList();
    }
}
