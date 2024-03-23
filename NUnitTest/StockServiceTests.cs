using Moq;
using NUnitProject;
using NUnitProject.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTest
{
    internal class StockServiceTests
    {
        [TestCase]
        public void GetStockBaseInfoViewModels_StockIdsContainsStockId_ReturnStockBaseInfoViewModel()
        {
            //Arrange
            var stockIds = new int[] { 1, 2, 3 };
            var stockBaseInfos = new List<StockBaseInfo>
            {
                new StockBaseInfo { StockId = 1, StockName = "Test1", StockType = "T1", StockAmount = 100, Category = "C1" },
                new StockBaseInfo { StockId = 2, StockName = "Test2", StockType = "T2", StockAmount = 200, Category = "C2" },
                new StockBaseInfo { StockId = 3, StockName = "Test3", StockType = "T3", StockAmount = 300, Category = "C3" },
                new StockBaseInfo { StockId = 4, StockName = "Test4", StockType = "T4", StockAmount = 400, Category = "C4" },
                new StockBaseInfo { StockId = 5, StockName = "Test5", StockType = "T5", StockAmount = 500, Category = "C5" },
            };
            var expected = new List<StockBaseInfoViewModel>
            {
                new StockBaseInfoViewModel { StockId = 1, StockName = "Test1", StockType = "T1", StockAmount = 100, Category = "C1" },
                new StockBaseInfoViewModel { StockId = 2, StockName = "Test2", StockType = "T2", StockAmount = 200, Category = "C2" },
                new StockBaseInfoViewModel { StockId = 3, StockName = "Test3", StockType = "T3", StockAmount = 300, Category = "C3" },
            };
            var db = new Mock<StockContext>();
            db.Setup(x => x.StockBaseInfos).Returns((Microsoft.EntityFrameworkCore.DbSet<StockBaseInfo>)stockBaseInfos.AsQueryable());
            var service = new StockService(db.Object);

            //Act
            var actual = service.GetStockBaseInfoViewModels(stockIds);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
