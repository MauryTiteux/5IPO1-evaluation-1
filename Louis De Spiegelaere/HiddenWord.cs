public class Letter {
    private char _value;
    private bool _hidden;
    public Letter(char value) {
        this._value = value;
        this._hidden = (value == ' ') ? false : true;
    }
    public char Value {
        get {
            return this._value;
        }
    }
    public bool Hidden {
        get {
            return this._hidden;
        }
    }
    public bool Unhide() {
        if (!this._hidden) return false;
        this._hidden = false;
        return true;
    }

    public bool Hide() {
        if (this._hidden) return false;
        this._hidden = true;
        return true;
    }
}
public class HiddenWord {
    public List<Letter> value;
    public HiddenWord(string[] words) {
        this.value = new List<Letter>{};
        string word = HiddenWord.PickRandomWord(words);
        foreach (char c in word) {
            this.value.Add(new Letter(c));
        }
    }
    public static string PickRandomWord(string[] words) {
        Random rnd = new Random();
        return words[rnd.Next(0, words.Length)];
    }
    public bool attempt(char c) {
        bool ret = false;
        foreach (Letter l in this.value) {
            if (Char.ToLower(c) == Char.ToLower(l.Value)) {
                if (l.Unhide()) ret = true;
            }
        }
        return ret;
    }
    public bool isFullyUnhidden() {
        foreach (Letter l in this.value) {
            if (l.Hidden) return false;
        }
        return true;
    }
    public override string ToString()
    {
        string ret = "";
        foreach(Letter l in this.value) {
            ret += (l.Hidden) ? "_" : l.Value;
        }
        return ret;
    }
}
class Game {
    public HiddenWord word;
    private int _turn;
    private int _failures;
    private int _successes;
    public Game() {
        word = new HiddenWord(new string[]{
            "Programmation",
            "Espace",
            "De Spiegelaere",
            "Elon Musk",
            "Francois Damien",
            "Ordinateur",
            "Age Of Empire 3",
            "Game Of Thrones",
            "Salle de bain"
            });
        this._turn = 0;
        this._failures = 0;
        this._successes = 0;
    }
    public int Turn {
        get {
            return this._turn;
        }
    }
    public void Play() {
        while (!word.isFullyUnhidden()) {
            Console.Clear();
            Console.WriteLine(String.Format("{0}. MOT CACHE : [{1}]", this._turn, this.word));
            Console.WriteLine("Entrez un caractère : ");
            char input = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (word.attempt(input)) {
                this._successes++;
                Console.WriteLine("Bravo !");
            } else {
                this._failures++;
                Console.WriteLine("Dommage !");
            }
            this._turn++;
        }
        Console.Clear();
        Console.WriteLine(String.Format("Félicitation, le mot était bien [{0}]. Vous avez trouvé en {1} tour(s)({2}% succes, {3}% echec)", this.word, this._turn, Math.Round(((double)this._successes / this._turn) * 100), Math.Round(((double)this._failures / this._turn) * 100)));
    }
}

class Prog {
    static void Main(string[] args) {
        Game game = new Game();
        game.Play();
    }
}