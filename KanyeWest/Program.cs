using Newtonsoft.Json.Linq;

namespace KanyeWest
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Quotes.KanyeQuote();
                Quotes.RonQuote();
                Console.WriteLine();
            }
        }
    }
    class Quotes 
    { 
        public static void RonQuote()
        {
            var client = new HttpClient();

            var ronResponse = client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;

            var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace('"', ' ').Replace('"', ' ').Replace(']', ' ').Trim();  //.Replace seems to not be working?
                                                                                                             //FIXED: ronQuote was specified as
                                                                                                             //ronResponse in print method. When
                                                                                                             //.Replace works it actually replaces
                                                                                                             //the entire string creating a new
                                                                                                             //one but leaving the old in tact.
            Console.Write("Ron: ");
            Console.WriteLine(String.Join(" ", ronQuote));
            
        }

        public static void KanyeQuote()
        {
            var client = new HttpClient();

            var kanyeResponse = client.GetStringAsync("https://api.kanye.rest").Result;

            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

            Console.Write("Kanye: ");
            Console.WriteLine(String.Join(" ", kanyeQuote));
        }
    }
}