using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangManAsp
{
    internal static class Utils
    {
        private static Random rnd = new Random();

        public static string GetRandomUsername()
        {
            return "Player" + rnd.Next(0, 1000);
        }
    }
}
