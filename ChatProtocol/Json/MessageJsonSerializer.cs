using ChatProtocol.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatProtocol.Json
{
    public class MessageJsonSerializer
    {
        public static string SerializeMessage<T>(T obj) where T: class
        {
            return JsonSerializer.Serialize<T>(obj);
        }

        public static T DeserializeMessage<T>(string message) where T : class
        {
            try
            {
                return JsonSerializer.Deserialize<T>(message);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
