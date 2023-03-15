using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Service;

namespace MTGDataGatherer.Controllers
{
    [ApiController]
    [Route("")]
    public class CardCalculatorController : ControllerBase
    {
        private readonly ILogger<CardCalculatorController> _logger;
        private IMtgServiceProvider _serviceProvider;
        private ICardService _cardService;
        public CardCalculatorController(ILogger<CardCalculatorController> logger, IMtgServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _cardService = _serviceProvider.GetCardService();
        }

        [HttpGet]
        [Route("cards/cardtypes")]
        public async Task<IOperationResult<List<string>>> GetCardTypes()
        {
            return await _cardService.GetCardTypesAsync();
        }
    }
}