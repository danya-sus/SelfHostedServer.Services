using SelfHostedServer.Models.Entities;
using SelfHostedServer.ModelsDTO.ModelsDto;
using System.Threading.Tasks;

namespace SelfHostedServer.Services
{
    public interface IProcessService
    {
        Task SaleAsync(SaleDto ticket);
        Task RefundAsync(RefundDto refund);
    }
}
