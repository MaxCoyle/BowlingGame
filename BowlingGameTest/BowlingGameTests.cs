using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGameTest
{
    [TestClass]
    public class BowlingGameTests
    {
        private static Game CreateSut()
        {
            return new Game();
        }

        [TestMethod]
        [DataRow(0, 0)]
        [DataRow(1, 20)]
        [DataRow(2, 40)]
        [DataRow(3, 60)]
        [DataRow(4, 80)]
        public void TestOpenFrame(int pins, int expected)
        {
            // An open frame in tenpin bowling refers to a frame in which the player made neither a strike nor a spare.
            var game = CreateSut();

            for (var i = 0; i < 20; i++)
            {
                game.Roll(pins);
            }

            Assert.AreEqual(expected, game.Score());
        }

        [TestMethod]
        [DataRow(9, 1, 1, 12)]
        [DataRow(8, 2, 2, 14)]
        [DataRow(7, 3, 3, 16)]
        [DataRow(6, 4, 4, 18)]
        [DataRow(5, 5, 5, 20)]
        public void TestSpareFrame(int firstThrowPins, int secondThrowPins, int thirdThrowPins, int expected)
        {
            var game = CreateSut();
            game.Roll(firstThrowPins); // Anything but a strike
            game.Roll(secondThrowPins); // All pins down for a spare
            game.Roll(thirdThrowPins); // First throw of next frame

            // Roll zeros for the rest of the game
            for (int i = 0; i < 17 ; i++)
            {
                game.Roll(0);
            }

            Assert.AreEqual(expected, game.Score());
        }

        [TestMethod]
        [DataRow(1, 1, 14)]
        [DataRow(2, 2, 18)]
        [DataRow(3, 3, 22)]
        [DataRow(4, 4, 26)]
        public void TestStrikeFrame(int firstThrowPins, int secondThrowPins, int expected)
        {
            var game = CreateSut();
            game.Roll(10); // All ten pins in one throw
            game.Roll(firstThrowPins); // First throw of next frame
            game.Roll(secondThrowPins); // Second throw of next frame

            Assert.AreEqual(expected, game.Score());
        }
    }
}
