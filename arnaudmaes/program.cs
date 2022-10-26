
using arnaudmaes.Structures;


System.Console.WriteLine("Quelle mot?");

string mot = Console.ReadLine();
char[] array = new char[mot.Length];
for (int i = 0; i < mot.Length; i++) { 
         array[i] = mot[i];
         }
int tailleMot=mot.Length;
pendu pendu = new pendu(array, tailleMot);
System.Console.WriteLine(tailleMot);
while(pendu.generalCount != 0){
    System.Console.WriteLine(" ");
    System.Console.WriteLine("Quelle lettre?");
    string lettre = Console.ReadLine();
    pendu.verif(lettre);
    System.Console.WriteLine("Il vous reste " + pendu.life + " vies");
    System.Console.Write("Vous avez déjà essayer les lettres :"); 
    for(int i=0; i<pendu.lettrerater.Length;i++){
        System.Console.Write(pendu.lettrerater[i] + " " );
    }
    System.Console.Write("Vous avez déjà trouvé les lettres : ");
    for(int i=0; i<pendu.lettreTrouve.Length;i++){
        System.Console.Write(pendu.lettreTrouve[i] + " " );
    }
    if(pendu.life==0){
        System.Console.WriteLine("");
        System.Console.WriteLine("c'est perdu");
        break;
    }
}
if(pendu.generalCount==0){
    System.Console.WriteLine(("félicitation vous avez trouvé le mot!"));
}



