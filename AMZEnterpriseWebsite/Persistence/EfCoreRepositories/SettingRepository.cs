using AMZEnterpriseWebsite.Core.Domain;
using AMZEnterpriseWebsite.Data;
using AMZEnterpriseWebsite.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AMZEnterpriseWebsite.Persistence.EfCoreRepositories
{
    public class SettingRepository : ISettingRepository
    {
        private readonly IApplicationDbContext _context;
        public SettingRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Setting> Get()
        {
            return await _context.Settings.FirstOrDefaultAsync();
        }

        public void Update(Setting setting)
        {
            _context.Settings.Update(setting);
        }
    }
}
