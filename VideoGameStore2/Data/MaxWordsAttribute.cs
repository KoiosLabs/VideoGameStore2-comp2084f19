using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGameStore2.Data
{
    public class MaxWordsAttribute :ValidationAttribute, IClientModelValidator
    {
        public MaxWordsAttribute(int maxWords) : base("{0} has too many words.") { _maxWords = maxWords; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var valueAsString = value.ToString();
                if (valueAsString.Split(' ').Length > _maxWords)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }
            return ValidationResult.Success;
        }
        private readonly int _maxWords;

        void IClientModelValidator.AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-maxwords-wordcount", _maxWords.ToString());
            var errorMessage = FormatErrorMessage(context.ModelMetadata.GetDisplayName());
            context.Attributes.Add("data-val-maxwords", errorMessage);
        }
    }
}
