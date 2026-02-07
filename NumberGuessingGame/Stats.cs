using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame
{
    public class Stats
    {
        public int GamesPlayed { get; private set; }
        public int? BestAttempts { get; private set; }

        public Stats()
        {
            GamesPlayed = 0;
            BestAttempts = null;
        }


        public void UpdateStats(int attempts)
        {
            GamesPlayed++;

            if (BestAttempts == null || attempts < BestAttempts)
            {
                BestAttempts = attempts;
            }
        }
    }
}
