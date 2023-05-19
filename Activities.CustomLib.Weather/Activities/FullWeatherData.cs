using Activities.CustomLib.Weather.Properties;
using BR.Core;
using BR.Core.Attributes;
using Primo.CustomLib;

namespace Activities.CustomLib.Weather.Activities
{
    [LocalizablePath("Group_Name", typeof(Resources))]
    [LocalizableScreenName("WD_FullWeatherData_ScreenName", typeof(Resources))]
    [LocalizableDescription("WD_FullWeatherData_Description", typeof(Resources))]
    [LocalizableRepresentation("WD_FullWeatherData_Representation", typeof(Resources))]
    [Image(typeof(FullWeatherData), "Activities.CustomLib.Weather.Images.wether_icon.png")]
    public class FullWeatherData : Activity
    {
        #region [PROPERTIES]
        [LocalizableScreenName("WD_ApiKey_ScreenName", typeof(Resources))]
        [LocalizableDescription("WD_ApiKey_Description", typeof(Resources))]
        [IsRequired]
        public string ApiKey { get; set; }

        [LocalizableScreenName("WD_City_ScreenName", typeof(Resources))]
        [LocalizableDescription("WD_City_Description", typeof(Resources))]
        [IsRequired]
        public string City { get; set; }

        [LocalizableScreenName("WD_Weather_ScreenName", typeof(Resources))]
        [LocalizableDescription("WD_Weather_Description", typeof(Resources))]
        [IsOut]
        public string Weather { get; set; }
        #endregion

        #region [EXECUTION]
        public override void Execute(int? optionID)
        {
            Weather = new WeatherData().GetFullWeatherJson(ApiKey, City);
        }
        #endregion
    }
}



