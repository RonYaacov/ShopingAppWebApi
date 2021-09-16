

using System.Collections.Generic;

namespace ShopingAppApi.Models
{
    public struct ExternalUserData
    {
        public string Url { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int purchasedProdacts { get; set; }    
    }
}
