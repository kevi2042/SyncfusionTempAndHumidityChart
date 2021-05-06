using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Constants
{
    public class ApiConstants
    {
        // https://api.thingspeak.com/channels/<channel_id>/feeds.<format>.json?api_key=<XXXXXXXXXXXXXXXX>
        public const string BaseApiUrl = "https://api.thingspeak.com";
        public const string MeasurementEndPoint = "channels/1373129/feeds.json";
        public const string apikey = "api_key=T17CHY6F4XI46TVS";
    }
}
