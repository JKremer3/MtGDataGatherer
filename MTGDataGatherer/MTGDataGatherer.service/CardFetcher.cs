using System.Collections.Generic;
using System.Threading.Tasks;
using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Service;

namespace MTGDataGatherer.service
{
    public class CardFetcher : ICardFetcher
    {
        private IMtgServiceProvider _serviceProvider;
        private ICardService _cardService;

        public CardFetcher(IMtgServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _cardService = _serviceProvider.GetCardService();
        }

        public async Task<IOperationResult<List<string>>> GetCardTypesAsync()
        {
            return await _cardService.GetCardTypesAsync();
        }

        public async Task<CardInfo> GetCardByNameAsync(string cardName)
        {
            var result = await _cardService.Where(x => x.Name, cardName).AllAsync();

            if (result.IsSuccess)
            {
                return  new CardInfo(result.Value[0]);
            }
            else
            {
                return new CardInfo();
            }
        }
    }
}