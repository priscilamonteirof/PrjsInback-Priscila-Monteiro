using System;

namespace Domain.Models
{
    public class Token
    {
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public DateTime ExpiresAt { get; set; }

        public Token(string accessToken, int expiresIn, DateTime expiresAt) 
        {
            AccessToken = accessToken;
            ExpiresIn = expiresIn;
            ExpiresAt = expiresAt;            
        }
    }
}
