using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace RRHH.UI
{
    public class ValidarPassword
    {
        public static bool FormatoContraseña(string Password)
        {
            int Cantidad = 3;
            int Minimum_Length = 5;
            int Upper_Case_length = 1;
            int Lower_Case_length = 1;
            Cantidad = 3;
            if (Password.Length < Minimum_Length)
            {
                Cantidad = Cantidad - 1;
                return false;
            }
            if (UpperCaseCount(Password) < Upper_Case_length)
            {
                Cantidad = Cantidad - 1;
                return false;
            }
            if (LowerCaseCount(Password) < Lower_Case_length)
            {
                Cantidad = Cantidad - 1;
                return false;
            }
            if (NumericCount(Password) < 1)
            {
                Cantidad = Cantidad - 1;
                return false;
            }
            Cantidad = 4;
            return true;
        }
        private static int UpperCaseCount(string Password)
        {
            return Regex.Matches(Password, "[A-Z]").Count;
        }

        private static int LowerCaseCount(string Password)
        {
            return Regex.Matches(Password, "[a-z]").Count;
        }
        private static int NumericCount(string Password)
        {
            return Regex.Matches(Password, "[0-9]").Count;
        }
        private static int NonAlphaCount(string Password)
        {
            return Regex.Matches(Password, @"[^0-9a-zA-Z\._]").Count;
        }
    }
}