namespace SubscriberPDF.Infrastructure.MassTransit;

using System.Security.Authentication;
using global::MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SubscriberPDF.Infrastructure.MassTransit.Files.Consumers;

internal static class DependencyInjection
{
    public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
    {
        var rabbitMqOptions = configuration.GetSection(RabbitMqOptions.SectionName).Get<RabbitMqOptions>();
        rabbitMqOptions ??= new RabbitMqOptions();

        services.AddMassTransit(configure =>
        {
            configure.AddConsumer<ProcessNewFileConsumer>().Endpoint(endpoint => endpoint.InstanceId = "subscriberPDF");

            configure.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host(rabbitMqOptions.HostName, rabbitMqOptions.Port, rabbitMqOptions.VirtualHost, host =>
                {
                    host.Password(rabbitMqOptions.Password);
                    host.Username(rabbitMqOptions.User);

                    if (rabbitMqOptions.UseSsl)
                    {
                        host.UseSsl(ssl => ssl.Protocol = SslProtocols.Tls12 | SslProtocols.Tls13);
                    }
                });

                configurator.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}
