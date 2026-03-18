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
            if (t.Name != ItemNames.AgedBrie && t.Name != ItemNames.BackstagePasses)
            {
                if (t.Quality > 0)
                {
                    if (t.Name != ItemNames.Sulfuras)
                    {
                        t.Quality -= 1;
                    }
                }
            }
            else
            {
                if (t.Quality < 50)
                {
                    t.Quality += 1;

                    if (t.Name == ItemNames.BackstagePasses)
                    {
                        if (t.SellIn < 11)
                        {
                            if (t.Quality < 50)
                            {
                                t.Quality += 1;
                            }
                        }

                        if (t.SellIn < 6)
                        {
                            if (t.Quality < 50)
                            {
                                t.Quality += 1;
                            }
                        }
                    }
                }
            }

            if (t.Name != ItemNames.Sulfuras)
            {
                t.SellIn -= 1;
            }

            if (t.SellIn < 0)
            {
                if (t.Name != ItemNames.AgedBrie)
                {
                    if (t.Name != ItemNames.BackstagePasses)
                    {
                        if (t.Quality > 0)
                        {
                            if (t.Name != ItemNames.Sulfuras)
                            {
                                t.Quality -= 1;
                            }
                        }
                    }
                    else
                    {
                        t.Quality -= t.Quality;
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