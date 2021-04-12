using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Specialized;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Tarebear_Implementation
{
    public class Tarebear
    {
        protected string baseurl = "https:example.com/";
        protected  string clientid;
        string partneroathid;
        string partneroathkey;
        protected string partnertoken;
        protected string clienttoken;
        public Tarebear()
        {
            clientid = "";
            partneroathid = "";
            partneroathkey = "";
            clientoath
        }
    }
}