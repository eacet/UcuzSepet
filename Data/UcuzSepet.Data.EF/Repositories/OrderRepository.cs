using Microsoft.EntityFrameworkCore;
using UcuzSepet.Data.Domain.Entities;
using UcuzSepet.Data.EF.Components;
using UcuzSepet.Data.EF.IRepositories;

namespace UcuzSepet.Data.EF.Repositories {
    /// <summary>
    /// Order Repository for Order Access
    /// </summary>
    public class OrderRepository : EFBaseRepository<Order>, IOrderRepository {
        public OrderRepository(DbContext context)
            : base(context) { }
    }
}
