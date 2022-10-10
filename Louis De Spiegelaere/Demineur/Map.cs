namespace test {
    public class Map {
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
        public bool IsValidLocation(int line, int column) {
            if (column >= this.width || column < 0)
                return false;
            if (line >= this.height || line < 0)
                return false;
            return true;
        }
        public Cell GetCellIn(int line, int column) {
            return this.matrix[line][column];
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