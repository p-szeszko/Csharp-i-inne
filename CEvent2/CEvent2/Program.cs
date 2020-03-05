using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using static System.Console;

namespace CEvent2
{
    class Program
    {
        private const string url = "http://interia.pl";
        static async Task Main(string[] args)
        {
            SynchronizedAPI();
            //AsynchronousPattern();       
            //EventBasedAsyncPattern();     
            await TaskBasedAsyncPatternAsync();
            ReadLine();
        }
        private static async Task TaskBasedAsyncPatternAsync()
        {
            string name = nameof(TaskBasedAsyncPatternAsync); WriteLine("\t" + name);

            using (var client = new WebClient())
            {
                string content = await client.DownloadStringTaskAsync(url);
                WriteLine(content.Substring(0, 200));
                WriteLine("koniec " + name + Environment.NewLine);
            }
        }

        private static void EventBasedAsyncPattern()
        {
            string name = nameof(EventBasedAsyncPattern); WriteLine("\t" + name);

            using (var client = new WebClient())
            {
                client.DownloadStringCompleted += (sender, e) =>
                {
                    WriteLine(e.Result.Substring(0, 200));
                };
                client.DownloadStringAsync(new Uri(url)); WriteLine("koniec " + name + Environment.NewLine);

            }
        }

        private static void AsynchronousPattern()
        {
            string name = nameof(AsynchronousPattern); WriteLine("\t" + name);
            WebRequest request = WebRequest.Create(url);
            IAsyncResult result = request.BeginGetResponse(ReadResponse, null);

            void ReadResponse(IAsyncResult ar)
            {
                using (WebResponse response = request.EndGetResponse(ar))
                {
                    Stream stream = response.GetResponseStream();
                    var reader = new StreamReader(stream);
                    string content = reader.ReadToEnd(); WriteLine(content.Substring(0, 200));

                }
                WriteLine("koniec " + name + Environment.NewLine);
            }

        }
        private static void SynchronizedAPI()
        {
            string name = nameof(SynchronizedAPI);
            WriteLine("\t" + name); using (var client = new WebClient())
            {
                string content = client.DownloadString(url);
                WriteLine(content.Substring(0, 200));
            }
            WriteLine("koniec " + name + Environment.NewLine);
        }
    }
}