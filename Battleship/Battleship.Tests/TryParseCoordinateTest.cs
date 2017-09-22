using BattleShip.BLL.Requests;
using BattleShip.UI;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Tests
{
    [TestFixture]
    public class TryParseCoordinateTest
    {
        [TestCase("a7",true,1,7)]
        [TestCase("b9", true, 2, 9)]
        [TestCase("7a", false, -1, -1)]
        [TestCase("z69", false, null, null)]

        public void ParseStringToCoordinate(string userInput, bool expected, int xCoordinate, int yCoordinate)
        {
            Coordinate testCoordinate;
            // public static bool CoordinateTryParse(string userInput, out Coordinate validCoordinate);
            var isValidCoordinate = ConsoleInput.CoordinateTryParse(userInput, out testCoordinate);

            Assert.AreEqual(expected, isValidCoordinate);
            if(isValidCoordinate)
            {
                Assert.AreEqual(xCoordinate, testCoordinate.XCoordinate);
                Assert.AreEqual(yCoordinate, testCoordinate.YCoordinate);
            }
            
        }
    }
}
