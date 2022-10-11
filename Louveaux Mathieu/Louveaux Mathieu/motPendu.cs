



//Console.WriteLine(motArr.GetValue(2));


//for (int i = 0; i < motArr.Length; i++)
//{
//    Console.Write(" avant " + motArr.GetValue(i));
//    motArr[i] = "u";
//    Console.Write(" apres " + motArr.GetValue(i));
//}



public struct pendu
{
    public string mot;
    public Char[] motPendu()
    {
        char[] nbLettre = new char[mot.Length];
        for (int i = 0; i < mot.Length; i++)
        {
            Console.WriteLine(mot[i]);
            nbLettre[i] = mot[i];
        }
        return nbLettre;
    }
    //Char[] test2 = motPendu("pouet");
    //string[] motArr = Array.ConvertAll(test2, x => x.ToString());
    //Array[] motMasque = new Array[motArr.Length];
}

public struct motCache
{
    public string[] motCachArr;

    public string[] hiddenWord()
    {
        string[] motMasque = new string[motCachArr.Length];
        for (int i = 0; i < motMasque.Length; i++)
        {
            motMasque[i] = ".";
            Console.Write(motMasque.GetValue(i));
        }
        return motMasque;
    }
}