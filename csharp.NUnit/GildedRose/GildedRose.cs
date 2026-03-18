using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        foreach (var t in _items)
        {
            if (t.Name == ItemNames.Sulfuras)
            {
                continue;
            }

            if (t.Name != ItemNames.AgedBrie && t.Name != ItemNames.BackstagePasses)
            {
                if (t.Quality > 0)
                {
                    t.Quality -= 1;
                }
            }
            else
            {
                if (t.Quality < 50)
                {
                    t.Quality += 1;

                    if (t.Name == ItemNames.BackstagePasses)
                    {
                        if (t.SellIn < 11 && t.Quality < 50)
                        {
                            t.Quality += 1;
                        }

                        if (t.SellIn < 6 && t.Quality < 50)
                        {
                            t.Quality += 1;
                        }
                    }
                }
            }

            t.SellIn -= 1;

            if (t.SellIn < 0)
            {
                if (t.Name != ItemNames.AgedBrie)
                {
                    if (t.Name != ItemNames.BackstagePasses)
                    {
                        if (t.Quality > 0)
                        {
                            t.Quality -= 1;
                        }
                    }
                    else
                    {
                        t.Quality = 0;
                    }
                }
                else
                {
                    if (t.Quality < 50)
                    {
                        t.Quality += 1;
                    }
                }
            }
        }
    }
}