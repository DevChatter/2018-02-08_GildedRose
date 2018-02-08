using System.Collections.Generic;

namespace DevChatter.GildedRose.Console
{
    public class InventoryStatusUpdater
    {
        private const string BackstagePassItemName = "Backstage passes to a TAFKAL80ETC concert";
        private const string AgedBrieItemName = "Aged Brie";
        private const string SulfurasItemName = "Sulfuras, Hand of Ragnaros";
        private const string ConjuredItemPrefix = "Conjured";

        public void UpdateQuality(IList<Item> items)
        {
            foreach (var item in items)
            {
                if (item.Name != AgedBrieItemName && item.Name != BackstagePassItemName)
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != SulfurasItemName)
                        {
                            item.Quality = item.Quality - 1;
                            if (item.Name.StartsWith(ConjuredItemPrefix) && item.Quality > 0)
                            {
                                item.Quality -= 1;
                            }
                        }
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;

                        if (item.Name == BackstagePassItemName)
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (item.Name != SulfurasItemName)
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != AgedBrieItemName)
                    {
                        if (item.Name != BackstagePassItemName)
                        {
                            if (item.Quality > 0)
                            {
                                if (item.Name != SulfurasItemName)
                                {
                                    item.Quality = item.Quality - 1;
                                    if (item.Name.StartsWith(ConjuredItemPrefix) && item.Quality > 0)
                                    {
                                        item.Quality -= 1;
                                    }

                                }
                            }
                        }
                        else
                        {
                            item.Quality = item.Quality - item.Quality;
                        }
                    }
                    else
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
                }
            }
        }
    }
}