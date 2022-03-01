namespace FD.ShortUrl.Api
{
    public class SampleHostedService : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken) =>
            Task.Run(()=>Console.WriteLine("StartAsync"));

        public Task StopAsync(CancellationToken cancellationToken)
            => Task.Run(()=> () => Console.WriteLine("StopAsync"));
    }
}
