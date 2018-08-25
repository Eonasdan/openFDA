using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using JetBrains.Annotations;
using OpenFDA.Drug.Label;
using OpenFDA.Extensions;

namespace OpenFDA.Drug
{
    [UsedImplicitly]
    public class DrugClient : IDisposable
    {
        private static readonly Uri SearchApi = new Uri("/drug/label.json", UriKind.Relative);

        protected readonly HttpClient HTTPClient;
        private string ApiKey { get; }

        public DrugClient()
        {
            HTTPClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.fda.gov")
            };
        }

        public DrugClient(string apiKey) : this()
        {
            ApiKey = apiKey;
        }

        [System.Diagnostics.Contracts.Pure]
        [UsedImplicitly]
        public async Task<Search> SearchAsync(SearchOptions searchOptions, PaginationOptions pagingOptions = null)
        {
            var parameterDictionary = new List<KeyValuePair<string, string>>();
            if (pagingOptions == null) pagingOptions = new PaginationOptions();

            parameterDictionary.Add(new KeyValuePair<string, string>("search", searchOptions.ToQuery()));

            if (pagingOptions.Limit != 0)
            {
                parameterDictionary.Add(new KeyValuePair<string, string>("limit", pagingOptions.Limit.ToString()));
            }
            if (pagingOptions.Skip != 0)
            {
                parameterDictionary.Add(new KeyValuePair<string, string>("skip", pagingOptions.Skip.ToString()));
            }

            if (!string.IsNullOrEmpty(ApiKey))
                parameterDictionary.Add(new KeyValuePair<string, string>("api_key", ApiKey));


            var requestUri = new Uri($"{SearchApi}?{parameterDictionary.FlattenQueryString()}", UriKind.Relative);

            var result = await HTTPClient.GetAsync(requestUri);
            //result.EnsureSuccessStatusCode();

            var json = await result.Content.ReadAsStringAsync();

            return Search.FromJson(json);
        }

        public void Dispose()
        {
            HTTPClient?.Dispose();
        }
    }
}
