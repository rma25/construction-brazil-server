using construction_brazil_server.DataStores;
using construction_brazil_server.Dtos.Admin;
using construction_brazil_server.Dtos.Filters;
using construction_brazil_server.Entities.Logs;
using construction_brazil_server.Extensions;
using construction_brazil_server.Extensions.IQueryables;
using Microsoft.EntityFrameworkCore;

namespace construction_brazil_server.Interfaces
{
    public class ProfissionalRepository : IProfissionalRepository
    {
        private readonly ConstructionBrazil_Context _context;
        private readonly IEnderecoRepository _enderecoRepo;
        private readonly IContatoRepository _contatoRepo;
        public ProfissionalRepository(ConstructionBrazil_Context context, IEnderecoRepository enderecoRepo, IContatoRepository contatoRepo)
        {
            _context = context;
            _enderecoRepo = enderecoRepo;
            _contatoRepo = contatoRepo;
        }

        protected IQueryable<Profissional> GetAdminProfissionals(ProfissionalAdminFilterDto filter)
        {
            var startedOn = filter.StartedOn.StripDateAndTime(DateTimeOffset.MinValue);
            var endedOn = filter.EndedOn.StripDateAndTime(DateTimeOffset.MaxValue);

            var profissionals = _context.Profissionals
                                        .Include(x => x.Contato)
                                        .Include(x => x.Endereco)
                                        .ThenInclude(x => x.Estado)
                                        .Where(x => (startedOn <= x.Criado.Date && x.Criado.Date <= endedOn)
                                                    || (startedOn <= x.Contato.DataDeNascimento.Date && x.Contato.DataDeNascimento.Date <= endedOn));

            if (!string.IsNullOrEmpty(filter.SearchText))
            {
                var loweredText = filter.SearchText.ToLower();

                profissionals = profissionals.Where(x => x.Contato.Cpf.ToLower().Contains(loweredText)
                                                        || x.Contato.Nome.ToLower().Contains(loweredText)
                                                        || x.Contato.Sobrenome.ToLower().Contains(loweredText)
                                                        || (x.Contato.Telefone != null && x.Contato.Telefone.ToLower().Contains(loweredText))
                                                        || x.Endereco.Cep.ToLower().Contains(loweredText)
                                                        || (x.Endereco.Cidade != null && x.Endereco.Cidade.ToLower().Contains(loweredText))
                                                        || (x.Endereco.Estado != null && x.Endereco.Estado.Nome.ToLower().Contains(loweredText))
                                                        || (x.Endereco.Estado != null && x.Endereco.Estado.Uf.ToLower().Contains(loweredText))
                                                        || (x.Pis != null && x.Pis.ToLower().Contains(loweredText))
                                                        || (x.Pix != null && x.Pix.ToLower().Contains(loweredText)));
            }

            return profissionals;
        }

        public async Task<bool> Exists(long id)
        {
            if (id == 0)
                throw new ArgumentException($"{nameof(id)} is not valid.");

            return await _context.Profissionals.AnyAsync(x => x.ProfissionalId == id);
        }

        public async Task DeleteAsync(long id)
        {
            if (id == 0)
                throw new ArgumentException($"{nameof(id)} is not valid.");

            var profissionalFound = await _context.Profissionals.FindAsync(id);

            if (profissionalFound == null)
                throw new ArgumentNullException(nameof(profissionalFound));

            _context.Entry(profissionalFound).State = EntityState.Deleted;
            _context.Profissionals.Remove(profissionalFound);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();

            await _contatoRepo.DeleteAsync(profissionalFound.ContatoId);
            await _enderecoRepo.DeleteAsync(profissionalFound.EnderecoId);
        }

        public async Task<IEnumerable<AdminProfissionalDto>> GetAdminPageAsync(ProfissionalAdminFilterDto filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            var dtos = await GetAdminProfissionals(filter)
                            .Skip(filter.CurrentPage.SkipOver(filter.TotalPerPage))
                            .Take(filter.TotalPerPage)
                            .Select(x => new AdminProfissionalDto
                            {
                                Id = x.ProfissionalId,
                                Ativo = x.Ativo,
                                Sindicalizado = x.Sindicalizado,
                                Observacoes = x.Observacoes,
                                Pis = x.Pis,
                                Pix = x.Pix,
                                Rg = x.Rg,
                                ProfissionalTypeId = x.ProfissionalTypeId,
                                Contato = new AdminContatoDto
                                {
                                    Id = x.ContatoId,
                                    Cpf = x.Contato.Cpf,
                                    DataDeNascimento = x.Contato.DataDeNascimento,
                                    DddId = x.Contato.DddId,
                                    Nome = x.Contato.Nome,
                                    Profissao = x.Contato.Profissao,
                                    SexoId = x.Contato.SexoId,
                                    Sobrenome = x.Contato.Sobrenome,
                                    Telefone = x.Contato.Telefone,
                                    Email = x.Contato.Email
                                },
                                Endereco = new AdminEnderecoDto
                                {
                                    Id = x.EnderecoId,
                                    EstadoId = x.Endereco.EstadoId,
                                    Bairro = x.Endereco.Bairro,
                                    Cep = x.Endereco.Cep,
                                    Cidade = x.Endereco.Cidade,
                                    Complemento = x.Endereco.Complemento,
                                    Rua = x.Endereco.Rua
                                },
                                Criado = x.Criado,
                                Modificado = x.Modificado
                            })
                            .ToListAsync();

            return dtos;
        }

        public async Task<long> GetAdminTotalAsync(ProfissionalAdminFilterDto filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            var total = await GetAdminProfissionals(filter).CountAsync();

            return total;
        }

        public async Task<long> InsertAsync(AdminProfissionalDto profissional)
        {
            if (profissional == null)
                throw new ArgumentNullException(nameof(profissional));

            var contatoId = await _contatoRepo.InsertAsync(profissional.Contato);
            var enderecoId = await _enderecoRepo.InsertAsync(profissional.Endereco);

            var newProfissional = new Profissional()
            {
                Rg = profissional.Rg,
                Ativo = profissional.Ativo,
                Sindicalizado = profissional.Sindicalizado,
                Observacoes = profissional.Observacoes,
                Pis = profissional.Pis,
                Pix = profissional.Pix,
                Criado = DateTimeOffset.UtcNow
            };

            if (profissional.ProfissionalTypeId > 0)
                newProfissional.ProfissionalTypeId = profissional.ProfissionalTypeId;
            if (contatoId > 0)
                newProfissional.ContatoId = contatoId;
            if (enderecoId > 0)
                newProfissional.EnderecoId = enderecoId;

            _context.Entry(newProfissional).State = EntityState.Added;
            _context.Profissionals.Add(newProfissional);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();

            return newProfissional.ProfissionalId;
        }

        public async Task UpdateAsync(AdminProfissionalDto profissional)
        {
            if (profissional == null)
                throw new ArgumentNullException(nameof(profissional));

            var profissionalFound = await _context.Profissionals.FindAsync(profissional.Id);

            if (profissionalFound == null)
                throw new ArgumentNullException(nameof(profissionalFound));

            await _contatoRepo.UpdateAsync(profissional.Contato);
            await _enderecoRepo.UpdateAsync(profissional.Endereco);

            profissionalFound.Rg = profissional.Rg;
            profissionalFound.Ativo = profissional.Ativo;
            profissionalFound.Sindicalizado = profissional.Sindicalizado;
            profissionalFound.Observacoes = profissional.Observacoes;
            profissionalFound.Pis = profissional.Pis;
            profissionalFound.Pix = profissional.Pix;
            profissionalFound.Modificado = DateTimeOffset.UtcNow;

            if (profissional.ProfissionalTypeId > 0)
                profissionalFound.ProfissionalTypeId = profissional.ProfissionalTypeId;

            _context.Entry(profissionalFound).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }
    }
}
