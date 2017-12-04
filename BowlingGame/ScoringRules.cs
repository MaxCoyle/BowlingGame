using System.Collections.Generic;

namespace BowlingGame
{
    public class ScoringRules
    {
        private static bool IsStrike(IReadOnlyList<int> rolls, int roll)
        {
            return rolls[roll] == 10;
        }
        
        private static bool IsSpare(IReadOnlyList<int> rolls, int roll)
        {
            return rolls[roll] + rolls[roll + 1] == 10;
        }

        public interface IScoringRule
        {
            void Execute(int[] rolls, ref int roll, ref int score);
        }

        private class StrikeFrameRule : IScoringRule
        {
            public void Execute(int[] rolls, ref int roll, ref int score)
            {
                if (!IsStrike(rolls, roll)) return;
                score += 10 + rolls[roll + 1] + rolls[roll + 2];
                roll++;
            }
        }

        private class SpareFrameRule : IScoringRule
        {
            public void Execute(int[] rolls, ref int roll, ref int score)
            {
                if (!IsSpare(rolls, roll)) return;
                score += 10 + rolls[roll + 2];
                roll += 2;
            }
        }

        private class OpenFrameRule : IScoringRule
        {
            public void Execute(int[] rolls, ref int roll, ref int score)
            {
                if (IsStrike(rolls, roll) || IsSpare(rolls, roll)) return;
                score += rolls[roll] + rolls[roll + 1];
                roll += 2;
            }
        }

        public List<IScoringRule> Rules = new List<IScoringRule>();

        public ScoringRules()
        {
            Rules.Add(new StrikeFrameRule());
            Rules.Add(new SpareFrameRule());
            Rules.Add(new OpenFrameRule());
        }
    }
}