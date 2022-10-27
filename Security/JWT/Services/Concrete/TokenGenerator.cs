﻿using Microsoft.IdentityModel.Tokens;
using Security.JWT.Services.Abstraction;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Security.JWT.Services.Concrete;

public class TokenGenerator : ITokenGenerator
{

    public string Generate(string secretKey, string issuer, string audience, double expires, IEnumerable<Claim>? claims = null)
    {

        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        JwtSecurityToken securityToken = new(issuer, audience,
            claims,
            DateTime.UtcNow,
            DateTime.UtcNow.AddMinutes(expires),
            credentials);
        return new JwtSecurityTokenHandler().WriteToken(securityToken);

    }

}