using BR.Core.Attributes;
using BR.Core;
using Activities.CustomLib.KPI.Properties;

namespace Activities.CustomLib.KPI.Activities
{
    [LocalizablePath("Group_Name", typeof(Resources))]
    [LocalizableScreenName("PIK_Stop_ScreenName", typeof(Resources))]
    [LocalizableDescription("PIK_Stop_Description", typeof(Resources))]
    [LocalizableRepresentation("PIK_Stop_Representation", typeof(Resources))]
    [Image(typeof(ProcessingItemKpi_StopTimer), "Activities.CustomLib.KPI.Images.item_kpi_icon.png")]
    public class ProcessingItemKpi_StopTimer : Activity
    {
        #region [PROPERTIES]
        [LocalizableScreenName("PIK_ItemKpi_ScreenName", typeof(Resources))]
        [LocalizableDescription("PIK_ItemKpi_Description", typeof(Resources))]
        [IsRequired]
        public ProcessingItemKpi ItemKpi { get; set; }

        [LocalizableScreenName("PIK_Stop_ErrorMessage_ScreenName", typeof(Resources))]
        [LocalizableDescription("PIK_Stop_ErrorMessage_Description", typeof(Resources))]
        public string ErrorMessage { get; set; }
        #endregion

        #region [EXECUTION]
        public override void Execute(int? optionID)
        {
            if (string.IsNullOrEmpty(ErrorMessage))
            {
                ItemKpi.Stop();
            }
            else
            {
                ItemKpi.Stop(ErrorMessage);
            }
        }
        #endregion
    }
}
