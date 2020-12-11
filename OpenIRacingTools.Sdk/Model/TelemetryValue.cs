using OpenIRacingTools.Sdk.Model;
using OpenIRacingTools.Sdk.Native;
using System;

namespace OpenIRacingTools.Sdk.Model
{
    public abstract class TelemetryValue
    {
        protected TelemetryValue(iRacingSDK sdk, string name)
        {
            if (sdk == null)
            {
                throw new ArgumentNullException("sdk");
            }

            Exists = sdk.VarHeaders.ContainsKey(name);
            if (Exists)
            {
                var header = sdk.VarHeaders[name];
                Name = name;
                Description = header.Desc;
                Unit = header.Unit;
                Type = header.Type;
            }
        }

        /// <summary>
        /// Whether or not a telemetry value with this name exists on the current car.
        /// </summary>
        public bool Exists { get; }

        /// <summary>
        /// The name of this telemetry value parameter.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The description of this parameter.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// The real world unit for this parameter.
        /// </summary>
        public string Unit { get; }

        /// <summary>
        /// The data-type for this parameter.
        /// </summary>
        public CVarHeader.VarType Type { get; }

        public abstract object GetValue();
    }

    /// <summary>
    /// Represents a telemetry parameter of the specified type.
    /// </summary>
    /// <typeparam name="T">The .NET type of this parameter (int, char, float, double, bool, or arrays)</typeparam>
    public sealed class TelemetryValue<T> : TelemetryValue
    {
        public TelemetryValue(iRacingSDK sdk, string name)
            : base(sdk, name)
        {
            GetData(sdk);
        }

        private void GetData(iRacingSDK sdk)
        {
            try
            {
                var data = sdk.GetData(Name);

                var type = typeof(T);
                if (type.BaseType != null && type.BaseType.IsGenericType/* && type.BaseType.GetGenericTypeDefinition() == typeof(BitfieldBase<>)*/)
                {
                    Value = (T)Activator.CreateInstance(type, new[] { data });
                }
                else
                {
                    Value = (T)data;
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// The value of this parameter.
        /// </summary>
        public T Value { get; private set; }

        public override object GetValue()
        {
            return Value;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Value, Unit);
        }
    }
}
