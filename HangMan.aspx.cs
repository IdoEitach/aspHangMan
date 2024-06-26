﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HangManAsp
{
    public partial class HangMan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Game"] == null)
            {
                string cat = Request.QueryString["cat"];
                string title = Request.QueryString["title"];
                Word word;
                if (cat != "General")
                    word = Word.GetRandomFromCategory(cat);
                else
                    word = Word.GetRandom();

                Session["Cat"] = title;
                Session["Game"] = new Game(word);
                Session["SecretWord"] = (Session["Game"] as Game).GetHangmanWord();
                Session["Mistakes"] = (Session["Game"] as Game).GetWrongGuesses();
                Session["Hint"] = null;
                Session["Won"] = null;
                Session["WinHtml"] = "";
                //Response.Write(word.GetText());
            }
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            if (Session["Won"] != null) return;

            Game game = Session["Game"] as Game;
            char letter = (sender as Button).Text[0];

            game.addLetter(letter);
            Session["SecretWord"] = game.GetHangmanWord();
            Session["Mistakes"] = game.GetWrongGuesses();
            Button_Load(sender, e);

            if (game.GetGameStatus() != GameStatus.Playing)
            {
                this.EndGame();
            }
        }

        protected void Button_Load(object sender, EventArgs e)
        {
            GuessType type = (Session["Game"] as Game).GetLetterType((sender as Button).Text[0]);
            if (type != GuessType.Unguessed)
            {
                (sender as Button).CssClass = "pressed";
                (sender as Button).Enabled = false;
            }
            if (type == GuessType.Wrong)
                (sender as Button).CssClass += " wrong";
        }

        protected void ButtonHint_Click(object sender, EventArgs e)
        {
            Session["Hint"] = (Session["Game"] as Game).GetRandomHint();
            ButtonHint_Load(sender, e);
        }

        protected void ButtonHint_Load(object sender, EventArgs e)
        {
            if (Session["Hint"] != null || Session["Won"] != null)
            {
                (sender as Button).Style.Add(HtmlTextWriterStyle.Display, "none");
            }

        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            if (Session["Won"] != null)
            {
                Session["Game"] = null;
                Response.Redirect("HomePage.aspx");
            }

        }
        protected void ButtonBack_Load(object sender, EventArgs e)
        {
            if (Session["Won"] == null)
            {
                (sender as Button).Style.Add(HtmlTextWriterStyle.Display, "none");
            }
        }

        private void EndGame()
        {
            ButtonHint.Style.Add(HtmlTextWriterStyle.Display, "none");
            Game game = Session["Game"] as Game;
            bool won = game.GetGameStatus() == GameStatus.Won;

            string log;
            if (won)
            {
                log = $"Player \"{Session["PlayerName"] ?? Utils.GetRandomUsername()}\" successfully guessed \"{game.GetWord().GetText()}\" with {game.GetWrongGuesses()} wrong guesses.";
            }
            else
            {
                log = $"Player \"{Session["PlayerName"] ?? Utils.GetRandomUsername()}\" failed to guess \"{game.GetWord().GetText()}\" with {game.GetWrongGuesses()} wrong guesses.";
            }
            if (Session["Hint"] != null)
            {
                log += " (Used an hint "+ Session["Hint"] + ")";
                
            }
            File.AppendAllText(Request.MapPath("data.txt"),
                $"[{DateTime.Now.ToString("dd/MM/yyyy HH:mm")}] {log}\n");
            
           

            ButtonBack.Style.Add(HtmlTextWriterStyle.Display, null);

            Session["Won"] = won;
            Session["WinHtml"] = won
                   ? $"<div style=\"color: green;\">ניצחת!</div>"
                   : $"<div style=\"color: red;\">הפסדת. המילה הייתה: <b>{game.GetWord().GetText()}</b></div>";
        }

    }
}