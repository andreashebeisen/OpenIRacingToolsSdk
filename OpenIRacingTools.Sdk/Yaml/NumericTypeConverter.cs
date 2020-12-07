using System;
using System.Globalization;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace OpenIRacingTools.Sdk.Yaml
{
    internal class NumericTypeConverter : IYamlTypeConverter
    {
        public bool Accepts(Type type)
        {
            return type == typeof(double) || type == typeof(double?) || type == typeof(int) || type == typeof(int?);
        }

        public object ReadYaml(IParser parser, Type type)
        {
            var value = parser.Consume<Scalar>().Value;

            // Strip unit if there is one
            if (value.Contains(' '))
            {
                value = value.Substring(0, value.IndexOf(' '));
            }

            // Return -1 / null if "unlimited" is given
            if (value == "unlimited")
            {
                if (Nullable.GetUnderlyingType(type) != null)
                {
                    return null;
                }
                else
                {
                    return -1;
                }
            }

            if (type == typeof(double)) { 

                return double.Parse(value, CultureInfo.InvariantCulture);
            }
            else if (type == typeof(int))
            {
                return int.Parse(value, CultureInfo.InvariantCulture);
            }

            throw new NotSupportedException();
        }

        public void WriteYaml(IEmitter emitter, object value, Type type)
        {
            throw new NotImplementedException();
        }
    }
}
