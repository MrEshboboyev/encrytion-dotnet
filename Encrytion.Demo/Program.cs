using System.Security.Cryptography;

var plainText = await File.ReadAllTextAsync("C:\\MrEshboboyev\\Encrytion.Demo\\Encrytion.Demo\\plainText.txt");

var masterKey = RandomNumberGenerator.GetBytes(32);

var encrypted = Encrypt(plainText, masterKey);

Console.WriteLine(encrypted);
Console.WriteLine();

var decrypted = Decrypt(encrypted, masterKey);
Console.WriteLine(decrypted);

Console.WriteLine(plainText == decrypted);

const int iVSize = 16;

static string Encrypt(string plainText, byte[] masterKey)
{
    try
    {
        using var aes = Aes.Create();
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;
        aes.Key = masterKey;
        aes.IV = RandomNumberGenerator.GetBytes(iVSize);

        using var ms = new MemoryStream();
        ms.Write(aes.IV, 0, iVSize);

        using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
        {
            using var sw = new StreamWriter(cs);
            sw.Write(plainText);
        }

        return Convert.ToBase64String(ms.ToArray());
    }
    catch (CryptographicException ex)
    {
        throw new InvalidOperationException("Encryption failed", ex);
    }
}

static string Decrypt(string encryptedText, byte[] masterKey)
{
    try
    {
        byte[] cipherData = Convert.FromBase64String(encryptedText);

        if (cipherData.Length < iVSize)
            throw new ArgumentException("Cipher data is too short to contain IV.");

        byte[] iv = new byte[iVSize];
        byte[] encryptedData = new byte[cipherData.Length - iVSize];

        Buffer.BlockCopy(cipherData, 0, iv, 0, iVSize);
        Buffer.BlockCopy(cipherData, iVSize, encryptedData, 0, encryptedData.Length);

        using var aes = Aes.Create();
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;
        aes.Key = masterKey;
        aes.IV = iv;

        using var ms = new MemoryStream(encryptedData);
        using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
        using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
        {
            using var sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }
    }
    catch (CryptographicException ex)
    {
        throw new InvalidOperationException("Decryption failed", ex);
    }
} 
