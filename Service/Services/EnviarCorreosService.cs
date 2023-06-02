using Microsoft.Extensions.Hosting;
using Repository.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EnviarCorreoService : IHostedService, IDisposable
    {
        private Timer _timer;
        private int horaProgramada = 8; // puedes cambiar este valor según lo que necesites


        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(EnviarCorreo, null, TiempoHastaLaHoraProgramada(), TimeSpan.FromDays(1));
            return Task.CompletedTask;
        }

        private void EnviarCorreo(object state)
        {
            
        }

        private TimeSpan TiempoHastaLaHoraProgramada()
        {
            DateTime ahora = DateTime.Now;
            DateTime horaProgramadaHoy = DateTime.Today.AddHours(horaProgramada);
            if (ahora > horaProgramadaHoy)
            {
                horaProgramadaHoy = horaProgramadaHoy.AddDays(1);
            }
            return horaProgramadaHoy - ahora;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }

}
