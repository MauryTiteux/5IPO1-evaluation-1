// Cours : POO 
//
// Jeu : Bonhomme pendu
//
// Auteur : Ozgur GUNDOGAN
// Prof : Jeremy KAIRIS
//


//Point d'entrer main du programme

JeuStruct pendu = new JeuStruct("Bonhomme Pendu",0);  // appelle du constructeur
pendu.InitDebutNiveau();
string reponseUser = "non";
                
//Boucle de maintient de jeu
do
{
    pendu.AfficheJeu();
    Console.SetCursorPosition(0, 9);
    Console.Write("Tapez un caractère : ");
    reponseUser = Console.ReadLine();
    pendu.VerifieProposition(reponseUser.ElementAt(0)); // premier caractere entré au clavier

    if (pendu.GetLives() <= 0)      //invite à rester ou quitter le jeu si points de vies épuisées
    {
        Console.Clear();
        pendu.AfficheJeu();
        Console.SetCursorPosition(0, 9);
        Console.Write("\tVous avez perdu!!!");
        Console.SetCursorPosition(0, 11);
        Console.WriteLine("Voulez-vous continuer ? tapez oui pour confirmer: ");
        reponseUser = Console.ReadLine();
        if (reponseUser.Equals("oui", StringComparison.OrdinalIgnoreCase) != true)
        {
            pendu.SetResterDansLeJeu(false);
        }
        else
        {
            pendu = new JeuStruct("Bonhomme Pendu",0);
        }
    }
    Console.Clear();
} while (pendu.GetResterDansLeJeu() == true);




struct JeuStruct  //variable complexe de type structure.
{
    private bool resterDansJeu=true;
    private string titre;
    private int niveau;
    private const int viesMax = 6;
    private int vies = viesMax;
    private string motEnCourt = "";
    private List<int> numeroFait = new List<int>();
    private List<string> listMots = new List<string>() { "maison", "camion", "pomme", "papier", "carton", "bouteille" };
    private string[] dessinGlobal = new string[] { " ____  ", " |  |  ", " |     ", " |     ", " |     ", " |     ", "------ " };
    private string dessinBonhomme = new string("O|/\\/\\");
    private List<int[]> coordonneesBonhomme = new List<int[]>() { new int[]{ 4, 2 }, new int[]{ 4, 3 } , new int[]{ 3, 3 },
                                       new int[]{ 5, 3 }, new int[]{ 3, 4 }, new int[]{ 5, 4 } };
    private int[] motFlags = {};

    public JeuStruct(string titre, int niveau) // Constructeur
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
    public bool GetResterDansLeJeu()
    {
        return resterDansJeu;
    }
    public void SetResterDansLeJeu(bool resterDansJeu)
    {
        this.resterDansJeu = resterDansJeu;
    }
    public void AfficheMotEnCourt()
    {
        //affiche le mot sous forme cachée et releve les parties trouvées
        for(int i = 0; i < motEnCourt.Length; i++)
        {
            if (motFlags[i] == 0)
            {
                Console.Write(" _ ");
            }
            else
            {
                Console.Write(" "+motEnCourt.ElementAt(i)+" ");
            }
        }
    }
    public void JoueMal()
    {
        //sanction de vie et debut d'apparition du bonhomme pendu
        vies = vies - 1;
        int x = coordonneesBonhomme.ElementAt(viesMax - 1 - vies)[0];
        int y = coordonneesBonhomme.ElementAt(viesMax - 1 - vies)[1];
        char[] partDessin = dessinGlobal.ElementAt(y).ToCharArray();
        char partBody = dessinBonhomme.ElementAt(viesMax - 1 - vies);
        partDessin[x] = partBody;
        dessinGlobal[y] = new string(partDessin);
    }
    public void JoueBien(char caractereLu)
    {
        //il faut s'occuper de reveler les caracteres cachés correspondants
        for(int i=0; i < motEnCourt.Length; i++)
        {
            if (motEnCourt.ElementAt(i) == caractereLu)
            {
                motFlags[i]=1;
            }
            
        }

    }
    
    public void InitDebutNiveau()
    {
        //on va selectionner un mot dans la liste des motes
        //cacher le mot selectionné
        Random aleatoire = new Random();
        int nombreDeMots = listMots.Count;  //nombre de mots dans list
        int numero;
        do
        {
            numero = aleatoire.Next(0, nombreDeMots); //numero allant de 0 -> 5
        } while (numeroFait.Contains(numero));
        numeroFait.Add(numero);
        motEnCourt = listMots[numero];
        motFlags= new int[motEnCourt.Length];
        for(int i=0; i < motEnCourt.Length; i++)
        {
            motFlags[i]=0;
        }
    }

    public void  VerifieProposition(char caractereLu)
    {
        //on regarde si le caractere rentrer fait partie du mot ou pas
        //et on agit en fonction
        //si on a tout découvert, on termine le niveau
        if (motEnCourt.Contains(caractereLu))
        {
            JoueBien(caractereLu);
        }
        else
        {
            JoueMal();
        }
        if (!motFlags.Contains(0)) 
        {
            VictoireNiveau();   
        }
    }
    public void VictoireNiveau()
    {
        //message de fin de niveau et demande de remise a zero ou mise a fin du jeu
        niveau = niveau + 1;
        Console.Clear();
        Console.WriteLine("\n\n\tFélicitation!!! Vous avez trouvé le mot secret : "+motEnCourt);
        Console.WriteLine("\n\n\t\tVous allez passer au niveau suivant...");
        Console.WriteLine("\n\n\t\t   Tapez sur entrer pour continuer!");
        Console.ReadLine();
        if (niveau < listMots.Count)
        {
            clearNiveau();
        }
        else
        {
            VictoireJeu();
        }
        
    }
    public void clearNiveau()
    {
        //remise a zero pour niveau suivant
        vies = viesMax;
        int x, y;
        for (int i=0; i < viesMax; i++)
        {
            x = coordonneesBonhomme.ElementAt(i)[0];
            y = coordonneesBonhomme.ElementAt(i)[1];
            char[] partDessin = dessinGlobal.ElementAt(y).ToCharArray();
            partDessin[x] = ' ';
            dessinGlobal[y] = new string(partDessin);

        }
        
        InitDebutNiveau();
    }
    public void AfficheJeu()
    {
        //Affichage principale du jeu
        Console.SetCursorPosition(0,0);
        Console.Write("Jeu : " + titre + "        Niveau : " + niveau);
        Console.WriteLine("        Vies : " + vies);

        foreach (string dessinPart in dessinGlobal)
        {
            Console.WriteLine(dessinPart);
        }
    
        Console.SetCursorPosition(13, 5);
        Console.Write("Mot à trouver : ");
        AfficheMotEnCourt();
    }
    public void VictoireJeu()
    {
        //message de fin de jeu (END)
        Console.Clear();
        Console.WriteLine("\n\n\t**************************************");
        Console.WriteLine("\n\n\t*            THE END                 *");
        Console.WriteLine("\n\n\t**************************************");
        Console.WriteLine("\n\n\t      Vous êtes l'ultime champion...");
        Console.WriteLine("\n\n\t       Vous avez terminé le jeu!!!"  );
        Console.WriteLine("\n\n\t      Tapez sur entrer pour quitter!");
        Console.ReadLine();
        resterDansJeu=false;
    
    }
}
 

