using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GraphApi.Core.Helpers
{
    public class SerializationHelper
    {
        private readonly JsonSerializer _serializer;

        public SerializationHelper(JsonSerializer serializer)
        {
            _serializer = serializer;
        }

        public T Deserialize<T>(string json)
        {
            return _serializer.Deserialize<T>(new JsonTextReader(new StringReader(json)));
        }

        public string Serialize<T>(T objToSerialize)
        {
            var sb = new StringBuilder();
            _serializer.Serialize(new JsonTextWriter(new StringWriter(sb)), objToSerialize, typeof(T));
            return sb.ToString();
        }
    }
}
