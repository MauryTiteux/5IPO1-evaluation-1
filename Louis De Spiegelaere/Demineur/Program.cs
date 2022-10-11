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
            while (true) {
                Console.WriteLine(demineur);
                int line;
                int column;
                while (!int.TryParse(Console.ReadLine(), out line) || !int.TryParse(Console.ReadLine(), out column));
                if (demineur.Map.DiscoverCell(line - 1, column - 1) == Map.Result.Bomb) {
                    Console.WriteLine("Perdu !");
                        return ;
                }
            }
        }
    }
}