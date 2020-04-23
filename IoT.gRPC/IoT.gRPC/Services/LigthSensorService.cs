using Grpc.Core;
using IoT.gRPC.kafka;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace IoT.gRPC
{
    public class LigthSensorService : LigthSensor.LigthSensorBase
    {
        private readonly ILogger<LigthSensorService> _logger;
        private readonly ICustomConsumer _consumer;
        private const string _topic = "IoT";

        public LigthSensorService(ILogger<LigthSensorService> logger, ICustomConsumer consumer)
        {
            _logger = logger;
            _consumer = consumer;
        }

        public override async Task GetLightSensorStream(LightSensorMessagesRequest request, IServerStreamWriter<LightSensorMessage> responseStream, ServerCallContext context)
        {
            while (!context.CancellationToken.IsCancellationRequested)
            {
                var message = await _consumer.GetMessage(context.CancellationToken);
                await responseStream.WriteAsync(new LightSensorMessage { Data = message.Data, Time = message.Time });
            }
        }
    }
}
