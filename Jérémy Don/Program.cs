        int vie = 7;
        string mot = "trouver";

        char[] motArray = new char[mot.Length];

         for (int i = 0; i < mot.Length; i++) { 
            motArray[i] = mot[i]; 
        }

        for (int i = vie; i > 0; i--)
        {
            Console.WriteLine(i);
            bool flag = false;
            string lettre = Console.ReadLine();
            char temp = lettre[0];
            foreach (var item in motArray)
            {
             if(lettre.Equals(temp)){
                Console.WriteLine("Bravo !");
                flag = true;
             }
            }
            if (flag==true){
                vie--;
            }
            if(vie<=0){
                    Console.WriteLine("Perdu !");
                }

            Console.WriteLine(vie);
        }
