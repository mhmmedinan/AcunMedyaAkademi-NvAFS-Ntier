﻿namespace Core.Security.JWT;

public class TokenOptions
{
    public string Audience { get; set; } // Bir kimlik doğrulama tokeninin hedef kitlesini temsil eden özellik
    public string Issuer { get; set; } // Bir kimlik doğrulama işleminde tokeni veren kim olduğunu belirtiyor
    public int AccessTokenExpiration { get; set; } // Token geçerlilik süresi
    public string SecurityKey { get; set; } // Kimlik doğrulama için kullanılan güvenlik anahtarı
}
