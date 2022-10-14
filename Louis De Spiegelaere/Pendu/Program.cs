using System;
using System.Collections.Generic;
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
    public bool Attempt(char c) {
        bool ret = false;
        foreach (Letter l in this.value) {
            if (Char.ToLower(c) == Char.ToLower(l.Value)) {
                if (l.Unhide()) ret = true;
            }
        }
        return ret;
    }
    public string GetWord() {
        string ret = "";
        foreach (Letter l in this.value) {
            ret += l.Value;
        }
        return ret;
    }
    public bool IsFullyUnhidden() {
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
    private List<char> AlreadyTried;
    private int _turn;
    private int _hp;
    public Game(string[] words, int hp) {
        this.AlreadyTried = new List<char>();
        word = new HiddenWord(words);
        this._turn = 0;
        this._hp = (hp <= 0) ? 1 : hp;
    }
    public int Turn {
        get {
            return this._turn;
        }
    }
    public int Hp {
        get {
            return this._hp;
        }
    }
    private bool IsCharInList(char c) {
        return this.AlreadyTried.Contains(c);
    }
    private string ListAsString() {
        string ret = "";
        for (int i = 0; i < this.AlreadyTried.Count; i++) {
            ret += this.AlreadyTried[i] + ((i == this.AlreadyTried.Count - 1) ? "" : ", ");
        }
        return ret;
    }

    public bool Play() {
        while (this._hp > 0) {
            Console.Clear();
            Console.WriteLine(String.Format("{0}. MOT CACHE : [{1}]", this._turn, this.word));
            Console.WriteLine(String.Format("Vies restantes : {0}", this._hp));
            Console.WriteLine(String.Format("Lettres déjà essayées : {0}", this.ListAsString()));
            Console.WriteLine("Entrez un caractère : ");
            char input = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (word.Attempt(input)) {
                Console.WriteLine("Bravo !");
            } else {
                if (!IsCharInList(input) && !this.word.GetWord().Contains(input)) {
                    this.AlreadyTried.Add(input);
                    this._hp--;
                    Console.WriteLine("Dommage !");
                }
            }
            if (word.IsFullyUnhidden()) {
                Console.Clear();
                Console.WriteLine(String.Format("Félicitation, le mot était bien [{0}].\nIl vous restait {1} vie(s)", this.word, this._hp));
                return true;
            }
            this._turn++;
        }
        Console.Clear();
        Console.WriteLine(String.Format("Dommage, le mot était [{0}].\nLa partie a duré {1} tour(s)", this.word.GetWord(), this._turn));
        return false;
    }
}

class Prog {
    static void Main(string[] args) {
        Game game = new Game(new string[]{
            "Programmation",
            "Espace",
            "De Spiegelaere",
            "Elon Musk",
            "Francois Damien",
            "Ordinateur",
            "Age Of Empire 3",
            "Game Of Thrones",
            "Salle de bain"
            }, 5);
        game.Play();
    }
}