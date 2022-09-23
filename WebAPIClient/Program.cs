
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
   private static readonly HttpClient _httpClient = new(); 

    private static async Task<List<Repositories>>  ProcessRepositories()
    {


        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        _httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

        /*
         The serializer automatically ignores JSON properties for which 
        there is no match in the target class. This feature makes it easier to create 
        types that work with only a subset of fields in a large JSON packet.
         */
        var streamTask = _httpClient.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");

        var repositories = await JsonSerializer.DeserializeAsync<List<Repositories>>(await streamTask);

        return repositories;

    }

   
    static async Task Main(string[] args)
    {

        List<Repositories> _repositories = await ProcessRepositories();
        List<(double, string)> l = new();
        foreach (var repo in _repositories)
        {
           string value = LevenshteinDistanceAlgorithm.LevenshteinDistance("This repo contains LLILC, an LLVM based compiler for .NET Core. It includes a set of cross-platform .NET code generation tools that enables compilation of MSIL byte code to LLVM supported platforms.\r\n", repo.Description);


            //string value = $"\n\n Last pushed: {repo.LastPush}\n name :{repo.Name}\n Homepage: {repo.Homepage}\n Descrition: {repo.Description}\n Watchers: {repo.Watchers}";
            l.Add((double.Parse(value), repo.Description));
        }
        l = l.OrderBy(p => p.Item1).ToList();
        l.ForEach(p => Console.WriteLine($"\n{p.Item1}: \n{p.Item2}"));

        Console.Read();

    }


}