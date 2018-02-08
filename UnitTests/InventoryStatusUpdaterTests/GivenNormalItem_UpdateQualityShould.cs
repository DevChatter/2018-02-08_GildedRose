using System.Collections.Generic;
using DevChatter.GildedRose.Console;
using Xunit;

namespace UnitTests.InventoryStatusUpdaterTests
{
    public class GivenNormalItem_UpdateQualityShould
    {
        [Fact]
        public void RunWithoutError()
        {
            var statusUpdater = new InventoryStatusUpdater();

            statusUpdater.UpdateQuality(new List<Item>());
        }

        [Fact]
        public void LowerQuality()
        {
            var statusUpdater = new InventoryStatusUpdater();
            var normalItem = new Item { Name = "Normal Normal", Quality = 20, SellIn = 10 };
            var items = new List<Item> {normalItem};

            statusUpdater.UpdateQuality(items);

            Assert.Equal(19, normalItem.Quality);
        }

        [Fact]
        public void LowerSellIn()
        {
            var statusUpdater = new InventoryStatusUpdater();
            var normalItem = new Item { Name = "Normal Normal", Quality = 20, SellIn = 10 };
            var items = new List<Item> {normalItem};

            statusUpdater.UpdateQuality(items);

            Assert.Equal(9, normalItem.SellIn);
        }

        [Fact]
        public void FloorQualityAtZero()
        {
            var statusUpdater = new InventoryStatusUpdater();
            var normalItem = new Item { Name = "Normal Normal", Quality = 1, SellIn = 10 };
            var items = new List<Item> {normalItem};

            statusUpdater.UpdateQuality(items);
            statusUpdater.UpdateQuality(items);

            Assert.Equal(0, normalItem.Quality);
        }

        [Fact]
        public void AllowNegativeSellIn()
        {
            var statusUpdater = new InventoryStatusUpdater();
            var normalItem = new Item { Name = "Normal Normal", Quality = 50, SellIn = 1 };
            var items = new List<Item> {normalItem};

            statusUpdater.UpdateQuality(items);
            statusUpdater.UpdateQuality(items);

            Assert.Equal(-1, normalItem.SellIn);
        }

        [Fact]
        public void DecreaseQualityTwiceAsFastAfterSellInReachesZero()
        {
            var statusUpdater = new InventoryStatusUpdater();
            var normalItem = new Item { Name = "Normal Normal", Quality = 50, SellIn = 1 };
            var items = new List<Item> {normalItem};

            statusUpdater.UpdateQuality(items); // -1
            statusUpdater.UpdateQuality(items); // -2
            statusUpdater.UpdateQuality(items); // -2

            Assert.Equal(45, normalItem.Quality);
        }
    }
}
