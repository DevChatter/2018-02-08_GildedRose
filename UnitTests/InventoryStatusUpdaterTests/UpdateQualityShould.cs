using System.Collections.Generic;
using DevChatter.GildedRose.Console;
using Xunit;

namespace UnitTests.InventoryStatusUpdaterTests
{
    public class UpdateQualityShould
    {
        [Fact]
        public void RunWithoutError_GivenEmptyCollection()
        {
            var statusUpdater = new InventoryStatusUpdater();

            statusUpdater.UpdateQuality(new List<Item>());
        }

        [Fact]
        public void LowerQuality_GivenNormalItem()
        {
            var statusUpdater = new InventoryStatusUpdater();

            var normalItem = new Item { Name = "Normal Normal", Quality = 20, SellIn = 10 };
            var items = new List<Item> {normalItem};
            statusUpdater.UpdateQuality(items);

            Assert.Equal(normalItem.Quality, normalItem.Quality - 1);
        }
    }
}
