// Cours : POO 
//
// Jeu : Bonhomme pendu
//
// Auteur : Ozgur GUNDOGAN
// Prof : Jeremy KAIRIS
//


JeuStruct pendu = new JeuStruct("Bonhomme Pendu",0);


Console.Write("Jeu : "+pendu.GetTitre() + "        Niveau : " + pendu.GetNiveau());
Console.WriteLine("        Vies : " + pendu.GetLives());


Random aleatoire = new Random();
int numero;
numero = aleatoire.Next(1, 7); //numero allant de 1 -> 6


foreach (string dessinPart in pendu.GetDessinGlobal())
{
    Console.WriteLine(dessinPart); 
}

struct JeuStruct
{
    private string titre;
    private int niveau;
    private int lives=6;
    List<int> numeroFait = new List<int>();
    List<string> listMots = new List<string>() { "maison", "camion", "pomme", "papier", "carton", "bouteille" };
    string[] dessinGlobal = new string[] { " ____  ", " |  |  ", " |     ", " |     ", " |     ", " |     ", "------ " };
    string dessinBonhomme = new string("O|/\\/\\");
    List<int[]> coordonneesBonhomme = new List<int[]>() { new int[]{ 4, 2 }, new int[]{ 4, 3 } , new int[]{ 3, 3 },
                                       new int[]{ 5, 3 }, new int[]{ 3, 4 }, new int[]{ 5, 4 } };
    public JeuStruct(string titre, int niveau)
    {
        this.titre = titre;
        this.niveau = niveau;
    }
    public string GetTitre()
    {
        return titre;
    }
    public int GetNiveau()
    {
        return niveau;
    }
    public int GetLives()
    {
        return lives;
    }
    public string[] GetDessinGlobal()
    {
        return dessinGlobal;
    }
}


