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
                string word = ChooseRndWord(cat);
                
                Session["Cat"] = cat;
                Session["Game"] = new Game(word);
                Session["secretWord"] = (Session["Game"] as Game).GetHangmanWord();
                Session["Mistakes"] = (Session["Game"] as Game).GetWrongGuesses();
            }
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            char letter = (sender as Button).Text[0];

             (Session["Game"] as Game).addLetter(letter);
             
            Session["secretWord"] = (Session["Game"] as Game).GetHangmanWord();
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
        
    }
}