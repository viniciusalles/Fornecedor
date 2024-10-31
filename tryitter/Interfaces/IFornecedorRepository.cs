using tryitter.DTO;
using tryitter.Models;

namespace tryitter.Interfaces
{
    public interface IFornecedorRepository
    {
        Task<IEnumerable<FornecedorDTO>> GetFornecedores();
        Task<IEnumerable<FornecedorDTO>> GetFornecedoresWithPosts();
        Task <FornecedorDTO> GetFornecedorByIdWithPost(int id);
        Task<FornecedorDTO> GetFornecedorById(int id);
        Task<FornecedorDTO> GetFornecedorByRazaoSocial(string razaosocial);
        Task<string> GetFornecedorByEmail(string email);
        Task <FornecedorDTO> CreateFornecedor(Fornecedor fornecedor);
        Task <FornecedorDTO> UpdateFornecedor(Fornecedor fornecedor, int fornecedorId);
        void DeleteFornecedor(int id);
    }
}
