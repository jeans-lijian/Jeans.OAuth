namespace Jeans.OAuth.Core.Domains
{
    /// <summary>
    ///  客户端 credentials
    /// </summary>
    public class Credentials : BaseEntity
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public GrantTypeMode GrantTypeMode { get; set; }
    }
}
