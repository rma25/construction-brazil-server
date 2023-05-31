using construction_brazil_server.DataStores;
using construction_brazil_server.Dtos.Admin;
using construction_brazil_server.Entities.Logs;
using Microsoft.EntityFrameworkCore;

namespace construction_brazil_server.Interfaces
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly ConstructionBrazil_Context _context;
        public EnderecoRepository(ConstructionBrazil_Context context)
        {
            _context = context;
        }

        public async Task DeleteAsync(long id)
        {
            if (id == 0)
                throw new ArgumentException($"{nameof(id)} is invalid.");

            var enderecoFound = await _context.Enderecos.FindAsync(id);

            if (enderecoFound == null)
                throw new ArgumentNullException(nameof(enderecoFound));

            _context.Entry(enderecoFound).State = EntityState.Deleted;
            _context.Enderecos.Remove(enderecoFound);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }

        public async Task<long> InsertAsync(AdminEnderecoDto endereco)
        {
            if (endereco == null)
                throw new ArgumentNullException(nameof(endereco));

            var newEndereco = new Endereco()
            {
                Bairro = endereco.Bairro,
                Cep = endereco.Cep,
                Cidade = endereco.Cidade,
                Complemento = endereco.Complemento,
                Rua = endereco.Rua,
                Criado = DateTimeOffset.UtcNow
            };

            if (endereco.EstadoId > 0)
                newEndereco.EstadoId = endereco.EstadoId;

            _context.Entry(newEndereco).State = EntityState.Added;
            _context.Enderecos.Add(newEndereco);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();

            return newEndereco.EnderecoId;
        }

        public async Task UpdateAsync(AdminEnderecoDto endereco)
        {
            if (endereco == null)
                throw new ArgumentNullException(nameof(endereco));

            var enderecoFound = await _context.Enderecos.FindAsync(endereco.Id);

            if (enderecoFound == null)
                throw new ArgumentNullException(nameof(enderecoFound));

            enderecoFound.Bairro = endereco.Bairro;
            enderecoFound.Cep = endereco.Cep;
            enderecoFound.Cidade = endereco.Cidade;
            enderecoFound.Complemento = endereco.Complemento;
            enderecoFound.Rua = endereco.Rua;
            enderecoFound.Modificado = DateTimeOffset.UtcNow;

            if (endereco.EstadoId > 0)
                enderecoFound.EstadoId = endereco.EstadoId;

            _context.Entry(enderecoFound).State = EntityState.Modified;            
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }
    }
}
