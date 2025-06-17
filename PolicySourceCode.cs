//-----------------------------------------------------------------------
// <copyright file="PolicySourceCode.cs" company="Microsoft">
//      All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using Microsoft.PowerPlatform.ConnectorPlatform.Azure.ApimPolicyContext;
using Newtonsoft.Json.Linq;

namespace ConnectorManager.Resources.Basic
{
    // This class is not used in this project.
    // The CSharp in here will be embedded in the policy. It will be html escaped before added to the policy.
    internal class PolicySourceCode : PolicyCodeBase
    {
        public string GetAccessTokenKey()
        {
            var connectionId = (string)context.Variables["connectionId"];
            return "access_token" + connectionId;
        }

        public bool IsAccessTokenNull()
        {
           // return !context.Variables.ContainsKey("AccessToken") || context.Variables["AccessToken"] == null;
           return true;
        }

        public string GetTokenBody()
        {
            if (!context.Variables.ContainsKey("tokens")
                || ((JObject)context.Variables["tokens"]).GetValue("key", StringComparison.OrdinalIgnoreCase) == null
                || ((JObject)context.Variables["tokens"]).GetValue("secret", StringComparison.OrdinalIgnoreCase) == null)
            {
                throw new Exception("EXPECTED400:Couldn't access login credentials. Check your connection to EightFold.");
            }
            const string grantType = "password";
            var tokens = (JObject)context.Variables["tokens"];
            var key = (string)tokens.GetValue("key", StringComparison.OrdinalIgnoreCase);
            var secret = (string)tokens.GetValue("secret", StringComparison.OrdinalIgnoreCase);
            return $"grant_type={grantType}&username={key}&password={secret}";
        }

        public string GetAuthorizationToken()
        {
            if (!context.Variables.ContainsKey("tokens")
                || ((JObject)context.Variables["tokens"]).GetValue("key", StringComparison.OrdinalIgnoreCase) == null
                || ((JObject)context.Variables["tokens"]).GetValue("Authorization", StringComparison.OrdinalIgnoreCase) == null
                || ((JObject)context.Variables["tokens"]).GetValue("secret", StringComparison.OrdinalIgnoreCase) == null)
            {
                throw new Exception("EXPECTED400:Couldn't access login credentials. Check your connection to EightFold.");
            }
            var tokens = (JObject)context.Variables["tokens"];
            var auth = (string)tokens.GetValue("Authorization", StringComparison.OrdinalIgnoreCase);
            return auth;
        }

        public string GetAccessToken()
        {
            if (context.Variables["IssueTokenResponse"] == null
                || ((IResponse)context.Variables["IssueTokenResponse"]).Body == null
                || ((IResponse)context.Variables["IssueTokenResponse"]).Body.As<JObject>(true).GetValue("access_token", StringComparison.OrdinalIgnoreCase) == null)
            {
                throw new Exception("EXPECTED401:  Error; Couldn't authenticate request.");
            }
            var response = ((IResponse)context.Variables["IssueTokenResponse"]).Body.As<JObject>(true);
            var tokenValue = response.GetValue("access_token", StringComparison.OrdinalIgnoreCase);
            return "Bearer " + tokenValue;
        }

        public string RetrieveAccessToken()
        {
            return context.Variables["AccessToken"] as string;
        }

        public bool IsSuccessfulResponse()
        {
            int statusCode = context.Response.StatusCode;
            return statusCode >= 200 && statusCode < 300;
        }

        public bool GetTokenFailed()
        {
            try
            {
                var response = (IResponse)context.Variables["IssueTokenResponse"];
                var statusCode = response.StatusCode;
                return !(statusCode >= 200 && statusCode < 300);
            }
            catch
            {
                throw new Exception("EXPECTED500: Unable to find account");
            }
        }

        public string ProcessErrorAccessToken()
        {
            return "EXPECTED401:PB-APIM-ERR-0401,Invalid API key or secret";
        }
    }
}