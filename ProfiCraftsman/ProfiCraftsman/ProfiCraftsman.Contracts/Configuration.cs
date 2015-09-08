using System;
using System.Configuration;
using System.Text;

namespace ProfiCraftsman.Contracts
{
    public static class Configuration
    {
        public static string OrderFileName
        {
            get
            {
                return ConfigurationManager.AppSettings["OrderFileName"];
            }
        }

        public static string OfferFileName
        {
            get
            {
                return ConfigurationManager.AppSettings["OfferFileName"];
            }
        }

        public static string InvoiceFileName
        {
            get
            {
                return ConfigurationManager.AppSettings["InvoiceFileName"];
            }
        }

        public static string InvoiceStornoFileName
        {
            get
            {
                return ConfigurationManager.AppSettings["InvoiceStornoFileName"];
            }
        }

        public static string ReminderFileName
        {
            get
            {
                return ConfigurationManager.AppSettings["ReminderFileName"];
            }
        }

        public static string DeliveryNoteFileName
        {
            get
            {
                return ConfigurationManager.AppSettings["DeliveryNoteFileName"];
            }
        }

        public static string OrderPreffix
        {
            get { return ConfigurationManager.AppSettings["OrderNumberPreffix"]; }
        }

        public static string CombineUrl(params string[] parts)
        {
            if (parts == null)
                return string.Empty;

            var builder = new StringBuilder();
            foreach (var part in parts)
            {
                builder.Append(part.Trim('/'));
                builder.Append("/");
            }

            var result = builder.ToString();
            if (!result.StartsWith("/"))
                result = "/" + result;

            return result;
        }

        public static double ReminderLevelTwoPrice
        {
            get
            {
                var configValue = ConfigurationManager.AppSettings["ReminderLevelTwoPrice"];

                double result = 6;
                if(!String.IsNullOrEmpty(configValue))
                {
                    Double.TryParse(configValue, out result);
                }

                return result;
            }
        }

        public static double ReminderLevelTreePrice
        {
            get
            {
                var configValue = ConfigurationManager.AppSettings["ReminderLevelTreePrice"];

                double result = 12;
                if (!String.IsNullOrEmpty(configValue))
                {
                    Double.TryParse(configValue, out result);
                }

                return result;
            }
        }
    }
}