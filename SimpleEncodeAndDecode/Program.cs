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
        private static readonly Random Random = new Random();
        static void Main(string[] args)
        {
            const string plaintext = "THISISASECRETMESSAGE";
            char[] cipher = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            cipher = ShuffleCipher(cipher);

            var encodedMessage = Encode(plaintext, cipher);

            var decodedMessage = Decoder(encodedMessage, cipher);

            Console.WriteLine($"Plaintext: {plaintext}");
            Console.WriteLine($"Endcoded: \xA0{encodedMessage}");
            Console.WriteLine($"Decoded: \xA0 {decodedMessage}");
        }

        private static char[] ShuffleCipher(char[] cipher)
        {
            char[] shuffled = new char[cipher.Length];
            List<char> cipherList = new List<char>(cipher);
            int randomIndex;
            for (var i = 0; i < cipher.Length; i++)
            {
                do
                {
                    randomIndex = Random.Next(0, cipherList.Count);
                } while (cipher[i] == cipherList[randomIndex]);

                shuffled[i] = cipherList[randomIndex];
                cipherList.RemoveAt(randomIndex);
            }
            return shuffled;
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
