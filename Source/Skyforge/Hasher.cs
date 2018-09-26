using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SkyforgeReforge
{
    // The type of hash to create
    internal enum HashType
    {
        MD5,
        SHA1,
        SHA512
    }

    // Class used to generate hash sums of files
    internal static class Hasher
    {
        internal static string HaseFile(string filePath, HashType algorithm)
        {
            switch(algorithm)
            {
                case HashType.MD5:
                    {
                        return MakeHashString(MD5.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));
                    }
                case HashType.SHA1:
                    {
                        return MakeHashString(SHA1.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));
                    }
                case HashType.SHA512:
                    {
                        return MakeHashString(SHA512.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));
                    }
                default:
                    {
                        return "";
                    }
               
            }
        }

        // converts byte arrays to string
        private static string MakeHashString(byte[] hash)
        {
            StringBuilder s = new StringBuilder(hash.Length * 2);

            foreach (byte b in hash)
            {
                s.Append(b.ToString("X2").ToLower());
            }
            return s.ToString();
        }
    }
}
