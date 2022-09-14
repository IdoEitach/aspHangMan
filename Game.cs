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
            guessedLetters = new GuessType[22];
            index = 0;
        }
        public void addLetter(char letter)
        {
            int index = LetterToInt(letter);
            if (guessedLetters[index] != GuessType.Unguessed || this.wrongGuesses >= 7)
            {
                return;
            }

            if (!this.word.Contains(letter))
            {
                guessedLetters[index] = GuessType.Wrong;
                this.wrongGuesses++;
            } else
            {
                guessedLetters[index] = GuessType.Correct;
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
        private static char[] letters = { 'א', 'ב', 'ג', 'ד', 'ה', 'ו', 'ז', 'ח', 'ט', 'י', 'כ', 'ל', 'מ', 'נ', 'ס', 'ע', 'פ', 'צ', 'ק', 'ר', 'ש', 'ת' };

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