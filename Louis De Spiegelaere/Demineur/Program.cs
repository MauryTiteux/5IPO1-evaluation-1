using System;
namespace test {
    class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length != 3)
                return;
            uint height;
            uint width;
            uint bombs;
            if (!uint.TryParse(args[0], out height))
            {
                Console.WriteLine("Parsing height impossible");
                return;
            }
            if (!uint.TryParse(args[1], out width)) {
                Console.WriteLine("Parsing width impossible");
                return;
            }
            if  (!uint.TryParse(args[2], out bombs)) {
                Console.WriteLine("Parsing bombs impossible");
                return;
            }
            Demineur demineur = null;
            try {
                demineur = new Demineur(height, width, bombs);
            } catch (ArgumentException e) {
                Console.Write(e.Message);
            }
            Console.Clear();
            if (demineur.Play() == true) {
                Console.Clear();
                Console.WriteLine("Felicitation, vous avez gagne !");
                Console.WriteLine(demineur);
                return;
            }
            Console.WriteLine("Dommage, c'est perdu !");
            return;
        }
    }
}