using construction_brazil_server.Dtos.Admin;
using construction_brazil_server.Interfaces.Shared;

namespace construction_brazil_server.Interfaces
{
    public interface IContatoRepository : IRepository
    {
        /// <summary>
        /// Checks if CPF is unique
        /// </summary>
        /// <param name="cpf">CPF to be checked</param>
        /// <param name="contatoId">Check to make sure it's not checking against itself, if set to 0 will assume it's a new one</param>
        /// <returns>True if it's unique</returns>
        public Task<bool> IsCpfUniqueAsync(string cpf, long contatoId = 0);

        /// <summary>
        /// Updates contato
        /// </summary>
        /// <param name="contato"></param>
        /// <returns></returns>
        public Task UpdateAsync(AdminContatoDto? contato);

        /// <summary>
        /// Adds a new contato
        /// </summary>
        /// <param name="contato"></param>
        /// <returns>New Contato Id</returns>
        public Task<long> InsertAsync(AdminContatoDto? contato);

        /// <summary>
        /// Deletes contato based on the id
        /// </summary>
        /// <param name="id">Contato Id</param>
        /// <returns></returns>
        public Task DeleteAsync(long id);
    }
}
