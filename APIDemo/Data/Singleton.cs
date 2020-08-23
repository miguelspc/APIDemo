﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDemo.Models;

namespace APIDemo.Data
{
    public sealed class Singleton
    {
        private readonly static Singleton _instance = new Singleton();
        public List<ExchangeRate> ExchangeRates { get; set; }
        private Singleton()
        {
                ExchangeRates = new List<ExchangeRate>();
                ExchangeRate newExchangeRate = new ExchangeRate
                {
                    Date = Convert.ToDateTime("2020-08-01"),
                    GTQ = 1,
                    USD = 7.9
                };
                ExchangeRates.Add(newExchangeRate);

                newExchangeRate = new ExchangeRate
                {
                    Date = Convert.ToDateTime("2020-08-02"),
                    GTQ = 1,
                    USD = 7.88
                };
                ExchangeRates.Add(newExchangeRate);

                newExchangeRate = new ExchangeRate
                {
                    Date = Convert.ToDateTime("2020-08-03"),
                    GTQ = 1,
                    USD = 7.86
                };
                ExchangeRates.Add(newExchangeRate);

                newExchangeRate = new ExchangeRate
                {
                    Date = Convert.ToDateTime("2020-08-04"),
                    GTQ = 1,
                    USD = 7.92
                };
                ExchangeRates.Add(newExchangeRate);

                newExchangeRate = new ExchangeRate
                {
                    Date = Convert.ToDateTime("2020-08-05"),
                    GTQ = 1,
                    USD = 7.87
                };
                ExchangeRates.Add(newExchangeRate);
        }

        public static Singleton Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
