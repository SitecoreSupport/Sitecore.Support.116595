namespace Sitecore.Support.Hooks
{
    using Sitecore.Configuration;
    using Sitecore.Diagnostics;
    using Sitecore.Events.Hooks;
    using Sitecore.SecurityModel;
    using System;

    public class UpdateNumberFieldDefinitionItem : IHook
    {
        public void Initialize()
        {
            using (new SecurityDisabler())
            {
                // Source validator //
                var databaseName1 = "master";
                var itemPath1 = "/sitecore/system/Settings/Validation Rules/Field Rules/System/Source";
                var fieldName1 = "Type";

                var type1 = typeof(Sitecore.Support.Data.Validators.FieldValidators.SourceValidator);

                var typeName1 = type1.FullName;
                var assemblyName1 = type1.Assembly.GetName().Name;
                var fieldValue1 = "Sitecore.Support.Data.Validators.FieldValidators.SourceValidator, Sitecore.Support.116595";

                var database1 = Factory.GetDatabase(databaseName1);
                var item1 = database1.GetItem(itemPath1);

                if (string.Equals(item1[fieldName1], fieldValue1, StringComparison.Ordinal))
                {
                    return;
                }

                // Source Item validator //
                var databaseName2 = "master";
                var itemPath2 = "/sitecore/system/Settings/Validation Rules/Field Rules/System/Source Item";
                var fieldName2 = "Type";

                var type2 = typeof(Sitecore.Support.Data.Validators.FieldValidators.SourceValidator);

                var typeName2 = type2.FullName;
                var assemblyName2 = type1.Assembly.GetName().Name;
                var fieldValue2 = "Sitecore.Support.Data.Validators.FieldValidators.SourceItemValidator, Sitecore.Support.116595";

                var database = Factory.GetDatabase(databaseName2);
                var item2 = database.GetItem(itemPath2);

                if (string.Equals(item2[fieldName2], fieldValue2, StringComparison.Ordinal))
                {
                    return;
                }

                Log.Info("Installing Sitecore.Support.116595", this);
               
                item1.Editing.BeginEdit();
                item1[fieldName1] = fieldValue1;
                item1.Editing.EndEdit();

                item2.Editing.BeginEdit();
                item2[fieldName2] = fieldValue2;
                item2.Editing.EndEdit();
            }
        }
    }
}