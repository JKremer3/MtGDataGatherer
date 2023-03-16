using System.Collections.Generic;
using System.Threading.Tasks;
using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Model;

namespace MTGDataGatherer.service
{
    public interface ICardFetcher
    {
        public Task<IOperationResult<List<string>>> GetCardTypesAsync();

        public Task<CardData> GetCardByNameAsync(string cardName);

        public Task<List<CardData>> GetCardListByNameAsync(List<string> cards);

        public Task<string> GetManaData(List<string> cards);
    }
}