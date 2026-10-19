using Cau_3.Models;
using Microsoft.EntityFrameworkCore;

namespace Cau_3.Helpers
{
    public static class DbContextHelper
    {
        public static QlDaNgoaiContext GetContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<QlDaNgoaiContext>();
            optionsBuilder.UseSqlServer(AppConfig.GetConnectionString());
            return new QlDaNgoaiContext(optionsBuilder.Options);
        }
    }
}
