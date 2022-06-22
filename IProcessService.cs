using SelfHostedServer.Models.Entities;
using System.Threading.Tasks;

namespace SelfHostedServer.Services
{
    public interface IProcessService
    {
        Task SaleAsync(Ticket ticket);
        Task RefundAsync(Refund refund);
    }
}
