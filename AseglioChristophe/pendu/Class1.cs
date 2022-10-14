using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;

class Character
{
    public char value;  //propriétés
    public bool isHidden;

    public Character(char value)
    {
        this.value = value;  //réferre aux propriétés
        this.isHidden = true;
    }
}

class Pendu
{
    public int lives;
    public List<Character> value;

    public Pendu(string secretWord) //constructeur
    {
        lives = 10;
        this.value = new List<Character>();

        foreach (char c in secretWord)
        {
            this.value.Add(new Character(c));
        }
    }
    public override string ToString()
    {
        string ret = "";
        foreach (Character l in this.value)
        {
            if (l.isHidden == false)
            {
                ret += l.value;
            }
            else
            {
                ret += '_';
            }
        }
        return ret;
    }

    public bool Attempt(char input)
    {
        bool ret = false;

        foreach (Character c in this.value)
        {
            if (c.value == input)
            {
                c.isHidden = false;
                ret = true;
            }
        }
        if (ret == false)
        {
            this.lives -= 1;
        }
        return ret;
    }

    public bool IsLost()
    {
        return this.lives <= 0; //expression qui se traduit par un booléen (si lives 0 return true)
    }
    public bool IsRevealed()
    {
        foreach (Character c in this.value)
        {
            if (c.isHidden == true)
            {
                return false;
            }
        }
        return true;
    }
}

