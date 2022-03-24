// CLASSE OUTILS.CS

using System;

namespace generateur_mot_de_passe
{	
	static class outils
	{ 
		static int Ask_Number_Strictly_Positive(string question)
		{	
			return Ask_Number_Borders(question, 1, int.MaxValue);
		}
		
		static int Ask_Number_Borders(string question, int min, int max)
		{
				int nbr_User = Ask_Number(question);
				
				if (nbr_User >= min && nbr_User <= max)
				{
					return nbr_User;	
				}
				else
				{
					Console.WriteLine("ERREUR : Entrez un nombre entre " + min + " et " + max);	
				}
			
			return Ask_Number_Borders(question, min, max);
		}
		
		static int Ask_Number(string question)
		{
			while(true)
			{
				Console.Write(question);
				string aswr = Console.ReadLine();

				try
				{
					int nbr_User = int.Parse(aswr);
					return nbr_User;
				}
				catch
				{
					Console.WriteLine("ERREUR : Entrez un nombre valide... (un peu con le type)");
				}
			}
		}
	}
}