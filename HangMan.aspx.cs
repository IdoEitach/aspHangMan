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
            }
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            char letter = (sender as Button).Text[0];

            (Session["Game"] as Game).addLetter(letter);
            Session["SecretWord"] = (Session["Game"] as Game).GetHangmanWord();
            Session["Mistakes"] = (Session["Game"] as Game).GetWrongGuesses();
            Button_Load(sender, e);
        }

        protected void Button_Load(object sender, EventArgs e)
        {
            GuessType type = (Session["Game"] as Game).LetterType((sender as Button).Text[0]);
            if (type != GuessType.Unguessed)
            {
                (sender as Button).CssClass = "pressed";
                (sender as Button).Enabled = false;
            }
            if(type == GuessType.Wrong)
                (sender as Button).CssClass += " wrong";
        }

        protected void ButtonHint_Click(object sender, EventArgs e)
        {
            Session["Hint"] = (Session["Game"] as Game).GetRandomHint();
            ButtonHint_Load(sender, e);
        }

        protected void ButtonHint_Load(object sender, EventArgs e)
        {
            if (Session["Hint"] != null)
            {
                (sender as Button).Style.Add(HtmlTextWriterStyle.Display, "none");
            }
            
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Session["Game"] = null;
            Response.Redirect("HomePage.aspx");
        }
    }
}