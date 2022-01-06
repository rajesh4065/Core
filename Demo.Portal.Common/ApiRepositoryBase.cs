using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Demo.Portal.Common.Models;
using Microsoft.Extensions.Options;

namespace Demo.Portal.Common
{
    public abstract class ApiRepositoryBase
    {
        /// <summary>Initialises a new instance of the <see cref="ApiRepositoryBase"/> class.</summary>
        /// <param name="httpClient">The http client.</param>
        /// <param name="apiSettings">The api settings options object.</param>
        protected ApiRepositoryBase(HttpClient httpClient, IOptions<ApiClientSettings> apiSettings)
        {
            this.HttpClient = httpClient;
            this.ApiSettings = apiSettings.Value;
            this.HttpClient.BaseAddress = new Uri(this.ApiSettings.BaseUri);
        }

        /// <summary>Gets the api client settings object.</summary>
        protected ApiClientSettings ApiSettings { get; }

        /// <summary>Gets the http client.</summary>
        protected HttpClient HttpClient { get; }

       

        /// <summary>Gets or sets the Api endpoint name for this repo.</summary>
        protected string EndpointName { get; set; }
    }
}
