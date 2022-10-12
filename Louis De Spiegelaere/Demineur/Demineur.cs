namespace test {
    public class Demineur {
        private class Cursor {
            private Cell _loc;
            private Demineur _d;
            public Cursor(int line, int column, Demineur d) {
                this._d = d;
                try {
                    this._loc = this._d.Map.GetCellIn(line, column);
                } catch (ArgumentException e) {
                    throw new ArgumentException(e.Message);
                }
            }
            public override string ToString()
            {
                return String.Format("[{0};{1}]", this._loc.Line, this._loc.Column);
            }
            public void AttemptToMove(int line, int column) {
                Cell c;
                try {
                    c = this._d.Map.GetCellIn(line, column);
                } catch (ArgumentException e){
                    throw new ArgumentException(e.Message);
                }
                this._loc = c;
            }
            public Cell Location {
                get {
                    return this._loc;
                }
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
            this._map = new Map(this._height, this._width, this._bombs);
            cursor = new Cursor(0, 0, this);
        }
    public bool Play() {
        while (!this.Map.IsResolved()) {
            Console.Clear();
            Console.WriteLine(this);
            Console.WriteLine();
            Console.WriteLine(this.cursor);
            ConsoleKey ck = Console.ReadKey().Key;
            Console.WriteLine();
            switch (ck) {
                case ConsoleKey.UpArrow:
                    try {
                        this.cursor.AttemptToMove(this.cursor.Location.Line - 1, this.cursor.Location.Column);
                    } catch (ArgumentException e) {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case ConsoleKey.DownArrow:
                    try {
                        this.cursor.AttemptToMove(this.cursor.Location.Line + 1, this.cursor.Location.Column);
                    } catch (ArgumentException e) {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    try {
                        this.cursor.AttemptToMove(this.cursor.Location.Line, this.cursor.Location.Column - 1);
                    } catch (ArgumentException e) {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case ConsoleKey.RightArrow:
                    try {
                        this.cursor.AttemptToMove(this.cursor.Location.Line, this.cursor.Location.Column + 1);
                    } catch (ArgumentException e) {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case ConsoleKey.Spacebar:
                    try {
                        if (this.Map.DiscoverCell(this.cursor.Location.Line, this.cursor.Location.Column) == Map.Result.Bomb) {
                            Console.WriteLine("Perdu !");
                            return false;
                        }
                    } catch (ArgumentException e) {
                        Console.WriteLine(e.Message);
                    }
                    break;
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