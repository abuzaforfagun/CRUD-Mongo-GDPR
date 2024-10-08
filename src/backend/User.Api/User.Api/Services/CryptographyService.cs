using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Security.Cryptography;
using System.Text;
using User.Api.Configurations;

namespace User.Api.Services;

public interface ICryptographyService
{
    string Hash(string data);
    string Encrypt(string plainText);
    string Decrypt(string cipherText);
}

public class CryptographyService : ICryptographyService
{
    private readonly byte[] _key;
    private readonly byte[] _iv;
    private readonly CryptographyConfig _config;

    public CryptographyService(CryptographyConfig config)
    {
        if (string.IsNullOrWhiteSpace(config.SecretKey))
        {
            throw new Exception("Secret key is not configured");
        }

        var keys = config.SecretKey.Split(":");
        if (keys.Length != 2)
        {
            throw new Exception("Secret key is invalid");
        }

        _key = Convert.FromBase64String(keys[0]);
        _iv = Convert.FromBase64String(keys[1]);

        _config = config;

    }


    public string Hash(string data)
    {
        using SHA256 sha256Hash = SHA256.Create();
        var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(data));

        var builder = new StringBuilder();
        foreach (var b in bytes)
        {
            builder.Append(b.ToString("x2"));
        }

        return builder.ToString();
    }

    public string Encrypt(string plainText)
    {
        using var aesAlg = Aes.Create();
        aesAlg.Key = _key;
        aesAlg.IV = _iv;

        var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

        using var msEncrypt = new MemoryStream();
        using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
        using var swEncrypt = new StreamWriter(csEncrypt);
        
        swEncrypt.Write(plainText);
        
        return Convert.ToBase64String(msEncrypt.ToArray());
    }

    public string Decrypt(string cipherText)
    {
        using var aesAlg = Aes.Create();
        aesAlg.Key = _key;
        aesAlg.IV = _iv;

        var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

        using var msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText));
        using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
        using var srDecrypt = new StreamReader(csDecrypt);

        return srDecrypt.ReadToEnd();
    }
}