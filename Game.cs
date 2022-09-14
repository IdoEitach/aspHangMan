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
        private int index;
        public Game(string word)
        {
            // create the word + wrongGuesses + guessedLetters + index
            this.word = word;
            wrongGuesses = 0;
            guessedLetters = new char[22];
            index = 0;
        }
        public void addLetter(char letter)
        {
            if (index == guessedLetters.Length || guessedLetters.Contains(letter) || this.wrongGuesses==7)//check for the letter is'nt exsist or wrongGuesses!=7
                return;
            guessedLetters[index] = letter;
            index++;
            if (!this.word.Contains(letter))
                this.wrongGuesses++;
        }
        public string HangmanWord()
        {
            string str = "";
            for (int i = 0; i < word.Length; i++)
                if(word[i] == ' ')
                    str += "- ";
                else if (guessedLetters.Contains(this.word[i]))
                    str += word[i] + " ";
                else
                    str += "_ ";
            return str;
        }
    }
}