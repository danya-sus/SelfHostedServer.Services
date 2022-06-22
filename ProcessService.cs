using SelfHostedServer.Data;
using SelfHostedServer.Models.Entities;
using System;
using System.Threading.Tasks;

namespace SelfHostedServer.Services
{
    public class ProcessService : IProcessService
    {
        private readonly ITicketRepository Repository;
        public ProcessService(ITicketRepository repository)
        {
            this.Repository = repository;
        }

        public async Task SaleAsync(Ticket ticket)
        {
            var delay = Task.Delay(1200000);

            var result = Repository.SaleAsync(ticket);

            if (await Task.WhenAny(result, delay) != delay)
            {
                await result;
            }
            else throw new TimeoutException();
        }

        public async Task RefundAsync(Refund refund)
        {
            var delay = Task.Delay(1200000);

            var result = Repository.RefundAsync(refund);

            if (await Task.WhenAny(result, delay) != delay)
            {
                await result;
            }
            else throw new TimeoutException();
        }
    }
}
