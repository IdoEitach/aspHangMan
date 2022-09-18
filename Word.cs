using System;

namespace HangManAsp
{
    public class Word
    {
        private int id;
        private string word;
        private string[] hints;
        private static Random rnd = new Random();


        public Word(int id, string word, string[] hints)
        {
            this.id = id;
            this.word = word;
            this.hints = hints;
        }
        public static Word GetRandomFromCategory(string category)
        {
            string sql = $"Select count(*) from {category};";
            int id = rnd.Next(1, SQLHelper.SelectScalarToInt32(sql));
            sql = $"select * from {category} where Id='{id}';";
            var data = SQLHelper.SelectData(sql);
            return new Word((data.Rows[0][0] as int?) ?? -1, data.Rows[0][1] as string, (data.Rows[0][2] as string).Split('.'));
        }

        public string GetWord()
        {
            return this.word;
        }

        public string[] GetHints()
        {
            return this.hints;
        }
    }
}