using AMZEnterpriseWebsite.Core.Domain;
using System.Threading.Tasks;

namespace AMZEnterpriseWebsite.Persistence.Repositories
{
    /// <summary>
    /// Represents setting repository interface 
    /// </summary>
    public interface ISettingRepository
    {
        /// <summary>
        /// Get setting
        /// </summary>
        /// <returns>returns setting</returns>
        Task<Setting> Get();
        /// <summary>
        /// Update setting
        /// </summary>
        /// <param name="setting">updated setting</param>
        void Update(Setting setting);
    }
}
