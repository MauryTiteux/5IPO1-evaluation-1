string str = "mathieu";
int count = 3;

static void attempt(string str = "mathieu", int count = 3)
{
    do
    {
        char test = Console.ReadLine()[0];
        //Char.TryParse(Console.ReadLine(), out test);
        bool flag = false;
        foreach (char c in str)
        {
            if (c == test)
            {
                Console.WriteLine("Bonne lettre");
                flag = true;
            }
        }
        if (flag == false)
        {
            count--;
        }
        if (count == 0)
        {
            Console.WriteLine("Game Over");
            break;
        }
        if (flag == false && count != 0)
        {
            Console.WriteLine("Mauvaise lettre essayer a nouveau");
        }
    } while (count != 0);

}

attempt(str, count);

//using static System.Net.Mime.MediaTypeNames;

//var mot = new pendu();
//mot.mot = "pouet";

//char[] test3 = mot.motPendu();

//string[] motArr = Array.ConvertAll(test3, x => x.ToString());
//string[] motMasque = new string[motArr.Length];

//var motCache = new motCache();
//motCache.motCachArr = motArr;

//string[] test4 = motCache.hiddenWord();


//for (int i = 0; i < motMasque.Length; i++)
//{
//    motMasque[i] = ".";
//    Console.Write(motMasque.GetValue(i));
//}
