
using IdentityDemo.BlazorWasmAuth.Models;

namespace IdentityDemo.BlazorWasmAuth;

public interface IAuthenticationManager
{
    public Task<FormResult> LoginAsync(string email, string password);

    public Task LogoutAsync();

    public Task<FormResult> RegisterAsync(string email, string password);

    public Task<bool> CheckAuthenticatedAsync();
}
