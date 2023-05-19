using Activities.CustomLib.Text.Properties;
using BR.Core;
using BR.Core.Attributes;

namespace Activities.CustomLib.Text.Activities
{
    [LocalizablePath("Group_Name", typeof(Resources))]
    [LocalizableScreenName("CTR_ScreenName", typeof(Resources))]
    [LocalizableDescription("CTR_Description", typeof(Resources))]
    [LocalizableRepresentation("CTR_Representation", typeof(Resources))]
    [Image(typeof(ChangeTextRegistry), "Activities.CustomLib.Text.Images.text_registry_icon.png")]
    public class ChangeTextRegistry : Activity
    {
        #region [PROPERTIES]
        [LocalizableScreenName("CTR_InputText_ScreenName", typeof(Resources))]
        [LocalizableDescription("CTR_InputText_Description", typeof(Resources))]
        [IsRequired]
        public string InputText { get; set; }

        [LocalizableScreenName("CTR_ChosenRegistry_ScreenName", typeof(Resources))]
        [LocalizableDescription("CTR_ChosenRegistry_Description", typeof(Resources))]
        [IsRequired]
        public Registry ChosenRegistry { get; set; }

        [LocalizableScreenName("CTR_OutputText_ScreenName", typeof(Resources))]
        [LocalizableDescription("CTR_OutputText_Description", typeof(Resources))]
        [IsOut]
        public string OutputText { get; set; }
        #endregion

        #region [EXECUTION]
        public override void Execute(int? optionID)
        {
            switch (this.ChosenRegistry)
            {
                case Registry.LowerCase:
                    OutputText = InputText.ToString().ToLower();
                    break;

                case Registry.UpperCase:
                    OutputText = InputText.ToString().ToUpper();
                    break;

                case Registry.TitleCase:
                    OutputText = RegistryClass.ToTitleCase(InputText);
                    break;
            }
        }
        #endregion
    }
}
