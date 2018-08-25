using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenFDA.Drug;
using OpenFDA.Drug.Label;

namespace OpenFDA.Sample
{
    public class Program
    {
        private static async Task Main(string[] args)
        {
            var drugClient = new DrugClient();
            var searchAsync = await drugClient.SearchAsync(new SearchOptions
            {
                BrandNames = new List<string>
                {
                    "zyrtec",
                    //"claritin"
                },
                WhenUsing = "drowsiness"
            });
            var a = 1;
            searchAsync = await drugClient.SearchAsync(new SearchOptions
            {
                WhenUsing = "drowsiness"
            });
            a = 1;
        }
    }
}
