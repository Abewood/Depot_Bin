using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projet_pizza
{
    class Pizza
    {
        string nom;
        public float prix{get; private set;}
        bool vegetarienne;
        List<string> ingredients;

        public Pizza(string nom, float prix, bool vegetarienne, List<string> ingredients)
        {
            this.nom = nom;
            this.prix = prix;
            this.vegetarienne = vegetarienne;
            this.ingredients = ingredients;
        }

        public void Afficher()
        {
            
            string badgeVegetarienne = vegetarienne ? " (V)" : "";
            string nomAfficher = FormatPremiereLettreMajuscules(nom);

			// Affichage des ingrédients formattés - 1ère lettre en Majuscule :
			
			// Solution 1/2 :
			//var ingredientsToDisplay = new List<string>();
			//foreach (var ingredient in ingredients)
			//{
			//	ingredientsToDisplay.Add(FormatPremiereLettreMajuscules(ingredient));
			//}
			
			// Solution 2/2 :
			var ingredientsToDisplay = ingredients.Select(i => FormatPremiereLettreMajuscules(i)).ToList();
			
            Console.WriteLine(nomAfficher + badgeVegetarienne + " - " + prix + "€");
			Console.WriteLine(String.Join(", ", ingredientsToDisplay));
            Console.WriteLine();
            
        }

        private static string FormatPremiereLettreMajuscules(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            string minuscules = s.ToLower();
            string majuscules = s.ToUpper();

            string resultat = majuscules[0] + minuscules[1..];

            return resultat;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // ingredients <- Liste string   "mozarella"    "poulet"   "oignon"
            // données
            // Afficher
            // 4 fromages (V) - 11.5€
            // cantal, mozzarella, gruyère, conté
            //
            // ...
            // join


            var pizzas = new List<Pizza>() {
                new Pizza("4 fromages", 11.5f, true, new List<string> { "cantal", "mozzarella", "fromage de chèvre", "gruyère" }),
                new Pizza("indienne", 10.5f, false, new List<string> { "curry", "mozzarella", "poulet", "poivron", "oignon", "coriandre" }),
                new Pizza("MEXICAINE", 13f, false, new List<string> {"boeuf", "mozzarella", "maïs", "tomates", "oignon", "coriandre"}),
                new Pizza("margherita", 8f, true, new List<string> { "sauce tomate", "mozzarella", "basilic" }),
                new Pizza("Calzone", 12f, false, new List<string> { "tomate", "jambon", "persil", "oignons"}),
                new Pizza("complète", 9.5f, false, new List<string> { "jambon", "oeuf", "fromage" }),
            };
			
			// Tri des pizzas en fonction de leur prix :
			// Décroissant :
			// pizzas = pizzas.OrderByDescending(p => p.prix).ToList();
			
			// Croissant :
			// pizzas = pizzas.OrderBy(p => p.prix).ToList();
			// Recherche de la pizza la moins chère et de la pizza la plus chère : 
			Pizza pizzaPrixMin = null;
			Pizza pizzaPrixMax = null;
			
			pizzaPrixMin = pizzas[0];
			pizzaPrixMax = pizzas[0];
			
			foreach (var pizza in pizzas)
			{
				// Recherche du prix minimum : 
				if (pizza.prix < pizzaPrixMin.prix)
				{
					pizzaPrixMin = pizza;
				}
				
				// Recherche du prix maximu : 
				if (pizza.prix > pizzaPrixMax.prix)
				{
					pizzaPrixMax = pizza;
				}

				pizza.Afficher();
			}
			
			// Affichage des pizzas la moins chère et la plus chère :
			Console.WriteLine();
			Console.WriteLine("La pizza la moins chere est : ");
			pizzaPrixMin.Afficher();
			Console.WriteLine();
			Console.WriteLine("La pizza la plus chere est : ");
			pizzaPrixMax.Afficher();
        }
    }
}