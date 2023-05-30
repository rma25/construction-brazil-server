using construction_brazil_server.Dtos.Admin;
using construction_brazil_server.Dtos.Filters;
using construction_brazil_server.Interfaces.Shared;

namespace construction_brazil_server.Interfaces
{
    public interface IProfissionalRepository : IRepository
    {
        /// <summary>
        /// Checks to see if Profissional exists
        /// </summary>
        /// <param name="id">Profissional Id</param>
        /// <returns>Message if it can't be deleted</returns>
        public Task<bool> Exists(long id);

        /// <summary>
        /// Gets all the profissionals based on the filter
        /// </summary>
        /// <param name="filter">Filters the collections</param>
        /// <returns>Collection of Admin Profissionals</returns>
        public Task<IEnumerable<AdminProfissionalDto>> GetAdminPageAsync(ProfissionalAdminFilterDto filter);

        /// <summary>
        /// Gets total count of all admins based on the filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Total Admins</returns>
        public Task<long> GetAdminTotalAsync(ProfissionalAdminFilterDto filter);

        /// <summary>
        /// Updates the profissional info
        /// </summary>
        /// <param name="profissional"></param>
        /// <returns></returns>
        public Task UpdateAsync(AdminProfissionalDto profissional);

        /// <summary>
        /// Add the profissional to the database
        /// </summary>
        /// <param name="profissional"></param>
        /// <returns>New Profissional Id</returns>
        public Task<long> InsertAsync(AdminProfissionalDto profissional);

        /// <summary>
        /// Deletes the Profissional based on the id
        /// </summary>
        /// <param name="id">Profissional Id</param>
        /// <returns></returns>
        public Task DeleteAsync(long id);
    }
}
