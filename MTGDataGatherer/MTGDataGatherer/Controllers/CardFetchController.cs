using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MtgApiManager.Lib.Core;
using MTGDataGatherer.service;

namespace MTGDataGatherer.Controllers
{
    [ApiController]
    [Route("")]
    public class CardFetchController : ControllerBase
    {
        private readonly ILogger<CardFetchController> _logger;
        private ICardFetcher _cardFetcher;
        public CardFetchController(ILogger<CardFetchController> logger, ICardFetcher cardFetcher)
        {
            _logger = logger;
            _cardFetcher = cardFetcher;
        }

        [HttpGet]
        [Route("cards/cardtypes")]
        public async Task<IOperationResult<List<string>>> GetCardTypes()
        {
            return await _cardFetcher.GetCardTypesAsync();
        }
        
        [HttpGet]
        [Route("cards/{cardName}")]
        public async Task<CardData> GetCard(string cardName)
        {
            return await _cardFetcher.GetCardByNameAsync(cardName);
        }
        
        [HttpPost]
        [Route("cards/list")]
        public async Task<List<CardData>> GetAllCardsInList([FromBody] List<string> cards)
        {
            return await _cardFetcher.GetCardListByNameAsync(cards);
        }
        
        [HttpPost]
        [Route("cards/list/manadata")]
        public async Task<string> GetManaData([FromBody] List<string> cards)
        {
            return await _cardFetcher.GetManaData(cards);
        }

       /* [HttpPost]
        [Route("cards/list/mana")]
        public async Task<string> GetMana([FromBody] string card)
        {
            return await _cardFetcher.GetManaData(card);
        }*/
    }
}