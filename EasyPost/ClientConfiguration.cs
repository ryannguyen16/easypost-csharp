using System;

namespace EasyPost
{
    /// <summary>
    ///     Provides configuration options for the REST client.
    /// </summary>
    public class ClientConfiguration
    {
        internal const string BetaBaseUrl = "https://api.easypost.com/beta";
        internal const string DefaultBaseUrl = "https://api.easypost.com/v2";

        /// <summary>
        ///     The API base URI to use on a per-request basis.
        /// </summary>
        internal string ApiBase { get; set; }
        /// <summary>
        ///     The API key to use on per-request basis.
        /// </summary>
        internal string ApiKey { get; set; }

        /// <summary>
        ///     Create an EasyPost.ClientConfiguration instance.
        /// </summary>
        /// <param name="apiKey">The API key to use for the client connection.</param>
        public ClientConfiguration(string apiKey) : this(apiKey, DefaultBaseUrl)
        {
        }

        /// <summary>
        ///     Create an EasyPost.ClientConfiguration instance.
        /// </summary>
        /// <param name="apiKey">The API key to use for the client connection.</param>
        /// <param name="apiBase">The base API url to use for the client connection.</param>
        public ClientConfiguration(string apiKey, string apiBase)
        {
            if (String.IsNullOrEmpty(apiKey))
            {
                throw new ClientNotConfigured("API key is required.");
            }
            ApiKey = apiKey;
            ApiBase = apiBase;
        }
    }
}
