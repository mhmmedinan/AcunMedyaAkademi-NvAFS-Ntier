﻿using Core.Extensions;
using Core.Security.Encryption;
using Core.Security.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Security.JWT;

public class JwtHelper : ITokenHelper
{
    public IConfiguration Configuration { get; }
    private TokenOptions _tokenOptions;
    private DateTime _expiration;


    public JwtHelper(IConfiguration configuration)
    {
        Configuration = configuration;
        _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
    }

    public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
    {
        _expiration = DateTime.Now.AddHours(_tokenOptions.AccessTokenExpiration);
        var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
        var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
        var jwt = CreateJwtSecurityToken(_tokenOptions,user,signingCredentials,operationClaims);
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var token = jwtSecurityTokenHandler.WriteToken(jwt);
        return new AccessToken
        {
            Token = token,
            Expiration = _expiration,
        };
    }

    public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions,User user,SigningCredentials signingCredentials,List<OperationClaim> operationClaims)
    {
        var jwt = new JwtSecurityToken(
            issuer:tokenOptions.Issuer,
            audience:tokenOptions.Audience,
            expires:_expiration,
            notBefore:DateTime.Now,
            signingCredentials:signingCredentials,
            claims:SetClaims(user,operationClaims)
            );
        return jwt;
    }

    private IEnumerable<Claim> SetClaims(User user,List<OperationClaim> operationClaims)
    {
        var claims = new List<Claim>();
        claims.AddEmail(user.Email);
        claims.AddNameIdentifier(user.Id.ToString());
        claims.AddName($"{user.FirstName}{user.LastName}");
        claims.AddRoles(operationClaims.Select(x => x.Name).ToArray());
        return claims;
    }
}