using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Service;
using Newtonsoft.Json;

namespace MTGDataGatherer.service
{
    public class CardFetcher : ICardFetcher
    {
        private readonly ICardService _cardService;
        private readonly ILogger<CardFetcher> _logger; 
        // ReSharper disable once ConvertToPrimaryConstructor
        public CardFetcher(IMtgServiceProvider serviceProvider, ILogger<CardFetcher> logger)
        {
            _cardService = serviceProvider.GetCardService();
            _logger = logger;
        }

        public async Task<IOperationResult<List<string>>> GetCardTypesAsync()
        {
            return await _cardService.GetCardTypesAsync();
        }

        public async Task<CardData> GetCardByNameAsync(string cardName)
        {
            var result = await _cardService.Where(x => x.Name, cardName).AllAsync();

            if (result.IsSuccess)
            {
                return  new CardData(result.Value[0]);
            }
            
            _logger.LogError("Could not find card '" + cardName + "', returning blank card...");
            return new CardData();
            
        }

        public async Task<List<CardData>> GetCardListByNameAsync(List<string> cards)
        {
            var ret = new List<CardData>();

            foreach (var card in cards)
            {
                var cardResult = await _cardService.Where(x => x.Name, card).AllAsync();

                if (cardResult.IsSuccess)
                {
                    ret.Add(new CardData(cardResult.Value[0]));
                }
                else
                {
                    _logger.LogError("Could not find card '" + card + "', continuing without card...");
                }
            }

            return ret;
        }

        public async Task<string> GetManaData(List<string> cards)
        {
            var cardSet = await GetCardListByNameAsync(cards);
            var data =  new ManaData(cardSet);

            var jret = new
            {
                AverageCMC = data.AverageCmc,
                data.ManaRatio,
                data.ManaCount
            };

            return JsonConvert.SerializeObject(jret);
        }
    }
}