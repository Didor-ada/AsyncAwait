using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string url1 = "http://codeavecjonathan.com/res/dummy.txt";
            string url2 = "http://codeavecjonathan.com/res/pizzas1.json";

            Console.Write("Téléchargement...");
            var displayTask = DisplayProgress();
            var downloadTask1 = DownloadData(url1);
            var downloadTask2 = DownloadData(url2);

            // await downloadTask1; // on attend que downloadTask se termine pour terminer le programme
            // await downloadTask2; 
            await Task.WhenAll(downloadTask1, downloadTask2); // quand toutes les taches ici sont terminées, tu peux passer à la suite

            Console.WriteLine("Fin du programme");
        }


        static async Task DownloadData(string url) // task est équivalent au type Void, il ne retourne rien, si on veut return un string par exemple, on ferait Task<String>
        {
            var httpClient = new HttpClient();
            

            var resultat = await httpClient.GetStringAsync(url);      // quand on voit que la fonction retourne un type task c'est qu'on peut l'utiliser avec await




            Console.WriteLine("OK -> " + url);

            // Console.WriteLine(resultat);
        }


        static async Task DisplayProgress()
        {
            while(true)
            {
                await Task.Delay(500);
                Console.Write(".");
            }
        }
    }
}
