using BoutiqueFarcesEtAttrapes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoutiqueFarcesEtAttrapes.Controllers
{
    public class HomeController : Controller
    {
        private readonly BoutiqueFarcesEtAttrapesDbContext _db;
        public HomeController(BoutiqueFarcesEtAttrapesDbContext db)
        {
            _db = db;
        }

        List<Product> Products = new List<Product>
        {
            new Product{ProductName = "Marques des Ténèbres comestibles", Description = "Bonbons qui rendent malades à coup sûr.", Price = 1},
            new Product{ProductName = "Oreilles à rallonge", Description = "Pour écouter à distance.", Price = 10},
            new Product{ProductName = "Tour de magie moldus", Description = "Pour découvrir la magie des Moldus", Price = 8},
            new Product{ProductName = "Rêve Éveillé", Description = " 	Permet de rêver et s'évader provisoirement du quotidien et des tracas de la vie. ", Price = 50},
            new Product{ProductName = "Télescope frappeur", Description = "Frappe celui ou celle qui le serre trop fort et provoque une ecchymose presque indélébile.", Price = 20},
            new Product{ProductName = "Marécage Portable", Description = " 	Pour ceux qui souhaitent un petit coin de nature... à portée de main. Légèrement envahissant.", Price = 45},
            new Product{ProductName = "Plume autoencreur", Description = "Une plume qui se recharge d'encre seule!", Price = 6},
            new Product{ProductName = "Plume à réplique cinglante", Description = "Sacrebleu!", Price = 3},
            new Product{ProductName = "Plume à vérificateur d'orthographe", Description = "N'ayez plus peur des fautes!", Price = 9},
            new Product{ProductName = "Pendu Réutilisable", Description = "Trouvez le bon sort ou il aura la corde au cou !", Price = 15},
            new Product{ProductName = "Boîtes à Flemme", Description = "Idéal pour manquer les cours!", Price = 10},
            new Product{ProductName = "Baguettes farceuses", Description = "Se transforme quand est utilisée.", Price = 5},
            new Product{ProductName = "Pousse-Rikiki", Description = "Vous avez peur de Vous-Savez-Qui ? Craignez plutôt POUSSE-RIKIKI le constipateur magique qui vous prend aux tripes !", Price = 10},
            new Product{ProductName = "Feuxfous Fuseboum - Flambée de base", Price = 5},
            new Product{ProductName = "Feuxfous Fuseboum - Déflagration Deluxe", Price = 20},
            new Product{ProductName = "Leurres Explosifs", Description = "Pour faire diversion.", Price = 5},
            new Product{ProductName = "Poudre d'Obscurité Instantanée du Pérou", Description = "Permet de disparaître facilement. ", Price = 18},
            new Product{ProductName = "Chapeaux Boucliers", Description = "Protègent contre les sorts mineurs.", Price = 30},
            new Product{ProductName = "Capes Bouclierss", Description = "Protègent contre les sorts mineurs", Price = 30},
            new Product{ProductName = "Capes Boucliers", Description = "Protègent contre les sorts mineurs", Price = 30},
            new Product{ProductName = "Chapeaux-sans-Tête", Description = "Plutôt évocateur, non?", Price = 2},
            new Product{ProductName = "Philtres d'amour", Description = "Rend la personne obsédée par vous lorsqu'elle en boit. Dure 24h.", Price = 5},
        };

        public async Task<IActionResult> Index()
        {
            return View(await GetStocksAsync());
        }
        public async Task<List<Stock>> GetStocksAsync()
        {
          return await _db.Stocks.ToListAsync();
        }
        public async Task<IActionResult> AddProducts()
        {
            await AddProductList(Products);
            return RedirectToAction("Index");
        }
        public async Task AddProductList(List<Product> products)
        {
            foreach (Product p in products)
            {
                Stock st = new Stock
                {
                    Product = p,
                    Quantity = new Random().Next()
                };
                _db.Stocks.Add(st);
            }
            await _db.SaveChangesAsync();
        }

    }
}
