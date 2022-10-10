namespace test {
    public class Cell {
        public const char BombChar = 'X';
        private Map _mapHandle;
        private bool _isVisible;
        private bool _isBomb;
        private int _line;
        private int _column;
        public Cell(Map mapHandle, int line, int column) {
            this._mapHandle = mapHandle;
            this._isVisible = false;
            this._isBomb = false;
            this._line = line;
            this._column = column;
        }
        public bool IsVisible {
            get {
                return this._isVisible;
            }
            set {
                this._isVisible = value;
            }
        }
        public bool IsBomb {
            get {
                return this._isBomb;
            }
            set {
                this._isBomb = value;
            }
        }
        public int BombNeighbor {
            get {
                int ret = 0;
                for (int i = -1; i <= 1; i++) {
                    for (int j = -1; j <= 1; j++) {
                        int tmpLine = this._line + i;
                        int tmpCol = this._column + j;
                        if (this._mapHandle.IsValidLocation(tmpLine, tmpCol)) {
                            if (this._mapHandle.GetCellIn(tmpLine, tmpCol)._isBomb)
                                ret++;
                        }
                    }
                }
                return ret;
            }
        }
        public int Line {
            get {
                return this._line;
            }
        }
        public override string ToString()
        {
            //if (!this._isVisible)
            //    return "[ ]";
            if (this._isBomb)
                return String.Format("[{0}]", Cell.BombChar);
            return String.Format("[{0}]", this.BombNeighbor);
        }
    }
}