using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendu
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Word> words = new List<Word>();
            words.Add(new Word("ajouter"));
            GameInstance game = new GameInstance();
            game.Play();
        }
    }
}
