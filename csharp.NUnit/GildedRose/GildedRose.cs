using System;
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
            switch (t.Name)
            {
                case ItemNames.Sulfuras:
                    continue;
                case ItemNames.AgedBrie:
                    HandleBrie(t);
                    break;
                case ItemNames.BackstagePasses:
                    HandleBackstagePasses(t);
                    break;
                default:
                    t.Quality = Math.Max(0, t.Quality - 1);
                    t.SellIn -= 1;
                    if (t.SellIn >= 0) continue;
                    t.Quality = Math.Max(0, t.Quality - 1);
                    break;
            }
        }
    }

    private static void HandleBackstagePasses(Item t)
    {
        t.Quality = Math.Min(t.Quality + 1, 50);
        if (t.SellIn < 11)
        {
            t.Quality = Math.Min(t.Quality + 1, 50);
        }

        if (t.SellIn < 6)
        {
            t.Quality = Math.Min(t.Quality + 1, 50);
        }

        t.SellIn -= 1;
        if (t.SellIn >= 0) return;
        t.Quality = 0;
    }

    private static void HandleBrie(Item t)
    {
        t.Quality = Math.Min(t.Quality + 1, 50);
        t.SellIn -= 1;
        if (t.SellIn >= 0) return;
        t.Quality = Math.Min(t.Quality + 1, 50);
    }
}