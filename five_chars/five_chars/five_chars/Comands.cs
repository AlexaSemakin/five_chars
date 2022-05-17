using System;
using System.Collections.Generic;
using System.Text;
namespace five_chars
{
    public static class Comands
    {
        private static SortedDictionary<int,char> mask  = new SortedDictionary<int, char>();
        private static SortedSet<char> have = new SortedSet<char>();
        private static SortedSet<char> notHave = new SortedSet<char>();
        private static SortedDictionary<int, char> notMask = new SortedDictionary<int, char>();

        public static void AddCharInMask(char c, int index) {
            mask[index] = c;
        }

        public static void AddCharInNotMask(char c, int index)
        {
            notMask[index] = c;
        }

        public static void AddCharInHave(char c) {
            have.Add(c);
        }

        public static void AddCharInNotHave(char c)
        {
            notHave.Add(c);
        }

        public static void FindElement(AlphabetData data) {
            foreach (var item in data.words)
            {
                if (checkWord(item)) {
                    Console.WriteLine(item);
                }
            }
        }

        private static bool checkWord(string temp) {
            StringBuilder word = new StringBuilder(temp);
            foreach (var item in mask)
            {
                if (word[item.Key] != item.Value)
                    return false;
            }
            foreach (var item in notMask)
            {
                if (temp[item.Key] == item.Value) {
                    return false;
                }
            }

            foreach (var item in notHave) {
                for (int i = 0; i < temp.Length; i++)
                {
                    if (word[i] == item)
                    {
                        return false;
                    }
                }
            }
            foreach (var item in have)
            {
                int find = -1;
                for (int i = 0; i < temp.Length; i++)
                {
                    if (find == -1 && word[i] == item) {
                        find = i;
                        break;
                    }
                }
                if (find == -1) {
                    return false;
                }
                word[find] = '-';
            }

            return true;
        }

        public static void addInstruction(string word, string inst) {
            for (int i = 0; i < inst.Length; i++)
            {
                if (inst[i] == '0')
                {
                    AddCharInNotHave(word[i]);
                }
                else if (inst[i] == '1')
                {
                    AddCharInHave(word[i]);
                    AddCharInNotMask(word[i], i);
                }
                else {
                    AddCharInHave(word[i]);
                    AddCharInMask(word[i], i);
                }
            }
        }
    }
}
