using Activities.CustomLib.Weather.Properties;
using BR.Core;
using BR.Core.Attributes;
using Primo.CustomLib;

namespace Activities.CustomLib.Weather.Activities
{
    [LocalizablePath("Group_Name", typeof(Resources))]
    [LocalizableScreenName("WD_CityTemperature_ScreenName", typeof(Resources))]
    [LocalizableDescription("WD_CityTemperature_Description", typeof(Resources))]
    [LocalizableRepresentation("WD_CityTemperature_Representation", typeof(Resources))]
    [Image(typeof(CityTemperature), "Activities.CustomLib.Weather.Images.wether_icon.png")]
    public class CityTemperature : Activity
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

        [LocalizableScreenName("WD_Temperature_ScreenName", typeof(Resources))]
        [LocalizableDescription("WD_Temperature_Description", typeof(Resources))]
        [IsOut]
        public string Temperature { get; set; }
        #endregion

        #region [EXECUTION]
        public override void Execute(int? optionID)
        {
            Temperature = new WeatherData().GetWeatherAttribute(ApiKey, City, WeatherAttribute.Temperature);
        }
        #endregion
    }
}


