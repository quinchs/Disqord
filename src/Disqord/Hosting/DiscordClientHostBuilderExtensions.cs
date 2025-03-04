using System;
using System.ComponentModel;
using System.Linq;
using Disqord.DependencyInjection.Extensions;
using Disqord.Gateway.Api.Default;
using Disqord.Gateway.Api.Models;
using Disqord.Gateway.Default;
using Disqord.Gateway.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Disqord.Hosting
{
    public static class DiscordClientHostBuilderExtensions
    {
        public static IHostBuilder ConfigureDiscordClient(this IHostBuilder builder, Action<HostBuilderContext, DiscordClientHostingContext> configure = null)
        {
            builder.ConfigureServices((context, services) =>
            {
                var discordContext = new DiscordClientHostingContext();
                configure?.Invoke(context, discordContext);

                services.AddDiscordClient();
                services.AddHostedService<DiscordClientRunnerService>();
                services.ConfigureDiscordClient(context, discordContext);
            });

            return builder;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void ConfigureDiscordClient(this IServiceCollection services, HostBuilderContext context, DiscordClientHostingContext discordContext)
        {
            if (!services.Any(x => x.ServiceType == typeof(Token)))
                services.AddToken(Token.Bot(discordContext.Token));

            if (discordContext.Intents != null)
                services.Configure<DefaultGatewayApiClientConfiguration>(x => x.Intents = discordContext.Intents.Value);

            services.Configure<DefaultGatewayDispatcherConfiguration>(x => x.ReadyEventDelayMode = discordContext.ReadyEventDelayMode);

            services.TryAddSingleton<DiscordClientMasterService>();
            services.AddHostedService(x => x.GetRequiredService<DiscordClientMasterService>());

            var serviceAssemblies = discordContext.ServiceAssemblies;
            if (serviceAssemblies != null)
            {
                for (var i = 0; i < serviceAssemblies.Count; i++)
                {
                    var types = serviceAssemblies[i].GetExportedTypes();
                    foreach (var type in types)
                    {
                        if (type.IsAbstract)
                            continue;

                        if (!typeof(DiscordClientService).IsAssignableFrom(type))
                            continue;

                        var hasService = false;
                        for (var j = 0; j < services.Count; j++)
                        {
                            var service = services[j];
                            if (service.ServiceType != type && (service.ServiceType != typeof(IHostedService) || service.GetImplementationType() != type))
                                continue;

                            hasService = true;
                            break;
                        }

                        if (hasService)
                            continue;

                        services.AddDiscordClientService(type);
                    }
                }
            }

            if (discordContext.Status != null || discordContext.Activities != null)
            {
                services.Configure<DefaultGatewayApiClientConfiguration>(x => x.Presence = new UpdatePresenceJsonModel
                {
                    Status = discordContext.Status ?? UserStatus.Online,
                    Activities = discordContext.Activities?.Select(x => x.ToModel()).ToArray() ?? Array.Empty<ActivityJsonModel>()
                });
            }
        }
    }
}
