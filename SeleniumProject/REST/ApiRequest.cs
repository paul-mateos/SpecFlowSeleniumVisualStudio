using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panviva.Rest
{
 

    public abstract class ApiRequest
    {
        public const string FindUserByName = "name";
        public const string FindUserByID = "id";

        public string ApiKey;
        public string User;


        public string FindUserBy = FindUserByName; //FindUserByName or FindUserByID

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Prompt = false ;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PromptMessage;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool FlashIcon = false;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PopupNotification;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool Maximized = true;

        protected ApiRequest(string key, string user)
        {
            ApiKey = key;
            User = user;
        }

        
        protected string buildUrlParam(string key, Object value, Object ignoreValue = null)
        {
            if (value == null || value.Equals(ignoreValue)) return "";

            return "&" + key + "=" + value;
            

        }

        public virtual string GenUrlString()
        {
            return buildUrlParam("ApiKey", ApiKey)
                   + buildUrlParam("User", User)
                   + buildUrlParam("FindUserBy", FindUserBy, FindUserByName)
                   + buildUrlParam("Prompt", Prompt, false)
                   + buildUrlParam("PromptMessage", PromptMessage, "")
                   + buildUrlParam("FlashIcon", FlashIcon, false)
                   + buildUrlParam("PopupNotification", PopupNotification, "")
                   + buildUrlParam("Maximized", Maximized, true);
        }
    }

    public class DocumentRequest : ApiRequest
    {

        public int DocumentID {get;set;}
        public int SectionID { get; set; }
        public string AnchorName { get; set; }
        public int Version { get; set; }

        public DocumentRequest() : base("","")
        {

        }
        
        public DocumentRequest(string key, string user, int Documentid) : base(key, user)
        {
            DocumentID = Documentid;
        }


        override public string GenUrlString()
        {
           return base.GenUrlString() + buildUrlParam("DocumentID", DocumentID)
                                + buildUrlParam("SectionID", SectionID, -1)
                                + buildUrlParam("AnchorName", AnchorName, "")
                                + buildUrlParam("Version", Version, -1);
        }
    }

    /**
     * for both search and CSH request search 
     */
    public class SearchRequest : ApiRequest
    {
       public string Query;

       [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
       public string Filters;

       public SearchRequest(string key, string user, string q) : base(key, user)
       {
           Query = q;
       }

       override public string GenUrlString()
       {
           return base.GenUrlString() + buildUrlParam("Query", Query)
                                + buildUrlParam("Filters", Filters, "");
       }
    };

    
}
