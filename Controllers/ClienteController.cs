// Controllers/ClienteController.cs
using CadastroCliente.Models;
using CadastroCliente.Repositories;
using CadastroCliente.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : Controller
{
    private readonly IClienteRepository _clienteRepository;

    public Cliente model = new Cliente();

    public ClienteController(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    [HttpGet("todos")]
    public async Task<IEnumerable<Cliente>> GetAllClientes()
    {
        return await _clienteRepository.GetAllClientes();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetClienteById(int id)
    {
        var cliente = await _clienteRepository.GetClienteById(id);
        if (cliente == null)
        {
            return NotFound();
        }
        return Ok(cliente);
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetClienteByName(string name)
    {
        var cliente = await _clienteRepository.GetClienteByName(name);
        if (cliente == null)
        {
            return NotFound();
        }
        return Ok(cliente);
    }

    [HttpGet("{email}")]
    public async Task<IActionResult> GetClienteByEmail(string email)
    {
        var cliente = await _clienteRepository.GetClienteByEmail(email);

        if (cliente == null)
        {
            return NotFound();
        }

        return Ok(cliente);
    }


    [HttpPost]
    public async Task<IActionResult> Create(Cliente cliente)
    {
        await _clienteRepository.AddCliente(cliente);
        return CreatedAtAction(nameof(GetClienteById), new { id = cliente.Id }, cliente);
    }

    [HttpGet("add")]
    public IActionResult Create()
    {
        //ViewData["Title"] = "Cadastro de Cliente";

        return View("/Pages/Cadastro/Create.cshtml", model);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult>Edit(int id, Cliente cliente)
    {
        if (id != cliente.Id)
        {
            return BadRequest();
        }

        await _clienteRepository.UpdateCliente(cliente);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult>Delete(int id)
    {
        await _clienteRepository.DeleteCliente(id);
        return NoContent();
    }
}
