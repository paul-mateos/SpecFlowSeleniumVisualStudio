using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using SP_Automation.Rest;
using System.Threading.Tasks;

namespace Panviva.LiveAPI
{
    /**
     *  Facade Class for LiveAPI
     **/
    public static class LiveAPI
    {

        public static DocumentRequest NewOpenDocument(String address)
        {
            return new DocumentRequest(address);
        }

        public static SearchRequest NewSearchRequest(String address)
        {
            return new SearchRequest(address);
        }

        public static CSHSearchRequest NewCSHSearchRequest(String address)
        {
            return new CSHSearchRequest(address);
        }
    }

    public abstract class LiveApiRequest
    {
      
        public string ApiKey;
        public string User;
        public string FindUserBy;
        public string Action;

        string address;  //EndPoint Address

        public LiveApiRequest(string add)
        {
            address = add;
        }

        public string buildUrlParam(string key, string value)
        {
            if (value == null || value.Length == 0) return "";

            return "&" + key + "=" + value;
            

        }

        public virtual string GenUrlString()
        {
            return buildUrlParam("ApiKey", ApiKey)
                   + buildUrlParam("User", User)
                   + buildUrlParam("FindUserBy", FindUserBy)
                   + buildUrlParam("Action", Action);
        }

        public void Send()
        {
            RestAPI.newRequest(address).GetAndVerifyStatus(address + GenUrlString(), HttpStatusCode.OK);
        }
    }

    public class DocumentRequest : LiveApiRequest
    {

        public string DocumentID {get;set;}
        public string SectionID { get; set; }
        public string AnchorName { get; set; }
        public string Version { get; set; }

        public DocumentRequest(String s) : base(s) { }
        override public string GenUrlString()
        {
           return base.GenUrlString() + buildUrlParam("DocumentID", DocumentID)
                                + buildUrlParam("SectionID", SectionID)
                                + buildUrlParam("AnchorName", AnchorName)
                                + buildUrlParam("Version", Version);
        }
    }

    /**
     * for search request  
     */
    public class SearchRequest : LiveApiRequest
    {
       public string Query;

       public string Filters;

       public SearchRequest(String s) : base(s) { }
       override public string GenUrlString()
       {
           return base.GenUrlString() + buildUrlParam("Query", Query)
                                + buildUrlParam("Filters", Filters);
       }
    };

  /**
  * for CSH request search 
  */
    public class CSHSearchRequest : SearchRequest
    {
        public CSHSearchRequest(String s) : base(s) { }
    }; 
}
