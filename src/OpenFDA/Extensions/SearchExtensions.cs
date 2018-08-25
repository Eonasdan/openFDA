using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using OpenFDA.Drug.Label;

namespace OpenFDA.Extensions
{
    public static class SearchExtensions
    {
        public static string ToQuery(this SearchOptions searchOptions)
        {
            var search = new StringBuilder();
            searchOptions.GetType().GetProperties().ToList().ForEach(x =>
            {
                var value = x.GetValue(searchOptions);
                if (value == null) return;

                var att = (JsonPropertyAttribute)x.GetCustomAttributes().FirstOrDefault(z => (Type) z.TypeId == typeof(JsonPropertyAttribute));
                
                if (value.GetType() == typeof(List<string>))
                {
                    search.Append(string.Join("+", (value as List<string>).Select(y => $"{att.PropertyName}:\"{y}\"")));
                }
                else
                {
                    search.Append($"{att.PropertyName}:\"{value}\"");
                }

                search.Append("+AND+");
            });

            return search.ToString().Trim("+AND+".ToCharArray());
        }
    }
}
