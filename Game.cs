using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangManAsp
{
    public class Game
    {
        private string word;
        private int wrongGuesses;
        private char[] guessedLetters;
        public Game(string word)
        {
            this.word = word;
            wrongGuesses = 0;
            guessedLetters = new char[22];
        }
        public bool FindLetter(char letter)
        {
            //if (guessedLetters.Contains(letter))
            return this.word.Contains(letter);
        }
        public string HangmanWord()
        {
            string str = "";
            for (int i = 0; i < guessedLetters.Length; i++)
                if (this.word.Contains(guessedLetters[i]))
                    str += guessedLetters[i] + " ";
                else
                    str += "_ ";
            return str;
        }
    }
}