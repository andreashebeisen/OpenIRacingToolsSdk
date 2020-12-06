using OpenIRacingTools.Sdk.Model.Types;
using System;
using System.Globalization;
using System.Linq;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace OpenIRacingTools.Sdk.Yaml
{
    internal class DoubleUnitTypeConverter : IYamlTypeConverter
    {
        public bool Accepts(Type type)
        {
            return new[]
            {
                typeof(Temperature),
                typeof(Measure),
                typeof(Speed),
            }.Contains(type);
        }

        public object ReadYaml(IParser parser, Type type)
        {
            var value = parser.Consume<Scalar>().Value;

            string unit = null;
            double doubleValue;

            if (value.Contains(' '))
            {
                doubleValue = double.Parse(value.Substring(0, value.IndexOf(' ')), CultureInfo.InvariantCulture);
                unit = value.Substring(value.IndexOf(' ') + 1);
            }
            else
            {
                doubleValue = double.Parse(value, CultureInfo.InvariantCulture);
            }

            if (type == typeof(Temperature))
            {
                return new Temperature(doubleValue);
            }
            else if (type == typeof(Measure))
            {
                return new Measure(doubleValue, unit);
            }
            else if (type == typeof(Speed))
            {
                return new Speed(doubleValue, unit);
            }

            throw new NotImplementedException();
        }

        public void WriteYaml(IEmitter emitter, object value, Type type)
        {
            throw new NotImplementedException();
        }
    }
}
