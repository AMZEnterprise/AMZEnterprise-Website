using AMZEnterpriseWebsite.Core.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMZEnterpriseWebsite.Persistence.Repositories
{
    /// <summary>
    /// Represents progress bar repository interface 
    /// </summary>
    public interface IProgressBarRepository
    {
        /// <summary>
        /// Get all progressBars
        /// </summary>
        /// <returns>returns all progressBars</returns>
        IQueryable<ProgressBar> GetAll();
        /// <summary>
        /// Get a progressBar by id
        /// </summary>
        /// <param name="id">progressBar id</param>
        /// <returns>returns a specific progressBar or null</returns>
        Task<ProgressBar> GetById(int id);
        /// <summary>
        /// Insert new progressBar
        /// </summary>
        /// <param name="progressBar">new progressBar</param>
        Task Insert(ProgressBar progressBar);
        /// <summary>
        /// Update all existing progressBar
        /// </summary>
        /// <param name="progressBars">Updated progressBars as IEnumerable</param>
        void UpdateAll(IEnumerable<ProgressBar> progressBars);
        /// <summary>
        /// Delete a progressBar by id
        /// </summary>
        /// <param name="id">progressBar id</param>
        /// <returns></returns>
        Task Delete(int id);
        /// <summary>
        /// Count total contacts
        /// </summary>
        /// <returns>returns contacts count</returns>
        Task<int> Count();
    }
}
