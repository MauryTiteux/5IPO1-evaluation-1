using System.Text;

Console.Write("Entrer un mot pour le jeu du pendu : ");
string? word = Console.ReadLine();
if (word == null || word == "")
{
    Console.WriteLine("Pas de mot ?!");
    return;
}

string guessedWord = "";
int guessedLetterCount = 0;
int remainingLife = 8;
List<char> badLetter = new List<char>();


//creation des nb de point en focntion du nb de lettre dans le mot
for (int i = 0; i < word.Length; i++)
{
    guessedWord += ".";
}
Console.WriteLine(word);

bool canGuess = true;
do
{
    Console.WriteLine(guessedWord);
    Console.Write("Proposer une lettre : ");
    char letter = Console.ReadKey().KeyChar;
    Console.WriteLine();

    List<int> letterIndices = FindLetterInWord(letter, word);

    //check si isfound a au moins une lettre dans le mot
    bool isFound = letterIndices.Count > 0;
    if (isFound)
    {
        Console.WriteLine($"Tu as trouvé une lettre {letter}"); /*$ pour lettre une variable dans une string*/
        guessedWord = CompleteGuessedWord(letterIndices, guessedWord, word);
        guessedLetterCount += letterIndices.Count;
        if(guessedLetterCount >= word.Length){
            Console.WriteLine("Bravo tu as trouvé le mot");
            canGuess = false;
        }
    }
    else
    {
        Console.WriteLine("Non cette lettre n'est pas dans le mot !");
        badLetter.Add(letter);
        Console.WriteLine($" Lettre deja proposé : {string.Join(", ", badLetter)}");
        remainingLife--;
        Console.WriteLine($" vie restante : {remainingLife}");

        if(remainingLife <= 0){
            Console.WriteLine("Tu as perdu !");
            canGuess = false;
        }
        
    }

} while (canGuess);



//function trouver la lettre dans le mot
List<int> FindLetterInWord(char letter, string word)
{
    List<int> result = new List<int>();

    for (int i = 0; i < word.Length; i++)
    {
        if (char.ToLowerInvariant(word[i]) == char.ToLowerInvariant(letter))
        {
            result.Add(i);
        }
    }
    return result;
}

//function qui met les lettre au bon endroit
string CompleteGuessedWord(List<int> letterIndices, string guessedWord, string word)
{
    StringBuilder sb = new StringBuilder(guessedWord);

    foreach (var index in letterIndices)
    {
        sb[index] = word[index];
    }

    return sb.ToString();
}