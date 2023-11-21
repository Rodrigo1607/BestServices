// Repositories/ClienteRepository.cs
using CadastroCliente.Context;
using CadastroCliente.Models;
using CadastroCliente.Repositories;
using Microsoft.EntityFrameworkCore;

public class ClienteRepository : IClienteRepository
{
    private readonly ApplicationDbContext _context;

    public ClienteRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Cliente>> GetAllClientes()
    {
        return await _context.Clientes.ToListAsync();
    }

    public async Task<Cliente> GetClienteById(int id)
    {
        return  await _context.Clientes.FindAsync(id);
    }

    public async Task AddCliente(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCliente(Cliente cliente)
    {
        _context.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCliente(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task<Cliente> GetClienteByName(string name)
    {
        return await _context.Clientes.FirstOrDefaultAsync(c => c.Nome == name);
    }

    public async Task<Cliente> GetClienteByEmail(string email)
    {
        return  await _context.Clientes.FirstOrDefaultAsync(c => c.Email == email);
    }

    
}
