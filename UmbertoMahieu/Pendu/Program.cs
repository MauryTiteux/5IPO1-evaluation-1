// Variables globales

int idx = 0;

// Le jeu !

pendu();

// FONCTION

void pendu(){

    Console.Write("Joueur 1 : Indiquez le mot à faire deviner : ");
    string word = Console.ReadLine();
    char[] wordArr = word.ToCharArray();

    char[] guessArr = copyArray(wordArr); 
    initializeArr(guessArr);

    char[] notIncludedArr = new char[25];
    initializeNotInclu(notIncludedArr);

    int error = 0;

    Console.WriteLine("------------------------------------------------");
    Console.WriteLine("Le jeu commence !");
    for (int i = 0 ; i < 25 ; i++){

        Console.WriteLine("\nJoueur 2 : Testez une lettre ");
        char letter = Console.ReadKey().KeyChar;
        Console.WriteLine();

        if(!hasGuessedRight(wordArr, guessArr, letter))
        {
            pushToArr(letter, notIncludedArr);
            error++;
        }

        printPendu(error);
        Console.Write(guessArr);
        Console.WriteLine();
        if (error != 0)
        {
            printArr(notIncludedArr);
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

bool hasLetter(char l, char[] arr)
{
    for (int i = 0 ; i < arr.Length ; i++)
    {
        if (arr[i] == l) return true; 
    }
    return false;
}

void initializeNotInclu (char[] arr)
{
    for (int i = 0 ; i < arr.Length ; i++)
    {
        arr[i] = '\0';
    }
}

void initializeArr (char[] arr)
{
    for (int x = 0 ; x < arr.Length ; x++)
    {
        char code = '_';
        arr[x] = code;
    }
}

bool hasGuessedRight (char[] wordArr, char[] guessArr, char letter)
{  
    if (!hasLetter(letter, wordArr)) return false;

    for (int l = 0 ; l < wordArr.Length ; l++)
    {
        if (Char.ToLower(wordArr[l]) == Char.ToLower(letter))
        {
            guessArr[l] = letter;
        }
    }
    return true;
}

bool pushToArr (char l, char[] arr)
{   
    if (hasLetter(l, arr))
    {
        return false;
    }
    arr[idx] = l;
    idx++;

    return true;
}

void printArr (char [] arr)
{
    Console.Write("Lettre erronée : [");
    for(int i = 0 ; i < arr.Length ; i++)
    {
        if (arr[i] != '\0')
        {
            Console.Write(arr[i]);
            if (arr[i+1] == '\0')
            {
                Console.Write("]");
            }
            else if (i != arr.Length - 1)
            {
                Console.Write(", ");
            }
        }
    }
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

