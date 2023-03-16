using System.Collections.Generic;
using System.Linq;

namespace MTGDataGatherer.service;

public class ManaData
{
    public float AverageCmc;
    public Dictionary<string, float> ManaRatio;
    public Dictionary<string, float> ManaCount;

    public ManaData(List<CardData> dataSet)
    {
        if (dataSet.Count == 0)
        {
            AverageCmc = 0;
            
        }
        else
        {
            ManaRatio = new Dictionary<string, float>();
            ManaCount = new Dictionary<string, float>();
            float currSumCmc = 0, pipTotal = 0;
            var  cardsWithCmc = 0;
            foreach (var cardData in dataSet)
            {
                if (cardData.CombinedManaCost != null)
                {
                    currSumCmc += cardData.CombinedManaCost.Value;
                    cardsWithCmc++;
                }

                pipTotal += AddManaPips(cardData.ManaCost);
            }

            AverageCmc = currSumCmc / cardsWithCmc;
            if (ManaCount.Count > 0)
            {
                foreach (var color in ManaCount)
                {
                    ManaRatio.Add(color.Key, color.Value / pipTotal);
                }
            }
        }
    }

    private int AddManaPips(string manaCost)
    {
        // Parse card mana cost into associated values
        // i.e. {1}{U}{B} will build a list of {"1","U","B"}
        var manaList = manaCost.Split('{', '}').Where((item, index) => index % 2 != 0).ToList();
        var pipTotal = 0;
        
        foreach (var mana in manaList)
        {
            //if value converts to an integer, ignore it.
            if (!int.TryParse(mana, out int value))
            {
                if (ManaCount.ContainsKey(mana))
                {
                    ManaCount[mana]++;
                }
                else
                {
                    ManaCount.Add(mana,1);
                }

                pipTotal++;
            }
        }

        return pipTotal;
    }
}