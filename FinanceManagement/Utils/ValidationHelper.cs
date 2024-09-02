﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinanceManagement.Utils
{
    internal class ValidationHelper
    {
        // Validate if an email is in the correct format
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string pattern = @"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$";
            return Regex.IsMatch(email, pattern);
        }

        // Validate if a string is not null or empty
        public static bool IsNotEmpty(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        // Validate if a password meets minimum requirements
        public static bool IsValidPassword(string password)
        {
            string pattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            return Regex.IsMatch(password, pattern);
        }

        // Validate if StartDate < EndDate
        public static bool IsStartDateLessThanEndDate(DateTime startDate, DateTime endDate)
        {
            return startDate <= endDate;
        }

    }
}
