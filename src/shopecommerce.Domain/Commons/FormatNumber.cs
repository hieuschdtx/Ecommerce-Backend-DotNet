namespace shopecommerce.Domain.Commons
{
    public static class FormatNumber
    {
        public static string fNumber(object value, int rounded = 2)
        {
            bool isNumber = IsNumeric(value);
            decimal cost = 0;
            if(isNumber)
            {
                cost = Convert.ToDecimal(value);
            }

            string decimals = "";
            for(int i = 0; i < rounded; i++)
            {
                decimals += "#";
            }
            if(decimals.Length > 0)
                decimals = "." + decimals;
            string snumformat = string.Format("0:#,##0{0}", decimals);
            string str = string.Format("{" + snumformat + "}", cost);

            return str;
        }
        private static bool IsNumeric(object value)
        {
            return value is sbyte
                       || value is byte
                       || value is short
                       || value is ushort
                       || value is int
                       || value is uint
                       || value is long
                       || value is ulong
                       || value is float
                       || value is double
                       || value is decimal;
        }
    }
}
