using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProfiCraftsman.API.Config
{
    /// <summary>
    /// Configuration settings for smtp server for notification server
    /// </summary>
    public class NotificationServerConfigSection : ConfigurationSection
    {
        private static NotificationServerConfigSection settings;

        private const string SmtpServerSettingName = "SmtpServer";
        private const string SmtpServerAccountSettingName = "SmtpServerAccountName";
        private const string SmtpServerAccountPasswordSettingName = "SmtpServerAccountPassword";
        private const string SmtpServerPortSettingName = "SmtpServerPort";
        private const string EnableSslSettingName = "EnableSsl";
        private const string SmtpDeliveryMethodSettingName = "SmtpDeliveryMethod";
        private const string SectionName = "notificationServer";

        /// <summary>
        /// Smtp server path
        /// </summary>
        [ConfigurationProperty(SmtpServerSettingName, IsRequired = true)]
        public string SmtpServer
        {
            get { return this[SmtpServerSettingName] as string; }
            set { this[SmtpServerSettingName] = value; }
        }
        /// <summary>
        /// Account name
        /// </summary>
        [ConfigurationProperty(SmtpServerAccountSettingName, IsRequired = true)]
        public string SmtpServerAccountName
        {
            get { return this[SmtpServerAccountSettingName] as string; }
            set { this[SmtpServerAccountSettingName] = value; }
        }
        /// <summary>
        /// Password
        /// </summary>
        [ConfigurationProperty(SmtpServerAccountPasswordSettingName, IsRequired = true)]
        public string SmtpServerAccountPassword
        {
            get { return this[SmtpServerAccountPasswordSettingName] as string; }
            set { this[SmtpServerAccountPasswordSettingName] = value; }
        }

        /// <summary>
        /// Port
        /// </summary>
        [ConfigurationProperty(SmtpServerPortSettingName, IsRequired = true)]
        public int SmtpServerPort
        {
            get
            {
                var result = 587;
                Int32.TryParse(this[SmtpServerPortSettingName].ToString(), out result);

                return result;
            }
            set { this[SmtpServerPortSettingName] = value; }
        }

        /// <summary>
        /// EnableSsl
        /// </summary>
        [ConfigurationProperty(EnableSslSettingName, IsRequired = true)]
        public bool EnableSsl
        {
            get
            {
                var result = true;
                bool.TryParse(this[EnableSslSettingName].ToString(), out result);

                return result;
            }
            set { this[EnableSslSettingName] = value; }
        }

        /// <summary>
        /// SmtpDeliveryMethod
        /// </summary>
        [ConfigurationProperty(SmtpDeliveryMethodSettingName, IsRequired = true)]
        public int SmtpDeliveryMethod
        {
            get
            {
                var result = 0;//equals SmtpDeliveryMethod.Network;
                Int32.TryParse(this[SmtpDeliveryMethodSettingName].ToString(), out result);
                //if (Int32.TryParse(this[SmtpDeliveryMethodSettingName].ToString(), out temp))
                //{
                //    result = (SmtpDeliveryMethod)temp;
                //}

                return result;
            }
            set { this[SmtpDeliveryMethodSettingName] = value; }
        }

        /// <summary>
        /// Gets instance of config section
        /// </summary>
        public static NotificationServerConfigSection Instance
        {
            get
            {
                if (settings == null)
                {
                    settings = (NotificationServerConfigSection)ConfigurationManager.GetSection(SectionName);
                }
                return settings;
            }
        }
    }
}
