namespace test {
    public class Cell {
        public const char BombChar = 'X';
        private Map _mapHandle;
        private bool _isVisible;
        private bool _isBomb;
        private int _line;
        private int _column;
        private bool _hasFlag;
        public Cell(Map mapHandle, int line, int column) {
            this._mapHandle = mapHandle;
            this._isVisible = false;
            this._isBomb = false;
            this._hasFlag = false; 
            this._line = line;
            this._column = column;
        }
        public string GetUnhiddenCell() {
            if (this._isBomb)
                return String.Format("[{0}]", Cell.BombChar);
            return String.Format("[{0}]", this.BombNeighbor);
        }
        public bool SetFlag() {
            if (this._hasFlag) return false;
            this._hasFlag = true;
            return true;
        }
        public bool UnsetFlag() {
            if (!this._hasFlag) return false;
            this._hasFlag = false;
            return false;
        }
        public bool IsVisible {
            get {
                return this._isVisible;
            }
            set {
                this._hasFlag = false;
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
                        Cell c;
                        try {
                            c = this._mapHandle.GetCellIn(tmpLine, tmpCol);
                            if (c._isBomb) ret++;
                        } catch (ArgumentException) {}
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
        public int Column {
            get {
                return this._column;
            }
        }
        public bool Flagged {
            get {
                return this._hasFlag;
            }
        }
        public override string ToString()
        {
            if (!this._isVisible) {
                if (!this._hasFlag)
                    return "[ ]";
                return "[!]";
            }
            if (this._isBomb)
                return String.Format("[{0}]", Cell.BombChar);
            return String.Format("[{0}]", this.BombNeighbor);
        }
    }
}