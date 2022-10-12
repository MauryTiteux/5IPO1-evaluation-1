namespace test {
    public class Demineur {
        private class Cursor {
            public int line;
            public int column;
            public Cursor(int line, int column) {
                this.line = line;
                this.column = column;
            }
        }
        public const uint MaxWidth = 100;
        public const uint MaxHeight = 100;
        public const uint MinEmptyCells = 10;
        private Map _map;
        private uint _height;
        private uint _width;
        private uint _bombs;
        private Cursor cursor;
        public Demineur(uint height, uint width, uint bombs) {
            try {
                this.Height = height;
                this.Width = width;
                this.Bombs = bombs;
            } catch (ArgumentException e) {
                throw new ArgumentException(e.Message);
            }
            cursor = new Cursor(0, 0);
            this._map = new Map(this._height, this._width, this._bombs);
        }
        public bool Play() {
            while (!this.Map.IsResolved()) {
                Console.WriteLine(this);
                int line;
                int column;
                while (!int.TryParse(Console.ReadLine(), out line) || !int.TryParse(Console.ReadLine(), out column));
                if (this.Map.DiscoverCell(line - 1, column - 1) == Map.Result.Bomb) {
                    Console.WriteLine("Perdu !");
                        return false;
                }
            }
            return true;
        }
        public uint Height {
            get {
                return this._height;
            }
            set {
                if (value > Demineur.MaxHeight)
                    throw new ArgumentException("Attempt to set height with a value exceeding limits");
                this._height = value;
            }
        }
        public uint Width {
            get {
                return this._width;
            }
            set {
                if (value > Demineur.MaxWidth)
                    throw new ArgumentException("Attempt to set width with a value exceeding limits");
                this._width = value;
            }
        }
        public uint Bombs {
            get {
                return this._bombs;
            }
            set {
                if (Demineur.MinEmptyCells > this._height * this._width - value)
                    throw new ArgumentException("Attempt to set bombs with a value exceeding limits");
                this._bombs = value;
            }
        }
        public Map Map {
            get {
                return this._map;
            }
        }
        public override string ToString()
        {
            return this._map.ToString();
        }
    }
}