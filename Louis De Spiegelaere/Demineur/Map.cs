namespace test {
    public class Map {
        public enum Result {
            outOfBounds,
            emptyCell,
            Bomb,
            numberedCell,
            alreadyVisible
        }
        private Cell[][] matrix;
        private uint height;
        private uint width;
        public Map(uint height, uint width, uint countBombs) {
            this.height = height;
            this.width = width;
            this.matrix = this.SetupMatrix(height, width, countBombs);
        }
        private Cell[][] SetupMatrix(uint height, uint width, uint countBombs) {
            Cell[][] ret = new Cell[height][];
            Random rnd = new Random();

            for (int i = 0; i < height; i++) {
                ret[i] = new Cell[width];
                for (int j = 0; j < width; j++) {
                    ret[i][j] = new Cell(this, i, j);
                }
            }
            for (int i = 0; i < countBombs; i++) {
                int random_line;
                int random_column;
                do {
                    random_line = rnd.Next(0, (int)height);
                    random_column = rnd.Next(0, (int)width);
                } while (ret[random_line][random_column].IsBomb);
                ret[random_line][random_column].IsBomb = true;
            }
            return ret;
        }
        private bool IsValidLocation(int line, int column) {
            if (column >= this.width || column < 0)
                return false;
            if (line >= this.height || line < 0)
                return false;
            return true;
        }
        public bool IsResolved() {
            for (int i = 0; i < this.matrix.Length; i++) {
                for (int j = 0; j < this.matrix[i].Length; j++) {
                    if (!this.matrix[i][j].IsVisible && !this.matrix[i][j].IsBomb)
                        return false;
                }
            }
            return true;
        }
        public Cell GetCellIn(int line, int column) {
            if (!this.IsValidLocation(line, column)) return null;
            return this.matrix[line][column];
        }
        public Map.Result DiscoverCell(int line, int column) {
            Cell c = this.GetCellIn(line, column);
            if (c == null)
                return Map.Result.outOfBounds;
            if (c.IsVisible)
                return Map.Result.alreadyVisible;
            if (c.IsBomb) {
                c.IsVisible = true;
                return Map.Result.Bomb;
            }
            if (c.BombNeighbor != 0) {
                c.IsVisible = true;
                return Map.Result.numberedCell;
            }
            c.IsVisible = true;
            for (int i = -1; i <= 1; i++) {
                for (int j = -1; j <= 1; j++) {
                    int y = c.Line + i;
                    int x = c.Column + j;
                    this.DiscoverCell(y, x);
                }
            }
            return Map.Result.emptyCell;
        }
        public override string ToString() {
            string ret = "";
            for (int i = 0; i < this.matrix.Length; i++) {
                for (int j = 0; j < this.matrix[i].Length; j++) {
                        ret += this.matrix[i][j] + ((j == this.matrix[i].Length - 1) ? "" : " ");
                }
                if (i < this.matrix.Length - 1) ret += "\n";
            }
            return ret;
        }
    }
}