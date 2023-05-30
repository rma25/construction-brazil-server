using construction_brazil_server.DataStores;
using construction_brazil_server.Dtos.Admin;
using construction_brazil_server.Entities.Logs;
using Microsoft.EntityFrameworkCore;

namespace construction_brazil_server.Interfaces
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly ConstructionBrazil_Context _context;
        public ContatoRepository(ConstructionBrazil_Context context)
        {
            _context = context;
        }

        public async Task DeleteAsync(long id)
        {
            if (id == 0)
                throw new ArgumentException($"{nameof(id)} is invalid.");

            var contatoFound = await _context.Contatos.FindAsync(id);

            if (contatoFound == null)
                throw new ArgumentNullException(nameof(contatoFound));

            _context.Entry(contatoFound).State = EntityState.Deleted;
            _context.Contatos.Remove(contatoFound);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }

        public async Task<long> InsertAsync(AdminContatoDto contato)
        {
            if (contato == null)
                throw new ArgumentNullException(nameof(contato));

            var newContato = new Contato()
            {
                Cpf = contato.Cpf,
                Nome = contato.Nome,
                Sobrenome = contato.Sobrenome,
                DataDeNascimento = contato.DataDeNascimento,
                Email = contato.Email,
                Telefone = contato.Telefone,
                Profissao = contato.Profissao,
                Criado = DateTimeOffset.UtcNow
            };

            if (contato.DddId > 0)
                newContato.DddId = contato.DddId;
            if (contato.SexoId > 0)
                newContato.SexoId = contato.SexoId;

            _context.Entry(newContato).State = EntityState.Added;
            _context.Contatos.Add(newContato);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();

            return newContato.ContatoId;
        }

        public async Task<bool> IsCpfUniqueAsync(string cpf, long contatoId = 0)
        {
            if (string.IsNullOrEmpty(cpf))
                throw new ArgumentNullException(nameof(cpf));

            var isUnique = false;

            if (contatoId > 0)
                isUnique = !await _context.Contatos.AnyAsync(x => x.Cpf.ToLower() == cpf.ToLower() && x.ContatoId == contatoId);
            else
                isUnique = !await _context.Contatos.AnyAsync(x => x.Cpf.ToLower() == cpf.ToLower());

            return isUnique;
        }

        public async Task UpdateAsync(AdminContatoDto contato)
        {
            if (contato == null)
                throw new ArgumentNullException(nameof(contato));

            var contatoFound = await _context.Contatos.FindAsync(contato.Id);

            if (contatoFound == null)
                throw new ArgumentNullException(nameof(contatoFound));

            contatoFound.Cpf = contato.Cpf;
            contatoFound.Nome = contato.Nome;
            contatoFound.Sobrenome = contato.Sobrenome;
            contatoFound.DataDeNascimento = contato.DataDeNascimento;
            contatoFound.Email = contato.Email;
            contatoFound.Telefone = contato.Telefone;
            contatoFound.Profissao = contato.Profissao;
            contatoFound.Modificado = DateTimeOffset.UtcNow;

            if (contato.DddId > 0)
                contatoFound.DddId = contato.DddId;
            if (contato.SexoId > 0)
                contatoFound.SexoId = contato.SexoId;

            _context.Entry(contatoFound).State = EntityState.Modified;
            _context.Contatos.Add(contatoFound);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }
    }
}
