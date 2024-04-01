using introducaoCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace introducaoCoreMVC.Controllers
{
    public class ProdutoController : Controller
    {
        // Variável de classe para persistir a lista de produtos
        private static List<Produto> produtos = new List<Produto>();
        // Ação que responde à requisição para a página inicial do controlador
        public IActionResult Index()
        {
            return View(produtos);
        }

        // Ação para exibir o formulário de adição de produtos
        public IActionResult Create()
        {
            return View();
        }

        // Ação para processar o formulário de adição de produtos
        [HttpPost]
        public IActionResult Create(Produto newProduto)
        {
            // Lógica para adicionar o novo produto ao banco de dados ou outra fonte de dados
            newProduto.Id = produtos.Count + 1;
            produtos.Add(newProduto);

            // Redireciona de volta para a página principal após adicionar o produto
            return RedirectToAction("Index");
        }
    }
}
