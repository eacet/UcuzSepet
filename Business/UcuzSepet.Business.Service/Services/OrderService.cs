using Microsoft.Extensions.Logging;
using UcuzSepet.Business.Service.IServices;
using UcuzSepet.Data.Domain.Entities;
using UcuzSepet.Data.EF.Components;

namespace UcuzSepet.Business.Service.Services {

    /// <summary>
    /// Order Service for Access Order entities
    /// </summary>
    public class OrderService : BaseService<Order>, IOrderService {
        public OrderService(IEFBaseRepository<Order> repository, ILogger<Order> logger)
            : base(repository, logger) { }
    }
}
