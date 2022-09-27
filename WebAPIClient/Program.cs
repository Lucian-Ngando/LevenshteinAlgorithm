
#region using directives

using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;
 

#endregion

namespace WebAPIClient;

class Program
{
   //private static readonly HttpClient _httpClient = new(); 

   // private static async Task<List<Repositories>>  ProcessRepositories()
   // {


   //     _httpClient.DefaultRequestHeaders.Accept.Clear();
   //     _httpClient.DefaultRequestHeaders.Accept.Add(
   //         new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
   //     _httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

   //     /*
   //      The serializer automatically ignores JSON properties for which 
   //     there is no match in the target class. This feature makes it easier to create 
   //     types that work with only a subset of fields in a large JSON packet.
   //      */
   //     var streamTask = _httpClient.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");

   //     var repositories = await JsonSerializer.DeserializeAsync<List<Repositories>>(await streamTask);

   //     return repositories;

   // }

   
    static void Main(string[] args)
    {
        var newData = new StringData();
        List<(double, string)> l = new();
        List<(double, string)> r = new();
        string inputString = "  such as the negotiations";

        //List<Repositories> _repositories = await ProcessRepositories();
        //List<(double, string)> l = new();
        //foreach (var repo in _repositories)
        //{
        //   string value = LevenshteinDistanceAlgorithm.LevenshteinDistance("", repo.Description);


        //    //string value = $"\n\n Last pushed: {repo.LastPush}\n name :{repo.Name}\n Homepage: {repo.Homepage}\n Descrition: {repo.Description}\n Watchers: {repo.Watchers}";
        //    l.Add((double.Parse(value), repo.Description));
        //}

        //l = l.OrderBy(p => p.Item1).ToList();
        //l.ForEach(p => Console.WriteLine($"\n{p.Item1}: \n{p.Item2}"));

        //Console.Read();

        foreach (var item in newData.AllStringData())
        {
            
            string value = LevenshteinDistanceAlgorithm.LevenshteinDistance(inputString, item);


            l.Add((double.Parse(value), item));
            //Console.WriteLine("\n{0}\n",item);
            
        }

        ///<method WeightRespone()>{For strings that is shorter then the average string.lenght, put a variable length to balance
        ///out the string.length}</>
        ///
        double avg_dist = l.Average(p => p.Item1);
        double avg_chars = l.Average(p => p.Item2.Length);

        foreach (var item in l)
        {
            if (item.Item2.Length < avg_chars)
            {

               r.Add( (item.Item1 * 1.8, item.Item2));

            }
            else if (item.Item2.Contains($"{inputString}"))
            {
                r.Add((item.Item1 * 0.4, item.Item2));
            }
            else
            {
                r.Add((item.Item1, item.Item2));
            }

        }

        r = r.OrderBy(p => p.Item1).ToList();




        r.ForEach(p => Console.WriteLine($"\n{p.Item1}: \n{p.Item2}"));

        Console.Read();
    }


}