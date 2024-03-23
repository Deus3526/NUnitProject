using Microsoft.EntityFrameworkCore;
using Moq;
using NUnitProject;
using NUnitProject.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NUnitTest
{
    internal class StockServiceTests
    {
        private StockContext _db;

        [SetUp]
        public void SetUp()
        {
            // 設置 InMemory 數據庫
            var options = new DbContextOptionsBuilder<StockContext>()
                .UseInMemoryDatabase(databaseName: "Stock")
                .Options;
            _db = new StockContext(options);
            _db = new StockContext();

            // 種子數據，用於測試
            var stockBaseInfos = new List<StockBaseInfo>
            {
                new StockBaseInfo { StockId = 1, StockName = "Test1", StockType = "T1", StockAmount = 100, Category = "C1" },
                new StockBaseInfo { StockId = 2, StockName = "Test2", StockType = "T2", StockAmount = 200, Category = "C2" },
                new StockBaseInfo { StockId = 3, StockName = "Test3", StockType = "T3", StockAmount = 300, Category = "C3" },
                new StockBaseInfo { StockId = 4, StockName = "Test4", StockType = "T4", StockAmount = 400, Category = "C4" },
                new StockBaseInfo { StockId = 5, StockName = "Test5", StockType = "T5", StockAmount = 500, Category = "C5" },
            };
            _db.StockBaseInfos.AddRange(stockBaseInfos);
            _db.SaveChanges();
        }
        [TearDown]
        public void TearDown()
        {
            _db.Dispose();
        }

        [TestCase]
        public void GetStockBaseInfoViewModels_StockIdsContainsStockId_ReturnStockBaseInfoViewModel()
        {
            
            //Arrange
            var stockIds = new int[] { 1, 2, 3 };

            var expected = new List<StockBaseInfoViewModel>
            {
                new StockBaseInfoViewModel { StockId = 1, StockName = "Test1", StockType = "T1", StockAmount = 100, Category = "C1" },
                new StockBaseInfoViewModel { StockId = 2, StockName = "Test2", StockType = "T2", StockAmount = 200, Category = "C2" },
                new StockBaseInfoViewModel { StockId = 3, StockName = "Test3", StockType = "T3", StockAmount = 300, Category = "C3" },
            };
            var service = new StockService(_db);

            //Act
            var actual = service.GetStockBaseInfoViewModels(stockIds);

            //Assert
            CollectionAssert.AreEqual(expected,actual);
        }
    }
}
