using System.Threading;
using System.Threading.Tasks;
using Apartment.App.Web.Models.MailModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Apartment.App.Web.Background
{
    public class BackgroundWorker : BackgroundService
    {
        private readonly IBackgroundQueue<Mail> queue;
        private readonly IServiceScopeFactory serviceFactory;
        private readonly ILogger<BackgroundWorker> logger;

        public BackgroundWorker(IBackgroundQueue<Mail> queue, IServiceScopeFactory serviceFactory, ILogger<BackgroundWorker> logger)
        {
            this.queue = queue;
            this.serviceFactory = serviceFactory;
            this.logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation("{Type} is now running in the background.", nameof(BackgroundWorker));
            await BackgroundProcessing(stoppingToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogCritical("The {Type} is stopping due to a host shutdown, queued items might not be processed anymore.", nameof(BackgroundWorker));
            return base.StopAsync(cancellationToken);
        }

        private async Task BackgroundProcessing(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(500, stoppingToken);
                    var mail = queue.Dequeue();
                    if (mail == null) continue;

                    logger.LogInformation("Mail Found! Starting to process");
                    using (var scope = serviceFactory.CreateScope())
                    {
                        var sender = scope.ServiceProvider.GetRequiredService<IMailSendService>();
                        await sender.SendEmailAsync(mail , stoppingToken);
                    }
                }
                catch (System.Exception ex)
                {
                    logger.LogError("An Error when sending a message. Exception", ex);
                }
            }
        }
    }
}
