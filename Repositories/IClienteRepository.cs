using CadastroCliente.Models;

namespace CadastroCliente.Repositories
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetAllClientes();
        Task<Cliente> GetClienteById(int id);
        Task AddCliente(Cliente cliente);
        Task UpdateCliente(Cliente cliente);
        Task DeleteCliente(int id);
        Task<Cliente> GetClienteByName(string name);
        Task<Cliente> GetClienteByEmail(string email);
        
    }
}
