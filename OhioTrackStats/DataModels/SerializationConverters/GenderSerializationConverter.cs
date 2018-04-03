using System;
using Newtonsoft.Json;
using OhioTrackStats.Constants;

namespace OhioTrackStats.DataModels.SerializationConverters
{
    public class GenderSerializationConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var gender = value as Gender;
            writer.WriteValue(gender?.ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
        }

        public override bool CanRead => false;

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Gender);
        }
    }
}