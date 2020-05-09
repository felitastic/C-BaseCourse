using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace WebCrawler
{
    class Crawler
    {
        public static object mutex = new object();
        public static HashSet<string> allLinks = new HashSet<string>();

        public static bool AddLink(string _URL)
        {
            lock(mutex)
            {
                return allLinks.Add(_URL);
            }
        }

        public static async Task<string> DownloadFile(string _URL)
        {
            using (var wc = new System.Net.WebClient())
            {
                try
                {
                    return await wc.DownloadStringTaskAsync(_URL);
                }
                catch (WebException)
                {
                    Console.WriteLine("Website not found");
                    return "";
                }
            }
        }

        public static int SearchForPhrase(string _searchTerm, string _stringToCheck)
        {
            return Regex.Matches(_stringToCheck, _searchTerm).Count;
        }

        public static IEnumerable<string> WebsiteList(string content)
        {
            foreach (Match match in Regex.Matches(content, "href=\"(https?://www\\.games-academy\\.de)?/([^\"#\\?:.]*)[\"#\\?]"))
            {
                yield return "http://www.games-academy.de/" + match.Groups[2].Value;                
            }
        }

        public static async Task FileHandler(string _URL, int _searchDepth)
        {
            string searchTerm = "Game";
            Crawler.AddLink(_URL);
            string content = await Crawler.DownloadFile(_URL);
            int Foundterm = Crawler.SearchForPhrase(searchTerm, content);
            Console.WriteLine("'{2}' found {0} times in {1}", Foundterm, _URL, searchTerm);
            //Console.WriteLine(string.Join("\n", Crawler.WebsiteList(content)));
            _searchDepth -= 1;

            if (_searchDepth > 0)
            {
                List<Task> allTasks = new List<Task>();

                foreach (string link in Crawler.WebsiteList(content))
                {
                    if (Crawler.AddLink(link))
                    {
                        Task task = FileHandler(link, _searchDepth);
                        allTasks.Add(task);
                    }
                }
                await Task.WhenAll(allTasks.ToArray());            
            }            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I love searching stuff! :D");
            Crawler.FileHandler("http://www.games-academy.de/", 3).Wait();
        }
    }
}
