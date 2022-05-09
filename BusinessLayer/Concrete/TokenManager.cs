using EntityLayer.Dto;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TokenManager
    {
        IConfiguration configuration;

        public TokenManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        
        public string CreateAccessToken(DtoLoginUser user)
        {
            //claim 
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserEmail),
                new Claim(JwtRegisteredClaimNames.Jti, user.UserID.ToString()),
                new Claim(ClaimTypes.Name, user.UserDepartmant),
                new Claim("role",user.UserAuthorization),
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Token");

         

            //security key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]));



            //şifrelenmiş kimlik oluşturmak 
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            //token ayarları
            var token = new JwtSecurityToken
            (
                //issuer : configuration["Tokens:Issuer"], //token dağıtıcı url,
                //audience : configuration["Tokens:Audience"], //erişilebilecek apiler
                expires : DateTime.Now.AddDays(1),// token süresini 5 dakikaya ayarlar,
                notBefore:  DateTime.Now, //token üretildikten ne kadar zaman sonra devreye girsin
                signingCredentials: cred, // kimlik verdik
                claims: claimsIdentity.Claims 

            );

            //token oluşturma sınıfı ile örnek alıp üretmek
            var tokenHandler = new { token = new JwtSecurityTokenHandler().WriteToken(token) };

            return tokenHandler.token;
        }
    }
}
