using Activities.CustomLib.Weather.Properties;
using BR.Core;
using BR.Core.Attributes;
using Primo.CustomLib;

namespace Activities.CustomLib.Weather.Activities
{
    [LocalizablePath("Group_Name", typeof(Resources))]
    [LocalizableScreenName("WD_CityPressure_ScreenName", typeof(Resources))]
    [LocalizableDescription("WD_CityPressure_Description", typeof(Resources))]
    [LocalizableRepresentation("WD_CityPressure_Representation", typeof(Resources))]
    [Image(typeof(CityPressure), "Activities.CustomLib.Weather.Images.wether_icon.png")]
    public class CityPressure : Activity
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

        [LocalizableScreenName("WD_Pressure_ScreenName", typeof(Resources))]
        [LocalizableDescription("WD_Pressure_Description", typeof(Resources))]
        [IsOut]
        public string Pressure { get; set; }
        #endregion

        #region [EXECUTION]
        public override void Execute(int? optionID)
        {
            Pressure = new WeatherData().GetWeatherAttribute(ApiKey, City, WeatherAttribute.Pressure);
        }
        #endregion
    }
}

