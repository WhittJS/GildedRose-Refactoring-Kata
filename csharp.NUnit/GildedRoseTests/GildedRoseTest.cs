using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    #region Normal Items

    [Test]
    public void UpdateQuality_Name_DoesNotChange()
    {
        var items = new List<Item> { new() { Name = "foo", SellIn = 0, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Name, Is.EqualTo("foo"));
    }

    [Test]
    public void UpdateQuality_SellIn_DecreasesByOne()
    {
        var items = new List<Item> { new() { Name = "foo", SellIn = 0, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].SellIn, Is.EqualTo(-1));
    }

    [Test]
    public void UpdateQuality_Quality_DoesNotGoBelowZero()
    {
        var items = new List<Item> { new() { Name = "foo", SellIn = 0, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(0));
    }

    [Test]
    public void UpdateQuality_Quality_DecreasesByOne()
    {
        var items = new List<Item> { new() { Name = "foo", SellIn = 1, Quality = 1 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(0));
    }

    [Test]
    public void UpdateQuality_WhenSellInNegative_DecreasesByTwo()
    {
        var items = new List<Item> { new() { Name = "foo", SellIn = -1, Quality = 8 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(6));
    }

    #endregion

    #region Aged Brie

    [Test]
    public void UpdateQuality_WhenAgedBrieBeforeSellDate_QualityIncreasesByOne()
    {
        var items = new List<Item> { new() { Name = ItemNames.AgedBrie, SellIn = 1, Quality = 8 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(9));
    }

    [Test]
    public void UpdateQuality_WhenAgedBrieAfterSellDate_QualityIncreasesByTwo()
    {
        var items = new List<Item> { new() { Name = ItemNames.AgedBrie, SellIn = 0, Quality = 8 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(10));
    }

    [Test]
    public void UpdateQuality_WhenAgedBrieMaxQuality_QualityDoesNotIncrease()
    {
        var items = new List<Item> { new() { Name = ItemNames.AgedBrie, SellIn = 0, Quality = 50 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(50));
    }

    #endregion

    #region Sulfuras

    [Test]
    public void UpdateQuality_WhenSulfuras_IsNeverAltered()
    {
        var items = new List<Item> { new() { Name = ItemNames.Sulfuras, SellIn = 5, Quality = 80 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(80));
        Assert.That(items[0].SellIn, Is.EqualTo(5));
    }

    #endregion

    #region Backstage Passes

    [Test]
    public void UpdateQuality_WhenBackStagePassExpired_QualityZero()
    {
        var items = new List<Item>
            { new() { Name = ItemNames.BackstagePasses, SellIn = -1, Quality = 40 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(0));
    }

    [Test]
    public void UpdateQuality_WhenBackStagePassGreaterThanTenDays_QualityIncreasesByOne()
    {
        var items = new List<Item>
            { new() { Name = ItemNames.BackstagePasses, SellIn = 15, Quality = 40 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(41));
    }

    [Test]
    public void UpdateQuality_WhenBackStagePassExactlyTenDays_QualityIncreasesByTwo()
    {
        var items = new List<Item>
            { new() { Name = ItemNames.BackstagePasses, SellIn = 10, Quality = 40 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(42));
    }

    [Test]
    public void UpdateQuality_WhenBackStagePassLessThanTenDays_QualityIncreasesByTwo()
    {
        var items = new List<Item>
            { new() { Name = ItemNames.BackstagePasses, SellIn = 9, Quality = 40 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(42));
    }

    [Test]
    public void UpdateQuality_WhenBackStagePassExactlyFiveDays_QualityIncreasesByThree()
    {
        var items = new List<Item>
            { new() { Name = ItemNames.BackstagePasses, SellIn = 5, Quality = 40 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(43));
    }

    [Test]
    public void UpdateQuality_WhenBackStagePassLessThanFiveDays_QualityIncreasesByThree()
    {
        var items = new List<Item>
            { new() { Name = ItemNames.BackstagePasses, SellIn = 4, Quality = 40 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(43));
    }

    [Test]
    public void UpdateQuality_WhenBackStagePassLessThanFiveDays_QualityCapsAtFifty()
    {
        var items = new List<Item>
            { new() { Name = ItemNames.BackstagePasses, SellIn = 4, Quality = 49 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(50));
    }

    [Test]
    public void UpdateQuality_WhenBackStagePassLessThanTenDays_QualityCapsAtFifty()
    {
        var items = new List<Item>
            { new() { Name = ItemNames.BackstagePasses, SellIn = 9, Quality = 49 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(50));
    }

    #endregion

    #region Conjured Items

    [Test]
    public void UpdateQuality_WhenConjured_QualityDecreasesByTwo()
    {
        var items = new List<Item> { new() { Name = ItemNames.Conjured, SellIn = 5, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(8));
    }

    [Test]
    public void UpdateQuality_WhenConjured_SellInDecreasesByOne()
    {
        var items = new List<Item> { new() { Name = ItemNames.Conjured, SellIn = 5, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].SellIn, Is.EqualTo(4));
    }

    [Test]
    public void UpdateQuality_WhenConjuredAfterSellDate_QualityDecreasesByFour()
    {
        var items = new List<Item> { new() { Name = ItemNames.Conjured, SellIn = 0, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(6));
    }

    [Test]
    public void UpdateQuality_WhenConjured_QualityDoesNotGoBelowZero()
    {
        var items = new List<Item> { new() { Name = ItemNames.Conjured, SellIn = 5, Quality = 1 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(0));
    }

    [Test]
    public void UpdateQuality_WhenConjuredAfterSellDate_QualityDoesNotGoBelowZero()
    {
        var items = new List<Item> { new() { Name = ItemNames.Conjured, SellIn = 0, Quality = 3 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(0));
    }

    #endregion
}
