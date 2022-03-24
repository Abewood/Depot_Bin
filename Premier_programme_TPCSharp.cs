using System;
	
// FORMATION C# UDEMY - NOMBRE MAGIQUE				
public class Program
{
	static int Ask_Nbr(int min, int max)
	{
		// Initialisation permettant de couvrir l'ensemble des valeurs pouvant 
		// être prises par "min" et "max" :
		int nbr_User = min - 1; // Alternative : int nbr_User = max + 1;
		
		while(nbr_User < min || nbr_User > max)
		{
			Console.Write("Entrez un nombre entre " + min + " et " + max + " > ");
			string aswr = Console.ReadLine();
			
			try
			{
				nbr_User = int.Parse(aswr);
				if (nbr_User < min || nbr_User > max)
				{
					Console.WriteLine("ERREUR : Entrez un nombre entre " + min + " et " + max + "(Sérieux...)");
				}
					
			}
			catch
			{
				Console.WriteLine("ERREUR : Entrez un nombre valide... (un peu con le type)");
			}
		}
		
		return nbr_User;
	}
	
	public static void Main(string[] args)
	{
		// Constantes :
		const int NOMBRE_MIN = 1;
		const int NOMBRE_MAX = 10;
		
		// Nombre aléatoire :
		// >> Impossible dans .NET Fiddle car le code est exécuté en totalité à chaque itération : la 
		// >> valeur de rand.Next change à chaque fois.
		// Random rand = new Random();
		// int nbr_mgc = rand.Next(NOMBRE_MIN, NOMBRE_MAX+1);
		// int NOMBRE_MAGIQUE = nbr_mgc;
		int NOMBRE_MAGIQUE = 5;
		
		Console.WriteLine("{NOMBRE_MIN : " + NOMBRE_MIN + " | NOMBRE MAX : " + NOMBRE_MAX + "}");
		Console.WriteLine("Nombre à trouver : " + NOMBRE_MAGIQUE);
		
		// Conditions pour rester ou sortir de la boucle while :
		bool nbr_fd = false;
		int tentatives = 3;
		
		while(nbr_fd == false && tentatives > 0)
		{
			Console.WriteLine("Nombre de tentatives restantes : " + tentatives);
			int user_Input = Ask_Nbr(NOMBRE_MIN, NOMBRE_MAX);

			if (user_Input > NOMBRE_MAGIQUE)
			{
				Console.WriteLine("Le nombre recherché est plus petit..");
			}
			else if (user_Input < NOMBRE_MAGIQUE)
			{
				Console.WriteLine("Le nombre recherché est plus grand..");
			}	
			else
			{
				nbr_fd = true;
				Console.WriteLine("Bravo ! Vous avez trouvé le bon nombre (" + user_Input + ") ! (BG)");
			}
			
			tentatives--;
		}
		
		if (nbr_fd != true)
		{
			Console.WriteLine("");
			Console.WriteLine("PERDU : Le nombre rechérché n'a pas été trouvé... (CHEHHHH !)");
		}
	}
}