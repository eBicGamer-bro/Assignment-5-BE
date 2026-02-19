namespace Assignment_5
{
    class MyCookieCollection
    {
        string username,theme,language;
        public MyCookieCollection()
        {
           username = string.Empty;
           theme = string.Empty;
           language = string.Empty;
        }
        public string this[string key]
        {
            get
            {
                if (key.Equals("username"))
                    return username;
                else if (key.Equals("theme"))
                    return theme;
                else if (key.Equals("language"))
                    return language;
                else
                    return null;
            }
            set
            {
                if (key.Equals("username"))
                    username = value;
                else if (key.Equals("theme"))
                    theme = value;
                else if (key.Equals("language"))
                    language = value;
            }
        }



    }
    internal class Program
    {
        static void Main(string[] args)
        {
           MyCookieCollection cookies = new MyCookieCollection();
            cookies["username"] = "John Doe";
            cookies["theme"] = "dark";
            cookies["language"] = "en";
            Console.WriteLine("Username: " + cookies["username"]);
            Console.WriteLine("Theme: " + cookies["theme"]);
            Console.WriteLine("Language: " + cookies["language"]);

        }
    }
}
