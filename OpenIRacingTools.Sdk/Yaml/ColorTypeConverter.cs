using System;
using System.Drawing;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace OpenIRacingTools.Sdk.Yaml
{
    internal class ColorTypeConverter : IYamlTypeConverter
    {
        public bool Accepts(Type type)
        {
            return type == typeof(Color) || type == typeof(Color?);
        }

        public object ReadYaml(IParser parser, Type type)
        {
            var value = parser.Consume<Scalar>().Value;

            if (value == "0xundefined" && type == typeof(Color?))
            {
                return type == typeof(Color?) ? null : Color.Empty;
            }

            return ColorTranslator.FromHtml(value);
        }

        public void WriteYaml(IEmitter emitter, object value, Type type)
        {
            throw new NotImplementedException();
        }
    }
}
