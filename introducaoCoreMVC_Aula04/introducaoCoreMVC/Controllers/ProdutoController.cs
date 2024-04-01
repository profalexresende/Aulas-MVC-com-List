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

        //EDITAR PRODUTOS

        // Ação para exibir o formulário de edição de produto
        public IActionResult Edit(int id)
        {
            // Encontra o produto na lista com base no ID
            Produto produto = produtos.FirstOrDefault(p => p.Id == id);

            if (produto == null)
            {
                // Se o produto não for encontrado, retorna um erro ou redireciona para uma página de erro
                return NotFound();
            }

            return View(produto);
        }

        // Ação para processar o formulário de edição de produto
        [HttpPost]
        public IActionResult Edit(Produto produto)
        {
            // Encontra o índice do produto na lista com base no ID
            int index = produtos.FindIndex(p => p.Id == produto.Id);

            if (index == -1)
            {
                // Se o produto não for encontrado, retorna um erro ou redireciona para uma página de erro
                return NotFound();
            }

            // Atualiza os dados do produto na lista
            produtos[index] = produto;

            // Redireciona de volta para a página principal após editar o produto
            return RedirectToAction("Index");
        }

        //EXCLUIR PRODUTOS

        // Ação para exibir a confirmação de exclusão do produto
        public IActionResult Delete(int id)
        {
            // Encontra o produto na lista com base no ID
            Produto produto = produtos.FirstOrDefault(p => p.Id == id);

            if (produto == null)
            {
                // Se o produto não for encontrado, retorna um erro ou redireciona para uma página de erro
                return NotFound();
            }

            return View(produto);
        }

        // Ação para processar a exclusão do produto
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            // Encontra o produto na lista com base no ID
            Produto produto = produtos.FirstOrDefault(p => p.Id == id);

            if (produto == null)
            {
                // Se o produto não for encontrado, retorna um erro ou redireciona para uma página de erro
                return NotFound();
            }

            // Remove o produto da lista
            produtos.Remove(produto);

            // Redireciona para a página principal após excluir o produto
            return RedirectToAction("Index");
        }


    }
}
