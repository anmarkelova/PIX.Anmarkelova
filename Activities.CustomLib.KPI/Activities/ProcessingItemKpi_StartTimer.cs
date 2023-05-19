using BR.Core.Attributes;
using BR.Core;
using Activities.CustomLib.KPI.Properties;

namespace Activities.CustomLib.KPI.Activities
{
    [LocalizablePath("Group_Name", typeof(Resources))]
    [LocalizableScreenName("PIK_Start_ScreenName", typeof(Resources))]
    [LocalizableDescription("PIK_Start_Description", typeof(Resources))]
    [LocalizableRepresentation("PIK_Start_Representation", typeof(Resources))]
    [Image(typeof(ProcessingItemKpi_StartTimer), "Activities.CustomLib.KPI.Images.item_kpi_icon.png")]
    public class ProcessingItemKpi_StartTimer : Activity
    {
        #region [PROPERTIES]
        [LocalizableScreenName("PIK_ItemKpi_ScreenName", typeof(Resources))]
        [LocalizableDescription("PIK_ItemKpi_Description", typeof(Resources))]
        [IsRequired]
        public ProcessingItemKpi ItemKpi { get; set; }

        [LocalizableScreenName("PIK_Start_ItemId_ScreenName", typeof(Resources))]
        [LocalizableDescription("PIK_Start_ItemId_Description", typeof(Resources))]
        public string ItemId { get; set; }
        #endregion

        #region [EXECUTION]
        public override void Execute(int? optionID)
        {
            if (string.IsNullOrEmpty(ItemId))
            {
                ItemKpi.Start();
            }
            else
            {
                ItemKpi.Start(ItemId);
            }
        }
        #endregion
    }
}
