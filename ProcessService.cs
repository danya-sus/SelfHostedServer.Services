using AutoMapper;
using SelfHostedServer.Data;
using SelfHostedServer.Models.Entities;
using SelfHostedServer.ModelsDTO.ModelsDto;
using System;
using System.Threading.Tasks;

namespace SelfHostedServer.Services
{
    public class ProcessService : IProcessService
    {
        private readonly ITicketRepository Repository;
        private readonly IMapper Mapper;
        public ProcessService(ITicketRepository repository, IMapper mapper)
        {
            this.Repository = repository;
            this.Mapper = mapper;
        }

        public async Task SaleAsync(SaleDto ticket)
        {
            var delay = Task.Delay(1200000);

            var result = Repository.SaleAsync(Mapper.Map<Ticket>(ticket));

            if (await Task.WhenAny(result, delay) != delay)
            {
                await result;
            }
            else throw new TimeoutException();
        }

        public async Task RefundAsync(RefundDto refund)
        {
            var delay = Task.Delay(1200000);

            var result = Repository.RefundAsync(Mapper.Map<Refund>(refund));

            if (await Task.WhenAny(result, delay) != delay)
            {
                await result;
            }
            else throw new TimeoutException();
        }
    }
}
