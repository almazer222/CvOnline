using CvOnline.API.Dtos;
using CvOnline.API.Validation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CvOnline.API.Helper
{
    public static class DateHelper
    {
        /// <summary>
        /// Method to transforme a Null date to empty date.
        /// </summary>
        /// <param name="cvItemsDto"></param>
        /// <returns></returns>
        public static DateTime GetEmptyDateWhenNullDate(DateTime? date)
        {
            return date == null ? new DateTime() :(DateTime) date;
        }
    }
}
