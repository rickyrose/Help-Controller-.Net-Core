using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Net;
using Systemm.Web;
using System.IO;
using System.Data;
using Newtonsoft.Json.Linq;
using Nager.Data;

namespace Tarebear_Implementation
{
    public class SettlementAccount
    {
        public string Id {get; set; }
        public string MethodId {get; set; }
        public string MethodText {get; set; }
        public string Currency {get; set; }
        public string Text {get; set; }
        public  string PaymentIdent {get; set; }
        public string BankName {get; set; }
        public string BankAccount {get; set; }
        public bool Prefered {get; set; }
        public bool Selected {get; set; }
    }
    public class SettlementAccountImplementation : Tarebear
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="accountHolderName"string (required) Full name account holder.</param>
         /// <param name="templateIdentifier">string (required) The client-assigned template identifier. This value should match the 'settlementAccountId' in the URL.</param>
        /// <param name="destinationCountry">string (required) Two-letter ISO code for the country where the beneficiary's bank is located.</param>
        /// <param name="bankCurrency">string (required) Three-letter ISO code for the bank account currency.</param>
        /// <param name="classification">string (required) Beneficiary classification = 'Individual' or 'Business'. Most of the other values are shown in GET Beneficiary Rules.</param>
        /// <param name="paymentMethods">string (required) Methods of payment that can be used for this beneficiary = ['W' or 'E'].</param>
        /// <param name="settlementMethods">string (required) Methods of settlement that can be used for this beneficiary = ['W' or 'E'].</param>
        /// <param name="preferredMethod">string (required) </param>
        /// <param name="accountHolderCountry">string (required) </param>
        /// <param name="accountHolderRegion">string (required) </param>
        /// <param name="accountHolderAddress1">string (required) </param>
        /// <param name="accountHolderAddress2">string (required) </param>
        /// <param name="accountHolderCity">string (required) </param>
        /// <param name="accountHolderPostal">string (required) </param>
        /// <param name="accountHolderPhoneNumber">string (required) </param>
        /// <param name="accountHolderEmail">string (required) </param>
        /// <param name="sendPayTracker">string (required) </param>
        /// <param name="ibanDigits">string (required) </param>
        /// <param name="ibanEnabled">string (required) </param>
        /// <param name="iban">string (required) </param>
        /// <param name="swiftBicCode">string (required) </param>
        /// <param name="bankName">string (required) </param>
        /// <param name="bankAddressLine1">string (required) </param>
        /// <param name="bankAddressLine2">string (required) </param>
        /// <param name="bankCity">string (required) </param>
        /// <param name="bankRegion">string (required) </param>
        /// <param name="bankPostal">string (required) </param>
        /// <param name="bankCountry">string (required) </param>
        /// <param name="accountNumber">string (required) </param>
        /// <param name="localAccountNumber">string (required) </param>
        /// <param name="routingCode">string (required) </param>
        /// <param name="localRoutingCode">string (required) </param>
        /// <param name="paymentReference">string (required) </param>
        /// <param name="internalPaymentAlert">string (required) </param>
        /// <param name="externalPaymentAlert">string (required) </param>
        /// <param name="regulatory"></param>
        /// <returns></returns>
        public HttpStatusCode CreateEditSettlementAccount(string accountHolderName, string templateIdentifier, string destinationCountry, string bankCurrency,
            string classification, List<string> paymentMethods, List<string> settlementMethods, string preferredMethod, 
            string accountHolderCountry, string accountHolderRegion, string accountHolderAddress1, string accountHolderAddress2, 
            string accountHolderCity, string accountHolderPostal, string accountHolderPhoneNumber, string accountHolderEmail,
            string sendPayTracker, string ibanDigits, string ibanEnabled, string iban, string swiftBicCode, 

            string bankName, string bankAddressLine1, string bankAddressLine2,
            string bankCity, string bankRegion, string bankPostal, string bankCountry, 

            string accountNumber, string localAccountNumber, string routingCode, string localRoutingCode, 
            string paymentReference, string internalPaymentAlert, string externalPaymentAlert, List<string> regulatory)
        {
            string strjsonresult = "";
            Uri endpoint = new Uri("https://beta.tarebeargames.com/api/" + clientid + "/0/quotes/forward");

            NameValueCollection nvc = new NameValueCollection();
            
            nvc["accountHolderName"] = accountHolderName;
            nvc["templateIdentifier"] = templateIdentifier;
            nvc["destinationCountry"] = destinationCountry;
            nvc["bankCurrency"] = bankCurrency;
            nvc["classification"] = classification;

            //paymentMethods
            //settlementMethods

            nvc["preferredMethod"] = preferredMethod;
            nvc["accountHolderCountry"] = accountHolderCountry;
            nvc["accountHolderRegion"] = accountHolderRegion;
            nvc["accountHolderAddress1"] = accountHolderAddress1;
            nvc["accountHolderAddress2"] = accountHolderAddress2;
            nvc["accountHolderCity"] = accountHolderCity;
            nvc["accountHolderPostal"] = accountHolderPostal;
            nvc["accountHolderPhoneNumber"] = accountHolderPhoneNumber;
            nvc["accountHolderEmail"] = accountHolderEmail;
            nvc["sendPayTracker"] = sendPayTracker;
            nvc["ibanDigits"] = ibanDigits;
            nvc["ibanEnabled"] = ibanEnabled;
            nvc["iban"] = iban;
            nvc["swiftBicCode"] = swiftBicCode;

            nvc["bankName"] = bankName;
            nvc["bankAddressLine1"] = bankAddressLine1;
            nvc["bankAddressLine2"] = bankAddressLine2;
            nvc["bankCity"] = bankCity;
            nvc["bankRegion"] = bankRegion;
            nvc["bankPostal"] = bankPostal;
            nvc["bankCountry"] = bankCountry;

            string query = "{ " + String.Join(", ", nvc.AllKeys
                            .SelectMany(key => nvc.GetValues(key)
                                .Select(value => String.Format("\"{0}\":\"{1}\"", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value))))
                            .ToArray()) + " }";

            HttpWebRequest webrequest = BuildHttpWebRequestPut(endpoint, query, clienttoken);
            HttpWebResponse webresponse = null;

            try
            {
                webresponse = (HttpWebResponse)webrequest.GetResponse();
            }
            catch (WebException ex)
            {
                webresponse = (HttpWebResponse)ex.Response;

                if (webresponse == null)
                {
                    strjsonresult = ex.Message;
                    return HttpStatusCode.BadRequest;
                }
            }

            return HttpStatusCode.OK;
        }

        public HttpStatusCode GetSettlementAccounts(string id, out SettlementAccount settlmentaccount)
        {
            string strjsonresult = "";
            Uri endpoint = new Uri("https://beta.tarebeargames.com/api/" + clientid + "/0/settlement-accounts");
                        
            HttpWebRequest webrequest = BuildHttpWebRequestGet(endpoint, clienttoken);
            HttpWebResponse webresponse = null;

            settlmentaccount = null;

            try
            {
                webresponse = (HttpWebResponse)webrequest.GetResponse();
            }
            catch (WebException ex)
            {
                webresponse = (HttpWebResponse)ex.Response;

                if (webresponse == null)
                {
                    strjsonresult = ex.Message;
                    return HttpStatusCode.BadRequest;
                }
            }

            strjsonresult = new StreamReader(webresponse.GetResponseStream()).ReadToEnd();

            dynamic json = JValue.Parse(strjsonresult);

            foreach (var item in json.items)
            {
                foreach (var child in json.children)
                {
                    if (child.id == id)
                    {
                        settlmentaccount = new SettlementAccount();
                        settlmentaccount.Id = child.id;
                        settlmentaccount.MethodId = child.method.id;
                        settlmentaccount.MethodText = child.method.text;
                        settlmentaccount.Currency = child.currency;
                        settlmentaccount.Text = child.text;
                        settlmentaccount.PaymentIdent = child.paymentIdent;
                        settlmentaccount.BankName = child.bankName;
                        settlmentaccount.BankAccount = child.bankAccount;
                        settlmentaccount.Prefered = child.preferred;
                        settlmentaccount.Selected = child.selected;
                        break;
                    }
                }
            }


            return HttpStatusCode.OK;
        }
    }
}
