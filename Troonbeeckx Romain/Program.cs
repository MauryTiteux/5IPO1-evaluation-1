Console.WriteLine("Entrez le mot à trouver");
string mot = Console.ReadLine();
int tailleMot = mot.Length;

Console.WriteLine("le mot devra être trouvé en combien d'éssais?");
string essais = Console.ReadLine();

Console.Clear();

Console.WriteLine("le mot était "+ mot +" et il faisaitt "+ tailleMot+ " lettres");