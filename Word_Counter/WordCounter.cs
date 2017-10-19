using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections;

namespace Word_Counter
{
    public class WordCounter
    {
        public static void Main(string[] args)
        {
            //Receiving data from a command line
            if (args.Length == 0)
            {
                Console.WriteLine("Argument not found.");
                return;
            }

            string rawText = string.Empty;

            try
            {
                rawText = File.ReadAllText(args[0]);
            }
            catch
            {
                Console.WriteLine("An error occured while reading from a file.");
                return;
            }

            //Splitting the whole text into an array of words
            IEnumerable<string> words = SplitText(rawText);

            //Hashtable provides faster access to each word rather than looping through an array.
            Hashtable wordsTable = CreateWordsHashTable(words);

            //Displaying rsults into a console.
            foreach (DictionaryEntry item in wordsTable)
            {
                Console.WriteLine(item.Key.ToString() + ' ' + item.Value);
            }

            //Delay.
            Console.ReadKey();
        }
        /// <summary>
        /// Splits the text into a word array. Words with dashes are considered to be a single word.
        /// </summary>
        /// <param name="rawText">Text to be splitted</param>
        /// <returns>Lower case words array</returns>
        public static IEnumerable<string> SplitText(string rawText)
        {
            string pattern = "(?!-)(?!`)[A-Za-z-`]+";
            MatchCollection matches = Regex.Matches(rawText, pattern);

            foreach (Match item in matches)
            {
                yield return item.Value.ToLower();
            }
        }

        /// <summary>
        ///Counts an occurrence of each word in a colletion.
        /// </summary>
        /// <param name="collection">String collection to be counted</param>
        /// <returns>Hashtable where both Key and Vaue are Objects</returns>
        public static Hashtable CreateWordsHashTable(IEnumerable<string> collection)
        {
            Hashtable wordsTable = new Hashtable(collection.Count());

            foreach (string word in collection)
            {
                if (wordsTable.ContainsKey(word))
                {
                    int current = Convert.ToInt32(wordsTable[word]);
                    wordsTable[word] = ++current;
                }
                else
                {
                    wordsTable.Add(word, 1);
                }
            }
            return wordsTable;
        }
    }
}
