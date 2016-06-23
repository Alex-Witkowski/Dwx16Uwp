using System.Threading.Tasks;

namespace Dwx16Workshop.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}