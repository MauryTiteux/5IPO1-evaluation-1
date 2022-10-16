// Le jeu !

pendu();

// FONCTION

void pendu(){

    Console.Write("Joueur 1 : Indiquez le mot à faire deviner : ");
    string word = Console.ReadLine();
    char[] wordArr = word.ToCharArray();

    char[] guessArr = copyArray(wordArr); 
    initializeArr(guessArr);

    List<char> notIncludedList = new List<char>();

    int error = 0;

    Console.Clear();

    Console.WriteLine("------------------------------------------------");
    Console.WriteLine("Le jeu commence !");
    while (true)
    {

        Console.WriteLine("\nJoueur 2 : Testez une lettre ");
        char letter = Console.ReadKey().KeyChar;
        Console.WriteLine();

        if(!hasGuessedRight(wordArr, guessArr, letter))
        {
            notIncludedList.Add(letter);
            error++;
        }
        Console.Clear();
        printPendu(error);
        Console.Write(guessArr);
        Console.WriteLine();
        if (error != 0)
        {
            printList(notIncludedList);
        }

        Console.WriteLine();

        if(error == 6)
        {
            Console.WriteLine("Vous avez perdu !");
            return;
        }

        if(hasWin(guessArr))
        {
            Console.WriteLine("Vous avez trouvé, bien joué !");
            return;
        }
        
    }
}


char[] copyArray (char[] arr)
{   
    char[] copied = new char[arr.Length];

    for (int i = 0 ; i < arr.Length ; i++)
    {
        copied[i] = arr[i];
    }
    return copied;
}

void initializeArr (char[] arr)
{
    for (int x = 0 ; x < arr.Length ; x++)
    {
        arr[x] = '_';
    }
}

bool hasGuessedRight (char[] wordArr, char[] guessArr, char letter)
{  
    if (!wordArr.Contains(letter)) return false;

    for (int l = 0 ; l < wordArr.Length ; l++)
    {
        if (Char.ToLower(wordArr[l]) == Char.ToLower(letter))
        {
            guessArr[l] = letter;
        }
    }
    return true;
}

void printList (List<char> list)
{
    Console.Write("Lettre erronée : [");
    for (int i = 0 ; i < list.Count ; i++)
    {
        Console.Write(list[i]);
        if (i != list.Count - 1)
        {
            Console.Write(", ");
        }
    }
    Console.Write("]");
}

void printPendu (int erreur)
{
    if (erreur == 0)
    {
        Console.WriteLine("\n+---+");
        Console.WriteLine("    |");
        Console.WriteLine("    |");
        Console.WriteLine("    |");
        Console.WriteLine("   ===");
    }
    else if (erreur == 1)
    {
        Console.WriteLine("\n+---+");
        Console.WriteLine("O   |");
        Console.WriteLine("    |");
        Console.WriteLine("    |");
        Console.WriteLine("   ===");
    }
    else if (erreur == 2)
    {
        Console.WriteLine("\n+---+");
        Console.WriteLine("O   |");
        Console.WriteLine("|   |");
        Console.WriteLine("    |");
        Console.WriteLine("   ===");
    }
    else if (erreur == 3)
    {
        Console.WriteLine("\n+---+");
        Console.WriteLine(" O  |");
        Console.WriteLine("/|  |");
        Console.WriteLine("    |");
        Console.WriteLine("   ===");
    }
    else if (erreur == 4)
    {
        Console.WriteLine("\n+---+");
        Console.WriteLine(" O  |");
        Console.WriteLine("/|\\ |");
        Console.WriteLine("    |");
        Console.WriteLine("   ===");
    }
    else if (erreur == 5)
    {
        Console.WriteLine("\n+---+");
        Console.WriteLine(" O  |");
        Console.WriteLine("/|\\ |");
        Console.WriteLine("/   |");
        Console.WriteLine("   ===");
    }
    else if (erreur == 6)
    {
        Console.WriteLine("\n+---+");
        Console.WriteLine(" O   |");
        Console.WriteLine("/|\\  |");
        Console.WriteLine("/ \\  |");
        Console.WriteLine("    ===");
    }
}

bool hasWin (char[] arr)
{
    for (int i = 0 ; i < arr.Length ; i++)
    {
        if (arr[i] == '_') return false;
    }
    return true;
}

