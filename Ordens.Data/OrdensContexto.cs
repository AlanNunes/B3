using Microsoft.EntityFrameworkCore;

namespace Ordens.Data
{
    public class OrdensContexto : DbContext
    {
        public OrdensContexto(DbContextOptions<OrdensContexto> options) : base(options) { }
    }
}
