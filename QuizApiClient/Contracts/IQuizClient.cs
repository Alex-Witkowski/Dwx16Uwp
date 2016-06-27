using System.Threading.Tasks;
using QuizApiClient.Model;

namespace QuizApiClient
{
    public interface IQuizClient
    {
        Task<SearchResult> SearchForSetsAsync(string searchTerm);
        Task<Set> GetSetAsync(int setId);
    }
}