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
        protected void ChooseRndWord(object sender, EventArgs e)
        {
            string sql = "select * From  Cat ;";
            int ans = SQLHelper.SelectScalarToInt32(sql);
            Response.Write(ans);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select * From  Cat where Category = N'סרטים' ;";
            string ans = SQLHelper.SelectScalarToString(sql);

            Response.Write(ans);
            if (Session["Game"] == null)
            {
                Session["Game"] = new Game("אבג דהו");
                Session["secretWord"] = (Session["Game"] as Game).HangmanWord();
                Session["Mistakes"] = (Session["Game"] as Game).WrongGuesses();
            }
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            char letter = (sender as Button).Text[0];
            (Session["Game"] as Game).addLetter(letter);
            Session["secretWord"] = (Session["Game"] as Game).HangmanWord();
<<<<<<< HEAD

         
=======
            Session["Mistakes"] = (Session["Game"] as Game).WrongGuesses();
            Button_Load(sender, e);
        }

        protected void Button_Load(object sender, EventArgs e)
        {
            GuessType type = (Session["Game"] as Game).LetterType((sender as Button).Text[0]);
            if (type == GuessType.Correct || type == GuessType.Wrong)
                (sender as Button).CssClass = "pressed";
            if(type == GuessType.Wrong)
                (sender as Button).CssClass += " wrong";
>>>>>>> 368ffc754a3706172ca8dfbdc268ffae819a8264
        }
        
    }
}