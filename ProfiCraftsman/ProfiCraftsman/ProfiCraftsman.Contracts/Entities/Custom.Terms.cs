using ProfiCraftsman.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ProfiCraftsman.Contracts.Entities
{
    /// <summary>
    ///  Term
    /// </summary>
    public partial class Terms
    { 
        public TermStatusTypes TermStatus
        {
            get
            {
                return (TermStatusTypes)Status;
            }
        }

        public string TermStatusString
        {
            get
            {
                var result = String.Empty;

                switch (TermStatus)
                {
                    case TermStatusTypes.Open:
                        result = "offen";
                        break;
                    case TermStatusTypes.Closed:
                        result = "abgeschlossen";
                        break;
                    case TermStatusTypes.Canceled:
                        result = "storniert";
                        break;
                }

                return result;
            }
        }
    }
}
