using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbit.Infra.IoC
{
    public class ContainerRegistory
    {
        public static void Reister(IServiceCollection services){
            services.AddTransient<IEventBus,RabbitMQBus>();
        }
    }
}