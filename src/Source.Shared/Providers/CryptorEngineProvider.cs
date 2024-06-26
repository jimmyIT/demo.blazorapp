﻿using System.Security.Cryptography;
using System.Text;

namespace Source.Shared.Providers;

public class CryptorEngineProvider
{
    public static string Create_HashSHA1(string value)
    {
        var sha1 = SHA1.Create();
        var inputBytes = Encoding.ASCII.GetBytes(value);
        var hash = sha1.ComputeHash(inputBytes);
        var sb = new StringBuilder();
        for (var i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("X2"));
        }
        return sb.ToString();
    }
}
