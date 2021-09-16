using System;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using Microsoft.AspNetCore.Mvc;
using ShopingBotClassLibrary;
using OpenQA.Selenium.Support;

namespace ShopingAppApi.Controllers
{

    public class BuyingOptionsController : ControllerBase
    {
        [Route("api/BuyingOptions/AddDriver")]
        [HttpPost]
        public void AddDriver()
        {
            ChromeOptions Options = new ChromeOptions();
            Options.AddArguments("--disable-logging", "--ignore-certificate-errors", "log-level=3");
            //Options.AddArgument("--headless");
            Prodact.Drivers.Add(new ChromeDriver(Options));

        }
        [Route("api/BuyingOptions/DeleteDriver")]
        [HttpDelete]


        public void DeleteDriver()
        {
            var driverAmount = Prodact.Drivers.Count;
            if(driverAmount > 0)
            {
                Prodact.Drivers[Prodact.Drivers.Count - 1].Close();
                Prodact.Drivers.RemoveAt(Prodact.Drivers.Count-1);
            }
        } 
        

        [Route("api/BuyingOptions/UserSignIn")]
        [HttpPost]
        public void UserSignIn([FromBody]Models.PurchaseCredentials val)
        {
            try
            {
                AmazonProdact amazonProdact = new AmazonProdact();
                var Url = val.Url;
                var UserName = val.username;
                var PassWord = val.password;
                amazonProdact.UserSignIn(Url, UserName, PassWord);
            }
            catch
            {
                throw new Exception("Sign In Filed");
            }
        }
        [Route("api/BuyingOptions/CheckIfAvailble")]
        [HttpPost]
        public void CheckIfAvailble([FromBody] Models.PurchaseCredentials val)
        {

            AmazonProdact amazonProdact = new AmazonProdact();
            var Url = val.Url;
            var UserName = val.username;
            var PassWord = val.password;
            amazonProdact.CheckIfAvailble(Url, UserName, PassWord);
        }

        [Route("api/BuyingOptions/PurchaseAvailableProdact")]
        [HttpPost]
        public void PurchaseAvailableProdact([FromBody] Models.PurchaseCredentials val)
        {
            try
            {
                AmazonProdact amazonProdact = new AmazonProdact();
                var Url = val.Url;
                var UserName = val.username;
                var PassWord = val.password;
                amazonProdact.PurchaseAvailableProdact(Url, UserName, PassWord);
            }
            catch
            {
                throw new Exception("Purchase Filed");
            }
        }
        [Route("api/BuyingOptions/DeleteAllDrivers")]
        [HttpDelete]
        public string DeleteAllDrivers()
        {
            try
            {
                foreach (var Driver in Prodact.Drivers)
                {
                    Driver.Close();
                }
                return "Driver Closed";
            }
            catch
            {
                throw new Exception("Drivers could not be closed properly");
            }
           
        }

       
    }
}
