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
                return;
            }
            Console.Clear();
            try {
                if (demineur.Play() == true) {
                    Console.Clear();
                    Console.WriteLine(demineur.Map);
                    Console.WriteLine();
                    Console.WriteLine("Felicitation, vous avez gagne !");
                    Console.WriteLine();
                    Console.WriteLine(demineur.Map.GetUnhiddenMap());
                    return;
                }
            } catch (ArgumentException e) {
                Console.WriteLine(e.Message);
            }
            Console.Clear();
            Console.WriteLine(demineur.Map);
            Console.WriteLine();
            Console.WriteLine("Dommage, c'est perdu !");
            Console.WriteLine();
            Console.WriteLine(demineur.Map.GetUnhiddenMap());
            return;
        }
    }
}