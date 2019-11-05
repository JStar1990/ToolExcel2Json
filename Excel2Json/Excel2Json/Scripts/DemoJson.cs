using System;
using Newtonsoft.Json;

namespace Excel2Json.Scripts
{
    public class DemoJson : JsonConverter
    {
        private void dumpNumArray<T>(JsonWriter writer, T n)
        {

            var s = n.ToString();
            if (s.EndsWith(".0"))
                writer.WriteRawValue(s.Substring(0, s.Length - 2));
            else if (s.Contains("."))
                writer.WriteRawValue(s.TrimEnd('0').TrimEnd('.'));
            else
                writer.WriteRawValue(s);
        }

        public override void WriteJson(JsonWriter writer, object value,
           JsonSerializer serializer)
        {
            Type t = value.GetType();
            if (t == dblArrayType)
                dumpNumArray<double>(writer, (double)value);
            else if (t == decArrayType)
                dumpNumArray<decimal>(writer, (decimal)value);
            else
                throw new NotImplementedException();
        }

        private Type dblArrayType = typeof(double);
        private Type decArrayType = typeof(decimal);

        public override bool CanConvert(Type objectType)
        {
            if (objectType == dblArrayType || objectType == decArrayType)
                return true;
            return false;
        }

        public override bool CanRead
        {
            get { return false; }
        }

        public override object ReadJson(JsonReader reader, Type objectType,
            object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
