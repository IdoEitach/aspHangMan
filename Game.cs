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

    public enum GameStatus
    {
        Playing,
        Lost,
        Won,
    }

    public class Game
    {
        private Word word;
        private int wrongGuesses;
        private GuessType[] guessedLetters;
        private static char[] letters = { 'א', 'ב', 'ג', 'ד', 'ה', 'ו', 'ז', 'ח', 'ט', 'י', 'כ', 'ל', 'מ', 'נ', 'ס', 'ע', 'פ', 'צ', 'ק', 'ר', 'ש', 'ת' };
        private Random rnd = new Random();
        private const int NumberOfGuesses = 6;
        private GameStatus gameStatus;

        public Game(Word word)
        {
            // create the word + wrongGuesses + guessedLetters + index
            this.word = word;
            this.wrongGuesses = 0;
            this.guessedLetters = new GuessType[letters.Length];
            this.gameStatus = GameStatus.Playing;
        }
        public void addLetter(char letter)
        {
            int index = LetterToInt(letter);
            if (guessedLetters[index] != GuessType.Unguessed || this.wrongGuesses >= NumberOfGuesses)
            {
                return;
            }
            guessedLetters[index] = GuessType.Correct;
            if (!LowerText(this.word.GetText()).Contains(letter))
            {
                guessedLetters[index] = GuessType.Wrong;
                this.wrongGuesses++;
                if (GetGuessesLeft() == 0)
                {
                    this.gameStatus = GameStatus.Lost;
                }
            }
            else
            {
                guessedLetters[index] = GuessType.Correct;
                if (IsWordFinished())
                {
                    this.gameStatus = GameStatus.Won;
                }
            }
        }
        public string GetRandomHint()
        {
            string[] hints = this.word.GetHints();
            if (hints[0] == "")
                return "אין כרגע רמז למילה זאת.";
            return hints[this.rnd.Next(hints.Length)] + ".";
        }
        public Word GetWord()
        {
            return this.word;
        }
        public string GetHangmanWord()
        {
            string str = "";
            string word = this.word.GetText();
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
        public GuessType GetLetterType(char letter)
        {
            return guessedLetters[LetterToInt(letter)];
        }
        public GameStatus GetGameStatus()
        {
            return this.gameStatus;
        }
        public int GetWrongGuesses()
        {
            return this.wrongGuesses;
        }

        private int GetGuessesLeft()
        {
            return Game.NumberOfGuesses - this.wrongGuesses;
        }
        private bool IsWordFinished()
        {
            string word = this.word.GetText();
            for (int i = 0; i < word.Length; i++)
            {
                if (guessedLetters[LetterToInt(LowerLetter(word[i]))] != GuessType.Correct)
                {
                    return false;
                }
            }
            return true;
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

        private static string LowerText(string text)
        {
            string lowerText = "";
            for (int i = 0; i < text.Length; i++)
            {
                lowerText += LowerLetter(text[i]);
            }
            return lowerText;
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