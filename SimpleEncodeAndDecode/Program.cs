using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEncodeAndDecode
{
    class Program
    {
        static void Main(string[] args)
        {
            const string plaintext = "THISISASECRETMESSAGE";
            char[] cipher = { 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Z', 'X', 'C', 'V', 'B', 'N', 'M' };

            var encodedMessage = Encode(plaintext, cipher);

            var decodedMessage = Decoder(encodedMessage, cipher);

            Console.WriteLine($"Plaintext: {plaintext}");
            Console.WriteLine($"Endcoded: \xA0{encodedMessage}");
            Console.WriteLine($"Decoded: \xA0 {decodedMessage}");
        }

        private static string Encode(string plaintext, char[] cipher)
        {
            var encodedMessage = string.Empty;
            for (var i = 0; i < plaintext.Length; i++)
            {
                var c = plaintext[i];
                var cipherIndex = c - 'A';
                encodedMessage += cipher[cipherIndex];
            }
            return encodedMessage;
        }

        private static string Decoder(string encodedMessage, char[] cipher)
        {
            var decodedMessage = string.Empty;
            for (var i = 0; i < encodedMessage.Length; i++)
            {
                var cipherIndex = 0;
                for (var j = 0; j < cipher.Length; j++)
                {
                    if (encodedMessage[i] == cipher[j])
                    {
                        cipherIndex = j;
                    }
                }

                var c = (char)('A' + cipherIndex);
                decodedMessage += c;
            }
            return decodedMessage;
        }
    }
}
