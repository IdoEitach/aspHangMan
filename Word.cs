using System;
using System.Data;

namespace HangManAsp
{
    public class Word
    {
        private int id;
        private string text;
        private string[] hints;
        private static Random rnd = new Random();


        public Word(int id, string text, string[] hints)
        {
            this.id = id;
            this.text = text;
            this.hints = hints;
        }
        public static Word GetRandomFromCategory(string category)
        {
            string sql = $"Select count(*) from {category};";
            int id = rnd.Next(1, SQLHelper.SelectScalarToInt32(sql)+1);
            sql = $"select * from {category} where Id='{id}';";
            var data = SQLHelper.SelectData(sql);
            return new Word((data.Rows[0][0] as int?) ?? -1, (data.Rows[0][1] as string).Trim(), ((data.Rows[0][2] as string) ?? "").Split('.'));
        }
        public static Word GetRandom()
        {
            string sql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES";
            DataTable datatable = SQLHelper.SelectData(sql);
            string cat = (string)datatable.Rows[rnd.Next(0, datatable.Rows.Count - 1)][0];
            return GetRandomFromCategory(cat);
        }

        public string GetText()
        {
            return this.text;
        }

        public string[] GetHints()
        {
            return this.hints;
        }
    }
}