﻿namespace Ebuy.Web.Common.Extensions
{
    using Microsoft.AspNetCore.Mvc.ViewFeatures;

    public static class TempDataDictionaryExtensions
    {
        public static void AddSuccessMessage(this ITempDataDictionary tempData, string message)
        {
            tempData[WebConstants.TempDataSuccessMessageKey] = message;
        }

        public static void AddErrorMessage(this ITempDataDictionary tempData, string message)
        {
            tempData[WebConstants.TempDataErrorMessageKey] = message;
        }

        public static void AddInfoMessage(this ITempDataDictionary tempData, string message)
        {
            tempData[WebConstants.TempDataInfoMessageKey] = message;
        }
    }
}