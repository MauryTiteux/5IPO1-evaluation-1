using System;


int life = 5; // variable vie
string word = "Chaussure"; // création du mot à trouver
bool[] is_letter_hidden = new bool[word.Length] ; // Création tableau pour voir si lettre du mot est caché ou pas et setup la taille du tableau

for(int i = 0; i < is_letter_hidden.Length ; i++){  // Boucle for qui cache toute les lettres
    is_letter_hidden[i] = true;
}

is_letter_hidden[4] = false;

//Console.WriteLine(get_pendu_str(word,is_letter_hidden)); //test affichage



string get_pendu_str(string w, bool[] ilh){         //Fonction qui affiche les lettres si elles ne sont pas cachées , sinon un underscore
    string pendu = ""; 
    for(int i = 0; i < ilh.Length ; i++){
        if (is_letter_hidden[i] == false){
            pendu = pendu + w[i];
        }
        else{
             pendu = pendu + '_';
        }
    }
    return pendu;
}

