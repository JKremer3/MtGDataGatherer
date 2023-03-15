using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Model;
using MTGDataGatherer.service;

namespace MTGDataGatherer.Controllers
{
    [ApiController]
    [Route("")]
    public class CardCalculatorController : ControllerBase
    {
        private readonly ILogger<CardCalculatorController> _logger;
        private ICardFetcher _cardFetcher;
        public CardCalculatorController(ILogger<CardCalculatorController> logger, ICardFetcher cardFetcher)
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
        public async Task<CardInfo> GetAllCards(string cardName)
        {
            return await _cardFetcher.GetCardByNameAsync(cardName);
        }
    }
}