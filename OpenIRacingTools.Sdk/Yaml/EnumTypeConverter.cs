using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace OpenIRacingTools.Sdk.Yaml
{
    internal class EnumTypeConverter : IYamlTypeConverter
    {
        public bool Accepts(Type type)
        {
            return type.IsEnum;
        }

        public object ReadYaml(IParser parser, Type type)
        {
            var value = parser.Consume<Scalar>().Value;

            // First try to find property with DisplayAttribute
            var valueWithDisplayAttribute = (from x in type.GetMembers()
                                             let attribute = x.GetCustomAttribute<DisplayAttribute>()
                                             where attribute?.Name == value
                                             select x.Name).SingleOrDefault();
            if (valueWithDisplayAttribute != null)
            {
                return Enum.Parse(type, valueWithDisplayAttribute);
            }

            // Convert value to title case
            var titleCaseValue = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(value).Replace(" ", string.Empty);

            if (Enum.GetNames(type).Contains(value))
            {
                return Enum.Parse(type, value);
            }
            else if (Enum.GetNames(type).Contains(titleCaseValue))
            {
                return Enum.Parse(type, titleCaseValue);
            }
            else
            {
                Debug.WriteLine($"Could not find value '{value}' for enum '{type.Name}'.");
                return 0;
            }
        }

        public void WriteYaml(IEmitter emitter, object value, Type type)
        {
            throw new NotImplementedException();
        }
    }
}
