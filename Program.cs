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
            // Defining the word list
            // Kelime listesini tanımlıyoruz
            string[] wordList = { "sena", "adam", "asmaca", "ödevi", "yazilim" };
            Random random = new Random();
            
            // Selecting a random word
            // Rastgele bir kelime seçiyoruz
            string chosenWord = wordList[random.Next(wordList.Length)];

            // Variables to store the guessed word and letters
            // Tahmin edilen kelimeyi ve harfleri saklamak için gerekli değişkenler
            char[] guessedWord = new string('_', chosenWord.Length).ToCharArray(); // Başlangıçta tüm karakterler'_'olarak ayarlanır / Initially setting all characters to '_'
            List<char> guessedLetters = new List<char>(); // Tahmin edilen harflerin listesi / List of guessed letters
            int attemptsLeft = 6; // Kalan tahmin hakkı / Remainig guess attempts
            bool wordGuessed = false;

            Console.WriteLine("Adam Asmaca Oyununa Hoş Geldiniz!"); // English: Welcome to the Hangman Game!

            while (attemptsLeft > 0 && !wordGuessed)//Tahmin hakları bitmediği ve kelime bilinmediği sürece devam eder.
            {
                Console.WriteLine("\nKelime: " + new string(guessedWord));// English: Displays the current state of the word.
                Console.WriteLine($"Kalan tahmin hakkı: {attemptsLeft}");// English: Shows remaining attempts.
                Console.Write("Bir harf tahmin edin: "); // English: Prompt to guess a letter.

                //Takes a letter from the user and converts it to lowercase.
                //Kullanıcıdan bir harf alıp küçük harfe çevirir.
                char guessedChar = char.ToLower(Console.ReadLine()[0]);

                if (guessedLetters.Contains(guessedChar)) // Harfin zaten tahmin edilip edilmediğini kontrol eder.
                {
                    Console.WriteLine("Bu harfi zaten tahmin ettiniz, başka bir harf deneyin."); // Inform the user if they already guessed the letter.
                    continue;
                }
                guessedLetters.Add(guessedChar); // Tahmin edilen harfi listeye ekler / Adds the guessed letter to the list.

                if (chosenWord.Contains(guessedChar)) // Tahmin edilen harfin kelimede olup olmadığını kontrol eder
                {
                    Console.WriteLine($"Doğru tahmin! '{guessedChar}' harfi kelimenin içinde var."); // Correct guess message.
                    for (int i = 0; i < chosenWord.Length; i++) // Kelimedeki tüm harfleri kontrol eder. / Checks each character in the word.
                    {
                        if (chosenWord[i] == guessedChar) // Tahmin edilen harf doğruysa, guessedWord dizisine eklenir.
                        {
                            guessedWord[i] = guessedChar; // Adds correct guessed letter to guessedWord array.
                        }

                    }
                }
                else
                {
                    Console.WriteLine($"Yanlış tahmin! '{guessedChar}' harfi kelimenin içinde yok."); // Incorrect guess message.
                    attemptsLeft--; // Yanlış tahminde bulunulursa tahmin hakları azaltılır. / Decreases attempts left on incorrect guess.
                }

                //Eğer kelimenin tamamı tahmin edildiyse oyun biter
                wordGuessed = new string(guessedWord) == chosenWord;

            }

            if (wordGuessed) // Oyuncu kelimeyi bilirse kazandığını belirtir.
            {
                Console.WriteLine($"\nTebrikler! Kelimeyi doğru tahmin ettiniz: {chosenWord}");
            }
            else // Oyuncu tahmin hakkını doldurduysa kaybettiğini belirtir.
            {
                Console.WriteLine($"\nMaalesef, tahmin hakkınız bitti. Kelime:{chosenWord}"); // Informs the player of the correct word after they run out of attempts.

            }

        }
    }
}
