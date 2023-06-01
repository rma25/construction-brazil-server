using construction_brazil_server.Dtos.Admin;
using construction_brazil_server.Interfaces.Shared;

namespace construction_brazil_server.Interfaces
{
    public interface IEnderecoRepository : IRepository
    {              
        /// <summary>
        /// Updates Endereco
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns></returns>
        public Task UpdateAsync(AdminEnderecoDto? endereco);

        /// <summary>
        /// Adds a new Endereco
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns>New Endereco Id</returns>
        public Task<long> InsertAsync(AdminEnderecoDto? endereco);

        /// <summary>
        /// Deletes the Endereco based on the Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteAsync(long id);
    }
}
