using Microsoft.EntityFrameworkCore;
using tryitter.Database;
using tryitter.DTO;
using tryitter.Interfaces;
using tryitter.Models;

namespace tryitter.Repository
{
    public class FornecedorRepository : IFornecedorRepository
    {
        protected readonly AplicationContext _context;

        public FornecedorRepository(AplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FornecedorDTO>> GetFornecedores()
        {
            var fornecedores = await _context.Fornecedor
                .Select(s => new FornecedorDTO
                {
                    FornecedorId = s.FornecedorId,
                    NomeFantasia = s.NomeFantasia,
                    Telefone = s.Telefone,
                    Email = s.Email,
                    CNPJ = s.CNPJ,
                    RazaoSocial = s.RazaoSocial
                }).ToListAsync();

            return fornecedores;
        }

        public async Task<IEnumerable<FornecedorDTO>> GetFornecedoresWithPosts()
        {
            var fornecedores = await _context.Fornecedor
                .Select(s => new FornecedorDTO
                {
                    FornecedorId = s.FornecedorId,
                    NomeFantasia = s.NomeFantasia,
                    Telefone = s.Telefone,
                    Email = s.Email,
                    CNPJ = s.CNPJ,
                    RazaoSocial = s.RazaoSocial

                }).ToListAsync();

            return fornecedores;
        }

        public async Task<FornecedorDTO> GetFornecedorById(int id)
        {
            var fornecedor = await _context.Fornecedor.Where(s => s.FornecedorId == id)
                .Select(s => new FornecedorDTO
                {
                    FornecedorId = s.FornecedorId,
                    NomeFantasia = s.NomeFantasia,
                    Telefone = s.Telefone,
                    Email = s.Email,
                    CNPJ = s.CNPJ,
                    RazaoSocial = s.RazaoSocial
                }).FirstOrDefaultAsync();

            return fornecedor;
        }

        public async Task<FornecedorDTO> GetFornecedorByIdWithPost(int id)
        {

            var fornecedor = await _context.Fornecedor
                .Where(x => x.FornecedorId == id)
                .Select(s => new FornecedorDTO
                {
                    FornecedorId = s.FornecedorId,
                    NomeFantasia = s.NomeFantasia,
                    Telefone = s.Telefone,
                    Email = s.Email,
                    CNPJ = s.CNPJ,
                    RazaoSocial = s.RazaoSocial

                }).FirstOrDefaultAsync();

            return fornecedor;
        }

        public async Task<FornecedorDTO> GetFornecedorByRazaoSocial(string name)
        {
            var fornecedor = await _context.Fornecedor.Where(s => s.RazaoSocial == name)
                .Select(s => new FornecedorDTO
                {
                    FornecedorId = s.FornecedorId,
                    NomeFantasia = s.RazaoSocial
                }).FirstOrDefaultAsync();

            return fornecedor;
        }

        public async Task<string> GetFornecedorByEmail(string email)
        {
            var fornecedor = await _context.Fornecedor.Where(s => s.Email == email)
                .Select(s => s.Email).FirstOrDefaultAsync();

            return fornecedor;
        }
        public async Task<FornecedorDTO> CreateFornecedor(Fornecedor fornecedor)
        {
            await _context.Fornecedor.AddAsync(fornecedor);
            _context.SaveChanges();

            return new FornecedorDTO
            {
                RazaoSocial = fornecedor.RazaoSocial
            };
        }

        public async Task<FornecedorDTO> UpdateFornecedor(Fornecedor newFornecedor, int fornecedorId)
        {
            var fornecedor = await _context.Fornecedor.FindAsync(fornecedorId);

            fornecedor.NomeFantasia = newFornecedor.NomeFantasia;
            fornecedor.CNPJ = newFornecedor.CNPJ;
            fornecedor.Telefone = newFornecedor.Telefone;
            fornecedor.Email = newFornecedor.Email;
            fornecedor.RazaoSocial = newFornecedor.RazaoSocial;
            
            _context.SaveChanges();

            return new FornecedorDTO
            {
                NomeFantasia = newFornecedor.NomeFantasia,
                Telefone = newFornecedor.Telefone,
                Email = newFornecedor.Email,
                CNPJ = newFornecedor.CNPJ,
                RazaoSocial = newFornecedor.RazaoSocial
            };
        }

        public void DeleteFornecedor(int forneceddorId)
        {
            var fornecedor = _context.Fornecedor.Find(forneceddorId);

            if (fornecedor is null)
            {
                throw new Exception("Student not found");
            }

            _context.Fornecedor.Remove(fornecedor);
            _context.SaveChanges();
        }
    }
}
