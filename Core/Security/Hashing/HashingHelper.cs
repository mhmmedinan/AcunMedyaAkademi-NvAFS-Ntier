using System.Security.Cryptography;
using System.Text;

namespace Core.Security.Hashing;

public class HashingHelper
{
    public static void CreatePasswordHash(string password, out byte[] passwordHash,out byte[] passwordSalt)
    {
        using(var hmac = new HMACSHA512())
        {
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); // Şifre + salt kullanarak hash üretir
            //0x12B810CFABE290B9680ACA3F71E4698D6A45B1A77D6E1528064B5A4D32BB0D3FB489A8D598520381CCC127B4DDAD44C9D5ACD4D6AEFC3E84024AAFBE9A2F8744

            passwordSalt = hmac.Key; // Rastgele salt üretir
            //0x74332E8C6E3550888E10FF918AFE1C57AE8A233D3177742B38840C49BEB20A319C83CA52E67868015C5EE89B112E89BF0D251E1B8FC83BD7875437FF7592CB81D54E477F661452B4B65805C1447EFC09B74C44278D29893FB1EA3AF0B953631577066693F3A34EF0A06CE8CD465BBAEC89E096FF1DE3703BC115D6B8C1A7CC93
        }
    }

    public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for(int i = 0; i < computeHash.Length; i++)
            {
                if (computeHash[i] != passwordHash[i])
                    return false;
            }
        }
        return true;
    }
}
