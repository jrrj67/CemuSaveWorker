namespace CemuSaveWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger, IConfiguration config)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var path = @"C:\Games\cemu\mlc01\usr\save";

            var filter = "*";

            var monitor = new FileSystemWatcher(path, filter)
            {
                IncludeSubdirectories = true
            };

            monitor.Created += SaveMonitor.OnFileChanged;

            monitor.Changed += SaveMonitor.OnFileChanged;

            monitor.EnableRaisingEvents = true;

            Console.ReadLine();
        }
    }
}