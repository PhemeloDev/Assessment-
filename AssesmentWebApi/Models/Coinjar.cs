using AssesmentWebApi.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssesmentTest.Models
{
    public class Coinjar : ICoinJar
    {
        private readonly TestDBContext db;
        private readonly IConfiguration _config;
        public Coinjar(TestDBContext testDB, IConfiguration config)
        {
            db = testDB;
            _config = config;
        }
        public void AddCoin(ICoin coin)
        {

            if (!ValidateCoin(coin)) 
            {
                throw new Exception(message: "Invalid Coin");
            }

            var volumeCapacity = CurrentVolume();

            if ((volumeCapacity + coin.Volume) <= _config.GetValue<decimal>("JarVolumeCapacity"))
            {               
                Coin newCoin = new Coin()
                {
                    Amount = coin.Amount,
                    Volume = coin.Volume
                };
                db.Coins.Add(newCoin);
                db.SaveChanges();
            }
            else 
            {
                throw new Exception(message: "Coin Jar Cappacity Exceeded");
            }
        }

        public decimal GetTotalAmount()
        {
            decimal amount = 0;
            db.Coins.Sum(x => x.Amount);
            return amount;
        }

        public void Reset()
        {
            db.Coins.RemoveRange(db.Coins);
            db.SaveChanges();
        }

        private decimal CurrentVolume()
        {
            return db.Coins.Sum(x => x.Volume);
        }

        private bool ValidateCoin(ICoin coin) 
        {
            return db.CoinTypes.Any(x => x.Value == coin.Amount && x.Volume == coin.Volume);
        }
    }
}
