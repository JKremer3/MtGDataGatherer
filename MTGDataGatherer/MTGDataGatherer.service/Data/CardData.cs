using System;
using MtgApiManager.Lib.Model;

namespace MTGDataGatherer.service;

public class CardData
{
    
    public string CardName { get; set; }
    public string[] CardColors{ get; set; }
    
    public string ManaCost { get; set; }
    public float? CombinedManaCost{ get; set; }
    
    // Return built CardInfo
    public CardData(ICard card)
    {
        CardName = card.Name;
        CardColors = card.ColorIdentity;
        ManaCost = card.ManaCost;
        CombinedManaCost = card.Cmc;
    }

    // Return Empty CardInfo
    public CardData()
    {
        CardName = "";
        CardColors = new String[] {""};
        ManaCost = "";
        CombinedManaCost = 0;
    }
}