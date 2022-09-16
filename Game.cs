using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.DynamicData;

namespace HangManAsp
{
    public enum GuessType
    {
        Unguessed,
        Wrong,
        Correct,
        HalfCorrect,
    }

    public class Game
    {
        private string word;
        private int wrongGuesses;
        private GuessType[] guessedLetters;
        private int index;

        public Game(string word)
        {
            // create the word + wrongGuesses + guessedLetters + index
            this.word = word;
            wrongGuesses = 0;
            guessedLetters = new GuessType[27];
            index = 0;
        }
        private void finalLetters(char regular, char final)
        {
            if (this.word.Contains(regular) || this.word.Contains(final))
                guessedLetters[index] = GuessType.Correct;
            else
            {
                guessedLetters[index] = GuessType.Wrong;
                this.wrongGuesses++;
            }
        }
        public void addLetter(char letter, char finalLetter = ' ')
        {
            int index = LetterToInt(letter);
            if (guessedLetters[index] != GuessType.Unguessed || this.wrongGuesses >= 6)
            {
                return;
            }
            if(finalLetter != ' ')
            {
                if (this.word.Contains(letter) && this.word.Contains(finalLetter))
                {
                    guessedLetters[index] = GuessType.Correct;
                    guessedLetters[LetterToInt(finalLetter)] = GuessType.Correct;
                }
                else if(this.word.Contains(letter) && !this.word.Contains(finalLetter))
                {
                    guessedLetters[index] = GuessType.Correct;
                    guessedLetters[LetterToInt(finalLetter)] = GuessType.HalfCorrect;
                }
                else if (!this.word.Contains(letter) && this.word.Contains(finalLetter))
                {
                    guessedLetters[index] = GuessType.HalfCorrect;
                    guessedLetters[LetterToInt(finalLetter)] = GuessType.Correct;
                }
                else
                {
                    guessedLetters[index] = GuessType.Wrong;
                    guessedLetters[LetterToInt(finalLetter)] = GuessType.Wrong;
                    this.wrongGuesses++;
                }
            }
            else
            {
                if (!this.word.Contains(letter))
                {
                    guessedLetters[index] = GuessType.Wrong;
                    this.wrongGuesses++;
                }
                else
                {
                    guessedLetters[index] = GuessType.Correct;
                }
            }
        }
        public string HangmanWord()
        {
            string str = "";
            for (int i = 0; i < word.Length; i++)
                if(word[i] == ' ')
                    str += "- ";
                else if (guessedLetters[LetterToInt(this.word[i])] == GuessType.Correct)
                    str += word[i] + " ";
                else
                    str += "_ ";
            return str;
        }
        public GuessType LetterType(char letter)
        {
            return guessedLetters[LetterToInt(letter)];
        }
        private static char[] letters = { 'א', 'ב', 'ג', 'ד', 'ה', 'ו', 'ז', 'ח', 'ט', 'י', 'כ', 'ל', 'מ', 'נ', 'ס', 'ע', 'פ', 'צ', 'ק', 'ר', 'ש', 'ת', 'ך', 'ם', 'ן', 'ף', 'ץ' };
        public int WrongGuesses()
        {
            return this.wrongGuesses;
        }
        public static int LetterToInt(char letter)
        {
            for (int i = 0; i < letters.Length; i++) {
                if (letters[i] == letter)
                    return i;
            }
            return 0;
        }
    }
}