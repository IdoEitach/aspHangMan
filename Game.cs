﻿using System;
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
        private Word word;
        private int wrongGuesses;
        private GuessType[] guessedLetters;
        private static char[] letters = { 'א', 'ב', 'ג', 'ד', 'ה', 'ו', 'ז', 'ח', 'ט', 'י', 'כ', 'ל', 'מ', 'נ', 'ס', 'ע', 'פ', 'צ', 'ק', 'ר', 'ש', 'ת' };
        private Random rnd = new Random();

        public Game(Word word)
        {
            // create the word + wrongGuesses + guessedLetters + index
            this.word = word;
            this.wrongGuesses = 0;
            this.guessedLetters = new GuessType[letters.Length];
        }
        public void addLetter(char letter)
        {
            int index = LetterToInt(letter);
            if (guessedLetters[index] != GuessType.Unguessed || this.wrongGuesses >= 6)
            {
                return;
            }
            guessedLetters[index] = GuessType.Correct;
            if (!this.word.GetWord().Contains(letter))
            {
                guessedLetters[index] = GuessType.Wrong;
                this.wrongGuesses++;
            }
            else
            {
                guessedLetters[index] = GuessType.Correct;
            }
        }
        public string GetHangmanWord()
        {
            string str = "";
            string word = this.word.GetWord();
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == ' ')
                    str += "- ";
                else if (guessedLetters[LetterToInt(LowerLetter(word[i]))] == GuessType.Correct)
                    str += word[i] + " ";
                else
                    str += "_ ";
            }
            return str;
        }
        public GuessType LetterType(char letter)
        {
            return guessedLetters[LetterToInt(letter)];
        }

        public int GetWrongGuesses()
        {
            return this.wrongGuesses;
        }

        private static char LowerLetter(char letter)
        {
            switch (letter)
            {
                case 'ך': return 'כ';
                case 'ם': return 'מ';
                case 'ן': return 'נ';
                case 'ף': return 'פ';
                case 'ץ': return 'צ';
                default: return letter;
            }
        }

        public static int LetterToInt(char letter)
        {
            for (int i = 0; i < letters.Length; i++) {
                if (letters[i] == letter)
                    return i;
            }
            return 0;
        }

        public string GetRandomHint()
        {
            return this.word.GetHints()[this.rnd.Next(this.word.GetHints().Length)];
        }
    }
}