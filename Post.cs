using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatically_place_bets
{
    public class Post
    {
        public async Task<string> PostWithHeadersAsync(string url, string jsonData, Dictionary<string, string> headers)
        {
            using (var client = new HttpClient())
            {
                // Add headers to HttpClient
                foreach (var header in headers)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);

                if (response.Content != null)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return responseContent;
                }
            }

            return string.Empty;
        }
    }
}
