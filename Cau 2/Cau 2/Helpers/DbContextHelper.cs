using Cau_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Cau_2.Helpers
{
    public static class DbContextHelper
    {
        public static QlNhaTroContext GetContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<QlNhaTroContext>();
            optionsBuilder.UseSqlServer(AppConfig.GetConnectionString());
            return new QlNhaTroContext(optionsBuilder.Options);
        }
    }
}
