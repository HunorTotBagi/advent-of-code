using System.Security.Cryptography;
using System.Text;

namespace Src.Day04;

public class SolutionP1
{
    public static int Find(string key, bool fiveZeroes)
    {
        using var md5 = MD5.Create();
        var keyBytes = Encoding.ASCII.GetBytes(key);

        for (var i = 1; ; i++)
        {
            var num = i.ToString();
            var bytes = new byte[keyBytes.Length + num.Length];
            Buffer.BlockCopy(keyBytes, 0, bytes, 0, keyBytes.Length);
            Encoding.ASCII.GetBytes(num, 0, num.Length, bytes, keyBytes.Length);

            var hash = md5.ComputeHash(bytes);

            var ok = hash[0] == 0 && hash[1] == 0 && (fiveZeroes ? (hash[2] & 0xF0) == 0 : hash[2] == 0);

            if (ok) return i;
        }
    }
}
