using Microsoft.EntityFrameworkCore;

namespace DataModel.Contracts
{
    public interface IEntity
    {
        void Configure(ModelBuilder modelBuilder);
    }
}
