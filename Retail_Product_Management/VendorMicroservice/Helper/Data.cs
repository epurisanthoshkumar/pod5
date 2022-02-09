using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorMicroservice.Models;

namespace VendorMicroservice.Helper
{
    public class Data
    {
        public static List<Vendor> vendors = new List<Vendor>
        {
            new Vendor{VendorId = 111,VendorName="Bharath",DeliveryCharge=2150,Rating=4,ExpectedDateOfDelivery=7},
            new Vendor{VendorId = 112,VendorName="Renuka",DeliveryCharge=2650,Rating=5,ExpectedDateOfDelivery=15},
            new Vendor{VendorId = 113,VendorName="Anupama",DeliveryCharge=2950,Rating=4,ExpectedDateOfDelivery=8},
            new Vendor{VendorId = 114,VendorName="Nancy",DeliveryCharge=1120,Rating=5,ExpectedDateOfDelivery=6},
            new Vendor{VendorId = 115,VendorName="Pranay",DeliveryCharge=1990,Rating=4,ExpectedDateOfDelivery=9}
        };

        public static List<VendorStock> stocks = new List<VendorStock>
        {
            new VendorStock{ProductId = 1,VendorId = 111,StockInHand=50,ExpectedStockReplenishmentDate="2022-02-16"},
            new VendorStock{ProductId = 2,VendorId = 111,StockInHand=150,ExpectedStockReplenishmentDate="2022-03-09"},
            new VendorStock{ProductId = 1,VendorId = 112,StockInHand=76,ExpectedStockReplenishmentDate="2022-02-25"},
            new VendorStock{ProductId = 2,VendorId = 112,StockInHand=0,ExpectedStockReplenishmentDate="2022-02-19"},
            new VendorStock{ProductId = 3,VendorId = 113,StockInHand=0,ExpectedStockReplenishmentDate="2022-03-20"},
            new VendorStock{ProductId = 1,VendorId = 113,StockInHand=202,ExpectedStockReplenishmentDate="2022-02-25"},
            new VendorStock{ProductId = 3,VendorId = 114,StockInHand=0,ExpectedStockReplenishmentDate="2022-03-27"},
            new VendorStock{ProductId = 4,VendorId = 114,StockInHand=85,ExpectedStockReplenishmentDate="2022-03-20"},
            new VendorStock{ProductId = 2,VendorId = 115,StockInHand=185,ExpectedStockReplenishmentDate="2022-02-03"},
            new VendorStock{ProductId = 5,VendorId = 115,StockInHand=150,ExpectedStockReplenishmentDate="2022-03-08"}
        };
    }
}
