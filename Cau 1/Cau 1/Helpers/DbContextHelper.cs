using Cau_1.Models;
using Microsoft.EntityFrameworkCore;

namespace Cau_1.Helpers
{
    public static class DbContextHelper
    {
        public static QlChiTieuContext GetContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<QlChiTieuContext>();
            optionsBuilder.UseSqlServer(AppConfig.GetConnectionString());
            return new QlChiTieuContext(optionsBuilder.Options);
        }
    }
}
