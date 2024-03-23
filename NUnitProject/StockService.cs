using NUnitProject.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitProject
{
    public class StockService
    {
        private readonly StockContext _db;
        public StockService(StockContext db)
        {
            _db = db;
        }

        public List<StockBaseInfoViewModel> GetStockBaseInfoViewModels(int[] stockIds)
        {
            return _db.StockBaseInfos
                .Where(x => stockIds.Contains(x.StockId))
                .Select(x => new StockBaseInfoViewModel(x))
                .ToList();
        }
    }


    public record StockBaseInfoViewModel
    {
        public int StockId { get; init; }
        public string StockName { get; init; }
        public string StockType { get; init; }
        public int StockAmount { get; init; }
        public string? Category { get; init; }

        public StockBaseInfoViewModel(StockBaseInfo baseInfo)
        {
            StockId = baseInfo.StockId;
            StockName = baseInfo.StockName;
            StockType = baseInfo.StockType;
            StockAmount = baseInfo.StockAmount;
            Category = baseInfo.Category;
        }


    }
}
