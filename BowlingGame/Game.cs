using System.Collections;
using System.Collections.Generic;

namespace BowlingGame
{ 
    public class Game
    {
        // ReSharper disable once InconsistentNaming
        private readonly int[] rolls;
        // ReSharper disable once InconsistentNaming
        private int currentRoll;

        private const int MaxRolls = 21;
        private const int MaxFrames = 10;

        public Game()
        {
            rolls = new int[MaxRolls];
        }

        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        public int Score()
        {
            var score = 0;
            var roll = 0;
            var scoringRules = new ScoringRules().Rules;

            for (var frame = 0; frame < MaxFrames; frame++)
            {
                foreach (var scoringRule in scoringRules)
                {
                    if (rolls.Length == roll + 1) break;
                    scoringRule.Execute(rolls, ref roll, ref score);
                }

            }

            return score;
        }
    }
}