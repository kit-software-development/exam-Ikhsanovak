using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using Net.Library.message;

namespace Net.Library.util
{
    public static class Extensions
    {
        public static byte[] ToBytes(this Message message)
        {
            using (var memory = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(memory, message);
                memory.Flush();
                return memory.ToArray();
            }
        }

        public static T FromBytes<T>(byte[] data) where T : Message
        {
            using (var memory = new MemoryStream(data))
            {
                var formatter = new BinaryFormatter();
                return (T)formatter.Deserialize(memory);
            }
        }

        private static void Write(this Stream stream, Message message)
        {
            var bytes = message.ToBytes();
            stream.Write(bytes, 0, bytes.Length);
            stream.Flush();
        }

        public static T Read<T>(this NetworkStream stream) where T : Message
        {
            var formatter = new BinaryFormatter();
            return (T)formatter.Deserialize(stream);
        }

        public static void Send(this TcpClient client, Message message)
        {
            client.GetStream().Write(message);
        }

        public static T Receive<T>(this TcpClient client) where T : Message
        {
            return client.GetStream().Read<T>();
        }
    }
}
