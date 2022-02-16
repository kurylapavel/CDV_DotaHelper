using DataModel.OpenDota;
using System.Threading.Tasks;

namespace Business.Parser
{
    public interface IParserService
    {
        Task Parse();
    }
}
