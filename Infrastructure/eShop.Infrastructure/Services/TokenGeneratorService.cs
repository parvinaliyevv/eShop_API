namespace eShop.Infrastructure.Services;

public class TokenGeneratorService : ITokenGeneratorService
{

    private readonly JsonWebTokenOptions _options;


    public TokenGeneratorService(IOptions<JsonWebTokenOptions> options)
    {
        _options = options.Value;
    }


    public string GenerateToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new Claim[]
        {
            new Claim(ClaimTypes.Email, user.Email)
        };

        var token = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<string> GenerateTokenAsync(User user)
        => await Task.Factory.StartNew(() => GenerateToken(user));
}
