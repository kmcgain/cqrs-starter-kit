using System;
using Newtonsoft.Json;

namespace Edument.CQRS
{
    public static class BytesToString
    {
        public static String ToString(byte[] data)
        {
            var bytes = data;
            var chars = new char[bytes.Length/sizeof (char)];
            Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new String(chars);
        }

        public static byte[] ToBytes(string data)
        {
            var bytes = new byte[data.Length*sizeof (char)];
            Buffer.BlockCopy(data.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}