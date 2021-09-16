using System;

namespace ShopingAppApi.DataValidation

{
    public class UserDataValidation
    {
        public int usernameMinimumLength { get; set; } = 8;
        public int passwordMinimumLength { get; set; } = 8;
        public bool usernameValidation(Models.ExternalUserData userData)
        {
            var username = userData.UserName;
            if(username is String)
            {
                if(username.Trim().Length > usernameMinimumLength)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if(username is null)
            {
                throw new Exception("the user name is null"); 
            }
            else
            {
                return false;
            }
        }

        public bool PasswordValidation(Models.ExternalUserData userData)
        {
            var password = userData.Password;
            if (password is String)
            {
                if (password.Trim().Length > passwordMinimumLength)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (password is null)
            {
                throw new Exception("the user name is null");
            }
            else
            {
                return false;
            }

        }
    }
}