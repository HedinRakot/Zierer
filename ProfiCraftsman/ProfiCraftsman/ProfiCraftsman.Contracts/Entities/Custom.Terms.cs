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
                        result = "Offen";
                        break;
                    case TermStatusTypes.BeginTrip:
                    case TermStatusTypes.BeginTripDepartureSelection:
                        result = "Anfahrt begonnen";
                        break;
                    case TermStatusTypes.EndTrip:
                        result = "Anfahrt beendet";
                        break;
                    case TermStatusTypes.BeginWork:
                    case TermStatusTypes.EnterPositions:
                    case TermStatusTypes.CheckPositions:
                    case TermStatusTypes.EnterMaterials:
                    case TermStatusTypes.CheckMaterials:
                    case TermStatusTypes.ShowDeliveryNote:
                    case TermStatusTypes.SignDeliveryNote:
                        result = "Arbeit angefangen";
                        break;
                    case TermStatusTypes.EndWork:
                        result = "Arbeit beendet";
                        break;
                    case TermStatusTypes.BeginReturnTrip:
                        result = "Rückfahrt angefangen";
                        break;
                    case TermStatusTypes.EndReturnTrip:
                        result = "Rückfahrt beendet";
                        break;
                    case TermStatusTypes.Canceled:
                        result = "Storniert";
                        break;
                }

                return result;
            }
        }
    }
}
