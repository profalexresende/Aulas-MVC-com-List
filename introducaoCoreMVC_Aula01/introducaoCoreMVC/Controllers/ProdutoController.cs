using introducaoCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace introducaoCoreMVC.Controllers
{
    public class ProdutoController : Controller
    {
        // Ação que responde à requisição para a página inicial do controlador
        public IActionResult Index()
        {
            // Lógica para obter a lista de produtos (do banco de dados, por exemplo)
            List<Produto> products = GetProdutos();
                        // Retorna a view "Index" com a lista de produtos como modelo
            return View(products);

        }
        // Método privado que simula a obtenção de produtos do banco de dados
        private List<Produto> GetProdutos()
        {
            // Lógica para obter produtos do banco de dados (pode ser simulado para um exemplo simples)
            return new List<Produto>
        {
            new Produto { Id = 1, Nome = "Product 1", Preco = 19.99 },
            new Produto { Id = 2, Nome = "Product 2", Preco = 29.99 },
            new Produto { Id = 3, Nome = "Product 3", Preco = 39.99 }
        };
        }
    }
}
