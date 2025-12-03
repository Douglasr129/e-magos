

namespace Auth.Domain.ValueObjects
{
    public record SocialLoginProvider(string Nome)
    {
        public static SocialLoginProvider Google => new("Google");
        public static SocialLoginProvider Facebook => new("Facebook");
    }

}
