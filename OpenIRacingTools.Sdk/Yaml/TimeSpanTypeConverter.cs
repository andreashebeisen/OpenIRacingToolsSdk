using System;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace OpenIRacingTools.Sdk.Yaml
{
    internal class TimeSpanTypeConverter : IYamlTypeConverter
    {
        public bool Accepts(Type type)
        {
            return type == typeof(TimeSpan);
        }

        public object ReadYaml(IParser parser, Type type)
        {
            var value = parser.Consume<Scalar>().Value;

            return TimeSpan.FromSeconds(double.Parse(value));
        }

        public void WriteYaml(IEmitter emitter, object value, Type type)
        {
            throw new NotImplementedException();
        }
    }
}
