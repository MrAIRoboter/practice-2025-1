using System;
using System.Text;
using System.Threading;
using Hydroponics.Application;
using Microsoft.Extensions.Hosting;

namespace Hydroponics.ESP32_C3.Services.Background
{
    public sealed class HydroponicService : BackgroundService
    {
        private readonly Hydroponic _hydroponic;

        public HydroponicService(Hydroponic hydroponic)
        {
            _hydroponic = hydroponic;
        }

        protected override void ExecuteAsync(CancellationToken stoppingToken)
        {
            _hydroponic.Run(stoppingToken);
        }
    }
}
