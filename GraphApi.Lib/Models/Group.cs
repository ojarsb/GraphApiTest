using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GraphApi.Core.Models
{
    public class Group
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        //public object DeletedDateTime { get; set; }
        //public object Classification { get; set; }
        //public DateTime CreatedDateTime { get; set; }
        //public object Description { get; set; }

        [JsonProperty(PropertyName = "displayName", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName { get; set; }
        //public List<object> GroupTypes { get; set; }
        //public object Mail { get; set; }
        //public bool MailEnabled { get; set; }
        //public string MailNickname { get; set; }
        //public object MembershipRule { get; set; }
        //public object MembershipRuleProcessingState { get; set; }
        //public object OnPremisesLastSyncDateTime { get; set; }
        //public List<object> OnPremisesProvisioningErrors { get; set; }
        //public object OnPremisesSecurityIdentifier { get; set; }
        //public object OnPremisesSyncEnabled { get; set; }
        //public object PreferredDataLocation { get; set; }
        //public object PreferredLanguage { get; set; }
        //public List<object> ProxyAddresses { get; set; }
        //public DateTime RenewedDateTime { get; set; }
        //public List<object> ResourceBehaviorOptions { get; set; }
        //public List<object> ResourceProvisioningOptions { get; set; }
        //public bool SecurityEnabled { get; set; }
        //public object Theme { get; set; }
        //public object Visibility { get; set; }
    }
}