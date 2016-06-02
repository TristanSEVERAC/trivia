using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace Trivia
{
    class Player
    {
       

        private String playerName;
        private readonly int _nbPursesToWin;
        private int position;
        private int purses;
        private bool isInPenaltyBox;



        public Player(string playerName, int nbPursesToWin)
        {
            this.playerName = playerName;
            _nbPursesToWin = nbPursesToWin;
            this.position = 0;
            this.purses = 0;
            this.isInPenaltyBox = false;
        }

        public void WinOnePurse()
        {
            this.purses++;
            
        }

        public bool didPlayerWin()
        {
            return !(this.purses == _nbPursesToWin);
        }

        public void changePosition(int roll)
        {
            this.position += roll;
            if (this.position > 11)
            {
                this.position -= 12;
            }
        }

        public string PlayerName
        {
            get { return playerName; }
        }

        public int Position
        {
            get { return position; }
        }

        public int Purses
        {
            get { return purses; }
        }

        public bool IsInPenaltyBox
        {
            get { return isInPenaltyBox; }
            private set { isInPenaltyBox = value; }
        }

        public void setIsInPenaltyBox(bool value)
        {
            this.IsInPenaltyBox = value;
        }

    }
}
