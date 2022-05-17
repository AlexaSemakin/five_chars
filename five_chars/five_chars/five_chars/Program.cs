using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace five_chars
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            AlphabetData alphabetData = JsonConvert.DeserializeObject<AlphabetData>(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "/alphabet.json"));
            Dictionary<char, int> statistic = new Dictionary<char, int>();
            foreach (var item in alphabetData.words)
            {
                for (char i = 'а'; i <= 'я'; i++)
                {
                    if (item.Split(i).Length > 1) {
                        int result = 0;
                        if (statistic.TryGetValue(i, out result))
                        {
                            statistic[i]++;
                        }
                        else {
                            statistic[i] = 1;
                        }
                    }
                }
            }
            SortedDictionary<int, char> data = new SortedDictionary<int, char>();
            
            foreach (var item in statistic)
            {
                data[item.Value] = item.Key;
            }
            
            foreach (var item in data)
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }
            Comands.addInstruction("окапи", "01000");
            Comands.addInstruction("беляк", "00001");

           


            Comands.FindElement(alphabetData);
        }
    }
}
