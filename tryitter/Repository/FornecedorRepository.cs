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
            var students = await _context.Fornecedor
                .Select(s => new FornecedorDTO
                {
                    FornecedorId = s.FornecedorId,
                    NomeFantasia = s.RazaoSocial
                }).ToListAsync();

            return students;
        }

        public async Task<IEnumerable<FornecedorDTO>> GetFornecedoresWithPosts()
        {
            var students = await _context.Fornecedor
                .Select(s => new FornecedorDTO
                {
                    FornecedorId = s.FornecedorId,
                    RazaoSocial = s.RazaoSocial,
                    CNPJ= s.CNPJ,
                    Email= s.Email,
                    NomeFantasia= s.NomeFantasia,
                    Telefone= s.Telefone,
                   
                }).ToListAsync();

            return students;
        }

        public async Task<FornecedorDTO> GetFornecedorById(int id)
        {
            var student = await _context.Fornecedor.Where(s => s.FornecedorId == id)
                .Select(s => new FornecedorDTO
                {
                    FornecedorId = s.FornecedorId,
                    NomeFantasia = s.RazaoSocial
                }).FirstOrDefaultAsync();

            return student;
        }

        public async Task<FornecedorDTO> GetFornecedorByIdWithPost(int id)
        {

            var student = await _context.Fornecedor
                .Where(x => x.FornecedorId == id)
                .Select(s => new FornecedorDTO
                {
                    FornecedorId = s.FornecedorId,
                    RazaoSocial = s.RazaoSocial,
                    CNPJ = s.CNPJ,
                    Email = s.Email,
                    NomeFantasia = s.NomeFantasia,
                    
                }).FirstOrDefaultAsync();

            return student;
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
            var student = await _context.Fornecedor.FindAsync(fornecedorId);

            student.RazaoSocial = newFornecedor.RazaoSocial;
            _context.SaveChanges();

            return new FornecedorDTO
            {
                RazaoSocial = newFornecedor.RazaoSocial
            };
        }

        public void DeleteFornecedor(int studentId)
        {
            var student = _context.Fornecedor.Find(studentId);

            if (student is null)
            {
                throw new Exception("Student not found");
            }

            _context.Fornecedor.Remove(student);
            _context.SaveChanges();
        }
    }
}
