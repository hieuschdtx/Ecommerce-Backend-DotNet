namespace shopecommerce.Domain.Commons;

public static class HandleCharacter
{
    //private static readonly string strCheck = "áàạảãâấầậẩẫăắằặẳẵÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴéèẹẻẽêếềệểễÉÈẸẺẼÊẾỀỆỂỄ" +
    //        "óòọỏõôốồộổỗơớờợởỡÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠúùụủũưứừựửữÚÙỤỦŨƯỨỪỰỬỮíìịỉĩÍÌỊỈĨđĐýỳỵỷỹÝỲỴỶỸ~!@#$%^&*()-[{]}|\\/'\"\\.,><;:";
    private static readonly string[ ] VietNamChar =
    {
      "aAeEoOuUiIdDyY",
      "áàạảãâấầậẩẫăắằặẳẵ",
      "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
      "éèẹẻẽêếềệểễ",
      "ÉÈẸẺẼÊẾỀỆỂỄ",
      "óòọỏõôốồộổỗơớờợởỡ",
      "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
      "úùụủũưứừựửữ",
      "ÚÙỤỦŨƯỨỪỰỬỮ",
      "íìịỉĩ",
      "ÍÌỊỈĨ",
      "đ",
      "Đ",
      "ýỳỵỷỹ",
      "ÝỲỴỶỸ"
   };

    public static string ConvertAlias(string str)
    {
        str = str.Trim();
        for(var i = 1; i < VietNamChar.Length; i++)
            for(var j = 0; j < VietNamChar[i].Length; j++)
                str = str.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
        str = str.Replace(" ", "-");
        str = str.Replace("--", "-");
        str = str.Replace("?", "");
        str = str.Replace("&", "");
        str = str.Replace(",", "");
        str = str.Replace(":", "");
        str = str.Replace("!", "");
        str = str.Replace("'", "");
        str = str.Replace("\"", "");
        str = str.Replace("%", "");
        str = str.Replace("#", "");
        str = str.Replace("$", "");
        str = str.Replace("*", "");
        str = str.Replace("`", "");
        str = str.Replace("~", "");
        str = str.Replace("@", "");
        str = str.Replace("^", "");
        str = str.Replace(".", "");
        str = str.Replace("/", "");
        str = str.Replace(">", "");
        str = str.Replace("<", "");
        str = str.Replace("[", "");
        str = str.Replace("]", "");
        str = str.Replace(";", "");
        str = str.Replace("+", "");
        return str.ToLower();
    }

    public static string ConvertUnaccented(string str)
    {
        str = str.Trim();
        for(var i = 1; i < VietNamChar.Length; i++)
            for(var j = 0; j < VietNamChar[i].Length; j++)
                str = str.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
        //str = str.Replace(" ", "-");
        str = str.Replace("--", "-");
        str = str.Replace("?", "");
        str = str.Replace("&", "");
        str = str.Replace(",", "");
        str = str.Replace(":", "");
        str = str.Replace("!", "");
        str = str.Replace("'", "");
        str = str.Replace("\"", "");
        str = str.Replace("%", "");
        str = str.Replace("#", "");
        str = str.Replace("$", "");
        str = str.Replace("*", "");
        str = str.Replace("`", "");
        str = str.Replace("~", "");
        str = str.Replace("@", "");
        str = str.Replace("^", "");
        str = str.Replace(".", "");
        str = str.Replace("/", "");
        str = str.Replace(">", "");
        str = str.Replace("<", "");
        str = str.Replace("[", "");
        str = str.Replace("]", "");
        str = str.Replace(";", "");
        str = str.Replace("+", "");
        return str.ToLower();
    }
}