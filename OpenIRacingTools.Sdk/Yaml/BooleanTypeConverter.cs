using System;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace OpenIRacingTools.Sdk.Yaml
{
    internal class BooleanTypeConverter : IYamlTypeConverter
    {
        public bool Accepts(Type type)
        {
            return type == typeof(bool);
        }

        public object ReadYaml(IParser parser, Type type)
        {
            var value = parser.Consume<Scalar>().Value;

            return value == "1"
                || value.Equals("true", StringComparison.InvariantCultureIgnoreCase)
                || value.Equals("on", StringComparison.InvariantCultureIgnoreCase);
        }

        public void WriteYaml(IEmitter emitter, object value, Type type)
        {
            throw new NotImplementedException();
        }
    }
}
