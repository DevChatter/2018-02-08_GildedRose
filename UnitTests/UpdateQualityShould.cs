using System.Collections.Generic;
using DevChatter.GildedRose.Console;
using Xunit;

namespace UnitTests
{
    public class UpdateQualityShould
    {
        [Fact]
        public void RunWithoutError_GivenEmptyCollection()
        {
            var statusUpdater = new InventoryStatusUpdater();

            statusUpdater.UpdateQuality(new List<Item>());
        }
    }
}
