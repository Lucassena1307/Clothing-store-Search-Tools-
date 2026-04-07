using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LojaOstentacaoAPI.Data;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("buscar")]
    public async Task<ActionResult> Buscar([FromQuery] string nome, [FromQuery] string tamanho)
    {
        var produtos = await _context.Produtos
            .Where(p => p.Nome.Contains(nome) && p.Tamanho == tamanho)
            .ToListAsync();

        return Ok(produtos);
    }

    [HttpPost("venda/{id}")]
    public async Task<IActionResult> RegistrarVenda(int id)
    {
        var produto = await _context.Context.Produtos.FindAsync(id);
        
        if (produto == null || produto.QuantidadeEstoque <= 0)
            return BadRequest("Item indisponível no estoque físico.");

        produto.QuantidadeEstoque -= 1;
        await _context.SaveChangesAsync();

        return Ok($"Venda confirmada! Estoque atualizado: {produto.QuantidadeEstoque} unidades.");
    }
}