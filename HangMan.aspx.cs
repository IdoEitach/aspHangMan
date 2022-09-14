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
            if(Session["Game"] == null)
            {
                Session["Game"] = new Game("אבג דהו");
                Session["secretWord"] = (Session["Game"] as Game).HangmanWord();
            }
            //string[] letters = { "א", "ב", "ג", "ד", "ה", "ו", "ז", "ח", "ט", "י", "כ", "ל", "מ", "נ", "ס", "ע", "פ", "צ", "ק", "ר", "ש", "ת" };
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            char letter = (sender as Button).Text[0];
            (Session["Game"] as Game).addLetter(letter);
            Session["secretWord"] = (Session["Game"] as Game).HangmanWord();
        }

        protected void Button_Load(object sender, EventArgs e)
        {

        }
    }
}