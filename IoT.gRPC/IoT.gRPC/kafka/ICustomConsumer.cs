using System.Threading;
using System.Threading.Tasks;

namespace IoT.gRPC.kafka
{
    public interface ICustomConsumer
    {
        public Task<LSData> GetMessage(CancellationToken ct);
    }
}
