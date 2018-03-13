namespace HomePropertySystem.Helpers.Jwt
{
    public static class JwtConstants
    {
        private const string issuerValidation = "Homes.Security.Bearer.Issuer";
        private const string audienceValidation = "Homes.Security.Bearer.Audience";
        private const string signingKey = "@Homes-security";

        public static string GetIssuer()
        {
            return issuerValidation;
        }

        public static string GetAudience()
        {
            return audienceValidation;
        }

        public static string GetSigningKey()
        {
            return signingKey;
        }
    }
}
