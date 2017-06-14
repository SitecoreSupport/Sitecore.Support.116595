namespace Sitecore.Support.Data.Validators.FieldValidators
{
    using Sitecore;
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Data.Validators;
    using Sitecore.Data.Validators.FieldValidators;
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class SourceItemValidator : Sitecore.Data.Validators.FieldValidators.SourceItemValidator
    {
        public SourceItemValidator()
        {
        }

        public SourceItemValidator(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        protected override ValidatorResult Evaluate()
        {
            Item item = base.GetItem();
            if (item == null)
            {
                return base.GetFailedResult(ValidatorResult.Valid);
            }
            string str = item[FieldIDs.SourceItem];
            string str2 = item[FieldIDs.Source];
            if (string.IsNullOrEmpty(str2) && string.IsNullOrEmpty(str))
            {
                return base.GetFailedResult(ValidatorResult.Valid);
            }
            Item item2 = (base.ItemUri == null) ? null : Database.GetItem(base.ItemUri);
            if (((item2 != null) && str.Equals(item2[FieldIDs.SourceItem], StringComparison.OrdinalIgnoreCase)) && str2.Equals(item2[FieldIDs.Source], StringComparison.OrdinalIgnoreCase))
            {
                return base.GetFailedResult(ValidatorResult.Valid);
            }
            return this.EvaluateCloneField(str2, str);
        }
    }
}