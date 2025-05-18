using Microsoft.IdentityModel.Tokens;

namespace Core.Security.Encryption;

public class SigningCredentialsHelper
{
    //Tokeni kriptografik olarak imzalar
    //Tokenin içeriği değiştirilmesin diye kullanılır

    public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
    {
        return new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha512Signature);
    }
}
