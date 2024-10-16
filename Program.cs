using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdamAsmaca
{
    class Hangman
    {
        static void Main()
        {
            string[] wordList = { "sena", "adam", "asmaca", "ödevi", "yazilim" };
            Random random = new Random();
            string chosenWord = wordList[random.Next(wordList.Length)];

            char[] guessedWord = new string('_', chosenWord.Length).ToCharArray();
            List<char> guessedLetters = new List<char>();
            int attemptsLeft = 6;
            bool wordGuessed = false;

            Console.WriteLine("Adam Asmaca Oyununa Hoş Geldiniz!");

            while (attemptsLeft > 0 && !wordGuessed)
            {
                Console.WriteLine("\nKelime: " + new string(guessedWord));
                Console.WriteLine($"Kalan tahmin hakkı: {attemptsLeft}");
                Console.Write("Bir harf tahmin edin: ");
                char guessedChar = char.ToLower(Console.ReadLine()[0]);

                if (guessedLetters.Contains(guessedChar))
                {
                    Console.WriteLine("Bu harfi zaten tahmin ettiniz, başka bir harf deneyin.");
                    continue;
                }
                guessedLetters.Add(guessedChar);

                if (chosenWord.Contains(guessedChar))
                {
                    Console.WriteLine($"Doğru tahmin! '{guessedChar}' harfi kelimenin içinde var.");
                    for (int i = 0; i < chosenWord.Length; i++)
                    {
                        if (chosenWord[i] == guessedChar)
                        {
                            guessedWord[i] = guessedChar;
                        }

                    }
                }
                else
                {
                    Console.WriteLine($"Yanlış tahmin! '{guessedChar}' harfi kelimenin içinde yok.");
                    attemptsLeft--;
                }

                //Eğer kelimenin tamamı tahmin edildiyse oyun biter
                wordGuessed = new string(guessedWord) == chosenWord;

            }

            if (wordGuessed)
            {
                Console.WriteLine($"\nTebrikler! Kelimeyi doğru tahmin ettiniz: {chosenWord}");
            }
            else
            {
                Console.WriteLine($"\nMaalesef, tahmin hakkınız bitti. Kelime:{chosenWord}");

            }

        }
    }
}