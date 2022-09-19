using System;
using System.Collections.Generic;
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
                Word word = Word.GetRandomFromCategory(cat);

                Session["Cat"] = cat;
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
                ButtonHint.Style.Add(HtmlTextWriterStyle.Display, "none");
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
            Game game = Session["Game"] as Game;
            bool won = game.GetGameStatus() == GameStatus.Won;

            (ButtonBack as Button).Style.Add(HtmlTextWriterStyle.Display, null);


            Session["Won"] = won;
            Session["WinHtml"] = won
                   ? $"<div style=\"color: green;\">You won!</div>"
                   : $"<div style=\"color: red;\">You lost. The word was {game.GetWord().GetText()}.</div>";
        }

    }
}