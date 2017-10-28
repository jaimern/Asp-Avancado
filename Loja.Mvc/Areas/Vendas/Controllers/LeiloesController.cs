using Loja.Dominio;
using Loja.Mvc.Helpers;
using Loja.Repositorios.SqlServer.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Loja.Mvc.Areas.Vendas.Controllers
{
    using System.Security.Claims;
    using System.Web.Mvc;

    [Authorize(Roles = "Administrador, Leiloeiro, Comprador")]
    public class LeiloesController : Controller
    {
        private LojaDbContext _db = new LojaDbContext();
        // GET: Vendas/Leiloes
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(Mapeamento.Mapear(_db.Produtos.Where(c => c.EmLeilao).ToList()));
            
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var usuario = (ClaimsIdentity)User.Identity;
            if(!usuario.HasClaim(Modulo.Leilao.ToString(),Acao.Detalhar.ToString()))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            Produto produto = _db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(Mapeamento.Mapear(produto));
        }

    }
}