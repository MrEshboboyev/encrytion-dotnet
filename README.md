# 🔐 AES Encryption Demo

[![.NET Version](https://img.shields.io/badge/.NET-10.0-512BD4?style=flat-square)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/github/license/MrEshboboyev/Encryption.Demo?style=flat-square)](LICENSE)

> **A secure and efficient AES encryption and decryption demo built with .NET 10, demonstrating industry-standard cryptographic practices.**

---

## 🌟 Key Highlights

- **Secure AES-256 Encryption**: Advanced encryption using AES in CBC mode with PKCS7 padding.
- **Dynamic IV Generation**: Each encryption operation generates a cryptographically secure Initialization Vector (IV).
- **Integrated IV Management**: IVs are seamlessly prepended to ciphertext for convenient and secure decryption.
- **Base64 Encoding**: Easily store and transmit encrypted data using Base64 encoding.
- **Robust Exception Handling**: Proactive error detection and handling for enhanced reliability.
- **Streamlined Data Processing**: Efficient cryptographic operations leveraging stream-based APIs.

---

## 🚀 Quick Start Guide

Here's a concise example to quickly get you started:

```csharp
// Generate a secure 256-bit key
byte[] masterKey = RandomNumberGenerator.GetBytes(32);

// Encrypt your message
string encrypted = Encrypt("Your confidential message", masterKey);
Console.WriteLine($"Encrypted: {encrypted}");

// Decrypt the message
string decrypted = Decrypt(encrypted, masterKey);
Console.WriteLine($"Decrypted: {decrypted}");
```

---

## 📦 Installation Steps

1. **Clone this repository**

```bash
git clone https://github.com/MrEshboboyev/Encryption.Demo.git
```

2. **Launch with Visual Studio**
- Open the solution in **Visual Studio 2022** or your preferred compatible IDE.
- Build and run the application.

---

## 🔑 Secure Design Principles

- **AES-256 Encryption**: Optimal security with a 256-bit key size.
- **CBC Mode with PKCS7 Padding**: Ensures data integrity and security.
- **Secure Random IV**: Prevents cryptographic vulnerabilities through unique IV generation per encryption.
- **Comprehensive Error Handling**: Reliable cryptographic operations with robust error catching and logging.

---

## 🛡️ Best Security Practices

To maximize the security and effectiveness of your encryption:
- Securely store and manage keys in protected environments.
- Avoid IV reuse; always generate a new IV for each encryption.
- Rotate encryption keys periodically.
- Use secure channels for transmitting encryption keys.
- Regularly audit and update your cryptographic libraries and dependencies.

---

## 📚 Usage Example with File Operations

```csharp
// Read plaintext from file
string plainText = await File.ReadAllTextAsync("plainText.txt");

// Generate secure key
byte[] masterKey = RandomNumberGenerator.GetBytes(32);

// Encrypt data
string encryptedData = Encrypt(plainText, masterKey);
await File.WriteAllTextAsync("encrypted.txt", encryptedData);
Console.WriteLine("Data encrypted successfully!");

// Decrypt data
string decryptedData = Decrypt(encryptedData, masterKey);
await File.WriteAllTextAsync("decrypted.txt", decryptedData);
Console.WriteLine("Data decrypted successfully!");
```

---

## 📌 Prerequisites

- .NET 10.0 or higher
- Visual Studio 2022 or another compatible IDE

---

## 🤝 Contributing

Your contributions are warmly welcomed! Feel free to:
- Submit issues
- Propose enhancements
- Create pull requests

---

## 📄 License

Distributed under the **MIT License**. See [LICENSE](LICENSE) for more details.
