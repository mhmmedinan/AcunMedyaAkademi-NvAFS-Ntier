﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Core.Security.Encryption;

public class SecurityKeyHelper
{
    //Token  oluşturulma sürecinde şifreleme anahtarını oluşturmak için kullanılır
    public static SecurityKey CreateSecurityKey(string securityKey)
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
    }
}
