using System;
using System.IO;


namespace five_chars
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            string s = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "/alphabet.txt");
            Console.Write(s);
        }
    }
}
