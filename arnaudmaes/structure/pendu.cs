
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arnaudmaes.Structures
{
    internal struct pendu 
    {
        private int _life = 5;
        public int life { get {return _life;} set { _life = value; }}

        private int _generalCount;
        public int generalCount { get {return _generalCount;} set { _generalCount = value; }}

        private int _countTabRater = 5;
        public int countTabRater { get {return _countTabRater;} set { _countTabRater = value; }}

        private int _countTabWin = 5;
        public int countTabWin { get {return _countTabWin;} set { _countTabWin = value; }}

        private char[] _lettreTrouve = new char[5];

        public char[] lettreTrouve { get {return _lettreTrouve;}}
        private char[] _lettrerater = new char[5];
        public char[] lettrerater { get {return _lettrerater;}}
        private char[] _mot;
        public char[] mot { get {return _mot;}}


        public pendu(char[] mot, int generalCount):this()
        {
            _mot = mot;
            _generalCount = generalCount;
        }

        public string verif(string lettre)
        {
         int count = 0;
         for(int i=0;i<mot.Length;i++){
            if(mot[i]==lettre[0]){
                count++;
                generalCount--;
            }
         }
         if(count>0){
            System.Console.WriteLine("félicitation");
            lettreTrouve[lettreTrouve.Length-countTabWin]= lettre[0];
            countTabWin--;
         }else{
            life--;
            lettrerater[lettrerater.Length-countTabRater] = lettre[0];
            System.Console.WriteLine("Mauvais");
            countTabRater--;
         }
         return lettre;   
        }

        


    }
}