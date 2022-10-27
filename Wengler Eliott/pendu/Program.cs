using System;

pendu();

string get_pendu_str(string w, bool[] ilh){         //Fonction qui affiche les lettres si elles ne sont pas cachées , sinon un underscore
    string pendu = ""; 
    for(int i = 0; i < ilh.Length ; i++){
        if (ilh[i] == false){
            pendu = pendu + w[i];
        }
        else{
             pendu = pendu + '_';
        }
    }
    return pendu;
}

bool verif_input_in_word(char c, string s, bool[] btab){ // verif si lettre est dans le mot
    bool ret = false;
    for (int i = 0; i < btab.Length ; i++){
        if (Char.ToLower(c) == Char.ToLower(s[i])){
            btab[i] = false;
            ret = true;
        }
    }
    return ret;
}

bool is_win(string w, bool[] btab){  // fonction qui check si c'est gagné
    for (int i = 0; i < btab.Length ; i++){
        if (btab[i] == true){
            return false;
        }
    }
    return true;
}

void pendu(){

    int life = 5; // variable vie
    string word = "Chaussure"; // création du mot à trouver
    bool[] is_letter_hidden = new bool[word.Length] ; // Création tableau pour voir si lettre du mot est caché ou pas et setup la taille du tableau

    for(int i = 0; i < is_letter_hidden.Length ; i++){  // Boucle for qui cache toute les lettres
        is_letter_hidden[i] = true;
    }

    while(!is_win(word,is_letter_hidden)){
        Console.WriteLine(String.Format("Il te reste {0} vies", life));
        
        Console.WriteLine(get_pendu_str(word, is_letter_hidden));
        char user_input = Console.ReadKey().KeyChar; // le programme s'interrompt et attends que l'utilisateur rentre une lettre et la stock dans user_imput
        Console.WriteLine();
        if (verif_input_in_word(user_input, word, is_letter_hidden)){
            Console.WriteLine("Bravo !");
        }
        else{
            Console.WriteLine("Dommage !");
            life--;
        }
        if (life<1){
            Console.WriteLine("Ho dommage t'as perdu");
            return;
        }
    }
    Console.WriteLine("Ho bravo, tu as gagné.");

    

}
