using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QuizApiClient.Model;

namespace QuizApiClient
{
    public class QuizletApiClient  : IQuizClient
    {
        private readonly string clientId;
        private HttpClient client;
        private const string BaseAddress = "https://api.quizlet.com/2.0/";

        public QuizletApiClient(IQuizletApiSettings settings)
        {
            this.clientId = settings.ClientId;
            this.client = new HttpClient();
            this.client.BaseAddress = new Uri(BaseAddress);
        }

        public async Task<SearchResult> SearchForSetsAsync(string searchTerm)
        {
            var response = await this.client.GetStringAsync($"search/sets?q={searchTerm}&client_id={this.clientId}").ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<SearchResult>(response);
            return result;
        }

        public async Task<Set> GetSetAsync(int setId)
        {
            var response = await this.client.GetStringAsync($"sets/{setId}?client_id={this.clientId}").ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<Set>(response);
            return result;
        }

    }
}
