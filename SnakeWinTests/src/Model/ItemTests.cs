using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Snake.Tests
{
    [TestClass]
    public class Itemtests
    {
        [TestMethod]
        public void FoodExist()
        {
            Grid grid = new Grid(new Tuple<int, int>(2, 1));
            grid.CommenceGame();

            Assert.IsTrue(grid.Items.Count == 1);
        }
    }
}