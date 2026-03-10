namespace WordFrequencyCountApp
{
    internal class Program
    {
        static string? GetSeentence()
        {
            Console.Write("enter a sentence: ");
            return Console.ReadLine();
        }
        static char[] FindSeparators(string sentence)
        {
            HashSet<char> separators = [];
            foreach (char ch in sentence)
            {
                if(char.IsLetter(ch) || char.IsDigit(ch))
                {
                    continue;
                }
                else
                {
                    separators.Add(ch);
                }
            }
            //return separators.ToArray<char>();
            return [.. separators];
        }
        static SortedDictionary<string,int> CountWordFrequency(string[] words)
        {
            SortedDictionary<string, int> wordCount = new();
            
            foreach (string word in words)
            {
                string key = word.ToLower();
                if (!wordCount.ContainsKey(key))
                {
                    wordCount.Add(key, 1);
                }
                else
                {
                    wordCount[key] = wordCount[key] + 1;
                }
            }
            return wordCount;
        }
        static void Main(string[] args)
        {
            string? sentence = GetSeentence();
            if (sentence != null)
            {
                char[] separators = FindSeparators(sentence);

                string[] words = sentence.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                SortedDictionary<string,int> wordCount = CountWordFrequency(words);

                foreach (KeyValuePair<string,int> item in wordCount)
                {
                    Console.WriteLine($"{item.Key}:{item.Value}");
                }
            }
        }
    }
}
