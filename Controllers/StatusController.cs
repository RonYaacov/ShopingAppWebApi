using Microsoft.AspNetCore.Mvc;
using ShopingBotClassLibrary;
using System;

namespace ShopingAppApi.Controllers
{
    [ApiController]

    public class StatusController : ControllerBase
    {
        public enum ValueTypeProdactData { PurchasedProdacts, PurchaseFailes, ProdactsOnTheShopingList }


        [Route("api/Status/GetReport")]
        [HttpGet]
        public string GetReport()
        {
            Prodact prodact = new Prodact();
            string Report = prodact.Report().ToString();
            return Report;
        }
        [Route("api/Status/GetById/{Id:int}")]
        [HttpGet]
        public int Get(ValueTypeProdactData Id)
        {
            switch (Id)
            {
                case (ValueTypeProdactData.PurchasedProdacts):
                    return Prodact.PurchasedProdacts;

                case (ValueTypeProdactData.ProdactsOnTheShopingList):
                    return Prodact.ProdactsOnTheShopingList;

                case (ValueTypeProdactData.PurchaseFailes):
                    return Prodact.PurchaseFailes;
            }
            throw new Exception("Invalid Get Id");
        }

        [Route("api/Status/Increment/{val:int}")]
        [HttpPut]
        public void Increment(ValueTypeProdactData val)
        {
            try
            {
                switch ((ValueTypeProdactData)val)
                {
                    case (ValueTypeProdactData.PurchasedProdacts):
                        Prodact.PurchasedProdacts++;
                        break;


                    case (ValueTypeProdactData.PurchaseFailes):
                        Prodact.PurchaseFailes++;
                        break;
                }
            }
            catch { throw new Exception("Invalid Put Increment"); }



        }


    }
}
