// Cours : POO 
//
// Jeu : Bonhomme pendu
//
// Auteur : Ozgur GUNDOGAN
// Prof : Jeremy KAIRIS
//



JeuStruct pendu = new JeuStruct("Bonhomme Pendu",0);
bool resterDansJeu = true;
string reponseUser = "non";
do
{
    Console.SetCursorPosition(0,0);
    Console.Write("Jeu : " + pendu.GetTitre() + "        Niveau : " + pendu.GetNiveau());
    Console.WriteLine("        Vies : " + pendu.GetLives());


    Random aleatoire = new Random();
    int numero;
    numero = aleatoire.Next(1, 7); //numero allant de 1 -> 6


    foreach (string dessinPart in pendu.GetDessinGlobal())
    {
        Console.WriteLine(dessinPart);
    }

    Console.WriteLine("Voulez-vous continuer ? tapez oui pour confirmer: ");
    reponseUser = Console.ReadLine();
    if (reponseUser.Equals("oui", StringComparison.OrdinalIgnoreCase) != true)
    {
        resterDansJeu = false;
    }
    else
    {
        pendu.JoueMal();
    }
        

} while (resterDansJeu == true);




struct JeuStruct
{
    private string titre;
    private int niveau;
    private const int viesMax = 6;
    private int vies = viesMax;
    private List<int> numeroFait = new List<int>();
    private List<string> listMots = new List<string>() { "maison", "camion", "pomme", "papier", "carton", "bouteille" };
    private string[] dessinGlobal = new string[] { " ____  ", " |  |  ", " |     ", " |     ", " |     ", " |     ", "------ " };
    private string dessinBonhomme = new string("O|/\\/\\");
    private List<int[]> coordonneesBonhomme = new List<int[]>() { new int[]{ 4, 2 }, new int[]{ 4, 3 } , new int[]{ 3, 3 },
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
        return vies;
    }
    public string[] GetDessinGlobal()
    {
        return dessinGlobal;
    }
    public List<int[]> GetCoordonneesBonhomme()
    {
        return coordonneesBonhomme;
    }
    public string GetDessinBonhomme()
    {
        return dessinBonhomme;
    }
    public void JoueMal()
    {
        vies = vies - 1;
        int x = coordonneesBonhomme.ElementAt(viesMax - 1 - vies)[0];
        int y = coordonneesBonhomme.ElementAt(viesMax - 1 - vies)[1];
        char[] partDessin = dessinGlobal.ElementAt(y).ToCharArray();
        char partBody = dessinBonhomme.ElementAt(viesMax - 1 - vies);
        partDessin[x] = partBody;
        dessinGlobal[y] = new string(partDessin);
    }
}
 

