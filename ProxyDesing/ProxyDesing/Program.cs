﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProxyDeseni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreditBase manager = new CreditMAnagerProxy();
            Console.WriteLine(manager.Calculate());
            Console.WriteLine(manager.Calculate());
            Console.ReadLine();
        }

    }
    abstract class CreditBase
    {
        public abstract int Calculate();
    }
    class CreditManager : CreditBase
    {
        public override int Calculate()
        {
            int result = 1;
            for (int i = 1; i < 5; i++)
            {
                result *= i;
                Thread.Sleep(1000);
            }
            return result;
        }
    }
    class CreditMAnagerProxy : CreditBase
    {
        private CreditManager _creditManager;
        private int _cacheValue;

        public override int Calculate()
        {
            if (_creditManager == null)
            {
                _creditManager = new CreditManager();
                _cacheValue = _creditManager.Calculate();

            }
            return _cacheValue;
        }
    }
}
