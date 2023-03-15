using System.Collections.Generic;
using System.Threading.Tasks;
using MtgApiManager.Lib.Core;

namespace MTGDataGatherer.service
{
    public interface ICardFetcher
    {
        public Task<IOperationResult<List<string>>> GetCardTypesAsync();
    }
}