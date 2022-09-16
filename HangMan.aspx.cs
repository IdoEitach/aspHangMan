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
        private Random rnd = new Random();
        protected string ChooseRndWord(string cat)
        {
            string sql = "Select count(*) from "+cat+";";
            int id = rnd.Next(1, SQLHelper.SelectScalarToInt32(sql));
            sql = "select Word from "+cat+" where Id='"+id+"';";
            return SQLHelper.SelectScalarToString(sql);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //string sql = "select * From  Cat where Category = N'סרטים' ;";
            //string ans = SQLHelper.SelectScalarToString(sql);

            //Response.Write(ans);
            if (Session["Game"] == null)
            {
                string cat = Request.QueryString["cat"];
                Session["Cat"] = cat;
                Session["Game"] = new Game(ChooseRndWord(cat));
                Session["secretWord"] = (Session["Game"] as Game).HangmanWord();
                Session["Mistakes"] = (Session["Game"] as Game).WrongGuesses();
            }
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            char letter = (sender as Button).Text[0];
            switch (letter)
            {
                case 'כ':
                    (Session["Game"] as Game).addLetter('כ', 'ך');
                    break;
                case 'מ':
                    (Session["Game"] as Game).addLetter('מ', 'ם');
                    break;
                case 'נ':
                    (Session["Game"] as Game).addLetter('נ', 'ן');
                    break;
                case 'פ':
                    (Session["Game"] as Game).addLetter('פ', 'ף');
                    break;
                case 'צ':
                    (Session["Game"] as Game).addLetter('כ', 'ך');
                    break;
                default:
                    (Session["Game"] as Game).addLetter(letter);
                    break;
            }
            Session["secretWord"] = (Session["Game"] as Game).HangmanWord();
            Session["Mistakes"] = (Session["Game"] as Game).WrongGuesses();
            Button_Load(sender, e);
        }

        protected void Button_Load(object sender, EventArgs e)
        {
            GuessType type = (Session["Game"] as Game).LetterType((sender as Button).Text[0]);
            if (type == GuessType.Correct || type == GuessType.Wrong || type == GuessType.HalfCorrect)
                (sender as Button).CssClass = "pressed";
            if(type == GuessType.Wrong)
                (sender as Button).CssClass += " wrong";
        }
        
    }
}