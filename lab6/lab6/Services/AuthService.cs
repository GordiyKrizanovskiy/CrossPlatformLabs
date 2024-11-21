using Lab6.Models;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;

namespace Lab6.Services;

public class AuthService(IConfiguration configuration)
{
    private readonly IConfiguration _configuration = configuration;

    public async Task<bool> CreateUserAsync(SignUpViewModel model)
    {
        try
        {
            var managementClient = await GetManagementApiClientAsync();

            var userCreateRequest = new UserCreateRequest
            {
                Email = model.Email,
                Password = model.Password,
                Connection = "Username-Password-Authentication",
                EmailVerified = true,
                UserMetadata = new
                {
                    full_name = model.FullName,
                    phone_number = $"+380{model.PhoneNumber}",
                    username = model.Username
                },
            };

            var user = await managementClient.Users.CreateAsync(userCreateRequest);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating user: {ex.Message}");
            return false;
        }
    }

    public async Task<Lab6.Models.User?> GetUserAsync(string id)
    {
        try
        {
            var managementClient = await GetManagementApiClientAsync();

            Console.WriteLine($"Fetching user with ID: {id}");
            var auth0User = await managementClient.Users.GetAsync(id);

            if (auth0User == null)
            {
                Console.WriteLine($"No user found with ID: {id}");
                return null;
            }

            Console.WriteLine($"User found: {auth0User.UserId}");
            return new Lab6.Models.User
            {
                Id = auth0User.UserId,
                UserName = auth0User.UserMetadata?["username"]?.ToString() ?? string.Empty,
                Email = auth0User.Email,
                FullName = auth0User.UserMetadata?["full_name"]?.ToString() ?? string.Empty,
                PhoneNumber = auth0User.UserMetadata?["phone_number"]?.ToString() ?? string.Empty,
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching user: {ex.Message}");
            return null;
        }
    }

    private async Task<IManagementApiClient> GetManagementApiClientAsync()
    {
        var auth0Client = new AuthenticationApiClient(new Uri($"https://{_configuration["Auth0:Domain"]}"));

        var tokenRequest = new ClientCredentialsTokenRequest
        {
            ClientId = _configuration["Auth0:ClientId"],
            ClientSecret = _configuration["Auth0:ClientSecret"],
            Audience = $"https://{_configuration["Auth0:Domain"]}/api/v2/"
        };

        var token = await auth0Client.GetTokenAsync(tokenRequest);

        return new ManagementApiClient(
            token.AccessToken,
            new Uri($"https://{_configuration["Auth0:Domain"]}/api/v2"));
    }
}
