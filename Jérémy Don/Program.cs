        int vie = 7;
        string word = "trouver";
        string[] hide = new string[word.Length];
        char[] wordArray = new char[word.Length];
        string hiddenWord = "";

        for (int i = 0; i < word.Length; i++)
        {
            wordArray[i]=word[i];
        }

        foreach (var item in wordArray)
        {
            hiddenWord = hiddenWord + "_";
        }
        void writeWord(){
            Console.WriteLine(hiddenWord);
        }


        while (true)
        {
            Console.WriteLine("Entrer une Lettre : ");
            char lettre = char.Parse(Console.ReadLine());
            bool balise = false;
            for (int i = 0; i < wordArray.Length; i++)
            {
                if(wordArray[i].Equals(lettre)){
                    balise=true;
                    hiddenWord = "";
                    for (int j = 0; j < word.Length; j++)
                    {
                        hiddenWord[i] = lettre;
                    }
                }
            }
            if (balise==false)
            {
                vie--;
            }
            Console.WriteLine("Vie(s) restante(s) " + vie);
            writeWord();
            if(vie<=0){
                Console.WriteLine("Game Over!");
                break;
                }
        }