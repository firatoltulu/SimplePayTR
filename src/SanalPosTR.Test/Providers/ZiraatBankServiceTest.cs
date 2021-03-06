﻿using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using SanalPosTR.Model;
using SanalPosTR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SanalPosTR.Providers;

namespace SanalPosTR.Test.Providers
{
    [TestFixture]
    public class ZiraatBankServiceTest : Initialize
    {
        private static readonly object[] _paymentModelData = new object[]{
           new List<PaymentModel>{
               new PaymentModel()
                    {
                        CreditCard = new CreditCardInfo()
                        {
                            CardNumber = "4355084355084358",
                            CVV2 = "",
                            ExpireMonth = "12",
                            ExpireYear = "25",
                            CardHolderName = "FIRAT OLTULU",
                        },
                        Order = new OrderInfo
                        {
                            Installment = 0,
                            OrderId = "1",
                            Total = 9.95M,
                            UserId = "ECommerce3D",
                            CurrencyCode="949"
                        }
                    }
           }
        }.ToArray();



        [TestCaseSource("_paymentModelData")]
        public async Task EstProviderServiceTest_ProcessPayment(IEnumerable<PaymentModel> paymentModels)
        {
            var providerService = ServiceProvider.GetRequiredService<Func<BankTypes, IProviderService>>();
            var _estService = providerService(BankTypes.Ziraat);

            var serverResponse = await _estService.ProcessPayment(paymentModels.FirstOrDefault());

            
        }

        [TestCaseSource("_paymentModelData")]
        public async Task EstProviderServiceTest_ProcessPaymentWith3D(IEnumerable<PaymentModel> paymentModels)
        {
            var providerService = ServiceProvider.GetRequiredService<Func<BankTypes, IProviderService>>();
            var _estService = providerService(BankTypes.Ziraat);
            var _paymentModel = paymentModels.FirstOrDefault();

            _paymentModel.Use3DSecure = true;

            var serverResponse = await _estService.ProcessPayment(_paymentModel);

        }

        [Test]
        public async Task EstProviderServiceTest_Refund()
        {
            var providerService = ServiceProvider.GetRequiredService<Func<BankTypes, IProviderService>>();
            var _estService = providerService(BankTypes.Ziraat);
            var serverResponse = await _estService.ProcessRefound(new Refund
            {
                OrderId = "123123",
                RefundAmount = 5,
                CurrencyCode = "949"
            });

        }
    }
}