using Data_Access.CrossCutting.MultiLanguaje;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute
    {
        private string _displayName;
        private bool _includeName;


        public RequiredAttribute(bool includeName = true)
        {
            _includeName = includeName;
            ErrorMessageResourceName = !_includeName ? "ValidationRequired" : "ValidationPropertyRequired";
        }

        public RequiredAttribute(string key)
        {
            ErrorMessageResourceName = key;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _displayName = validationContext.DisplayName;
            return base.IsValid(value, validationContext);
        }

        public override string FormatErrorMessage(string name)
        {
            var text = LanguageFactory.Instance.Current.GetText(ErrorMessageResourceName);
            return !_includeName ? text : string.Format(text, _displayName);
        }
    }
}
