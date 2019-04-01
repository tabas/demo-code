using Microsoft.EntityFrameworkCore;

namespace NovaXSoft.API.DataAccess.Abstraction.Repository
{
    public interface IBaseRepository
    {
        void SetContext(DbContext context);
    }
}
