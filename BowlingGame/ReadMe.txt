// Simple working version of score

//        public int Score()
//        {
//            var score = 0;
//            var roll = 0;
//
//            for (var frame = 0; frame < 10; frame++)
//            {
//                if (rolls[roll] == 10)
//                {
//                    score += 10 + rolls[roll + 1] + rolls[roll + 2];
//                    roll++;
//                }
//                else if (rolls[roll] + rolls[roll + 1] == 10)
//                {
//                    score += 10 + rolls[roll + 2];
//                    roll += 2;
//                }
//                else
//                {
//                    score += rolls[roll] + rolls[roll + 1];
//                    roll += 2;
//                }
//
//            }
//
//            return score;
//        }