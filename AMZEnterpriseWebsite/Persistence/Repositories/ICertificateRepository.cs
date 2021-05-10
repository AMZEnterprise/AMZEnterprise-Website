using AMZEnterpriseWebsite.Models;
using System.Linq;
using System.Threading.Tasks;
using AMZEnterpriseWebsite.Core.Domain;

namespace AMZEnterpriseWebsite.Persistence.Repositories
{
    /// <summary>
    /// Represents certificate repository interface 
    /// </summary>
    public interface ICertificateRepository
    {
        /// <summary>
        /// Get all certificates
        /// </summary>
        /// <returns>returns all certificates</returns>
        IQueryable<Certificate> GetAll();
        /// <summary>
        /// Get a certificate by id
        /// </summary>
        /// <param name="id">certificate id</param>
        /// <returns>returns a specific certificate or null</returns>
        Task<Certificate> GetById(int id);
        /// <summary>
        /// Insert new certificate
        /// </summary>
        /// <param name="certificate">new certificate</param>
        void Insert(Certificate certificate);
        /// <summary>
        /// Update existing certificate
        /// </summary>
        /// <param name="certificate">updated certificate</param>
        void Update(Certificate certificate);
        /// <summary>
        /// Delete a certificate by id
        /// </summary>
        /// <param name="id">certificate id</param>
        /// <returns></returns>
        Task Delete(int id);
        /// <summary>
        /// Count total certificates
        /// </summary>
        /// <returns>returns certificates count</returns>
        Task<int> Count();
    }
}
