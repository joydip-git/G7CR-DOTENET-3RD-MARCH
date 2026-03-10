namespace KeyValueCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<string, string> preferences = new();
            SortedList<string, string> preferences = new();

            preferences.Add("joydip", "Bank Account");
            preferences.Add("harika", "Investment");
            

            //will throw error because of the duplicate key
            //preferences.Add("joydip", "Funds Transfer");

            //will update the value associated with key if the key exists
            //will add the key and the value if the key does not exist
            preferences["joydip"] = "Funds Transfer";
            //preferences.Remove("joydip");

            foreach (KeyValuePair<string,string> kvPair in preferences)
            {
                Console.WriteLine($"{kvPair.Key}: {kvPair.Value}");
            }

            if (preferences.ContainsKey("kaif"))
            {
                Console.WriteLine("exists");
            }
        }
    }
}
