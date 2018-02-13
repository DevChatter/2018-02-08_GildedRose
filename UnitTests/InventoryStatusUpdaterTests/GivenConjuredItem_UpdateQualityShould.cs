using System.Collections.Generic;
using DevChatter.GildedRose.Console;
using Xunit;

namespace UnitTests.InventoryStatusUpdaterTests
{
    public class GivenConjuredItem_UpdateQualityShould
    {
        private InventoryStatusUpdater _statusUpdater = new InventoryStatusUpdater();

        [Fact]
        public void ReduceQualityByTwo()
        {
            var conjuredItem = new Item { Name = "Conjured Sword", Quality = 20, SellIn = 10 };
            var items = new List<Item> { conjuredItem };

            _statusUpdater.UpdateQuality(items);

            Assert.Equal(18, conjuredItem.Quality);
        }

        [Fact]
        public void ReduceQualityByFour_AfterSellInReachesZero()
        {
            var conjuredItem = new Item { Name = "Conjured Sword", Quality = 20, SellIn = 1 };
            var items = new List<Item> { conjuredItem };

            _statusUpdater.UpdateQuality(items); // -2
            _statusUpdater.UpdateQuality(items); // -4
            _statusUpdater.UpdateQuality(items); // -4

            Assert.Equal(10, conjuredItem.Quality);
        }

        [Fact]
        public void FloorQualityAtZero_GivenSellInRemains()
        {
            var conjuredItem = new Item { Name = "Conjured Sword", Quality = 1, SellIn = 10 };
            var items = new List<Item> { conjuredItem };

            _statusUpdater.UpdateQuality(items);

            Assert.Equal(0, conjuredItem.Quality);
        }

        [Fact]
        public void FloorQualityAtZero_GivenSellInZero()
        {
            var conjuredItem = new Item { Name = "Conjured Sword", Quality = 3, SellIn = 0 };
            var items = new List<Item> { conjuredItem };

            _statusUpdater.UpdateQuality(items);

            Assert.Equal(0, conjuredItem.Quality);
        }
    }
}