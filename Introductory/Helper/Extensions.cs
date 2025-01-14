using static Introductory.Helper.Calendar;

namespace Introductory.Helper
{
    public static class Extensions
    {
        public static int ToInt32(this object o)
        {
            try
            {
                return Convert.ToInt32(o);
            }
            catch 
            { 
                return 0;
            }
        }

        public static string ToText(this object o)
        {
            try
            {
                return string.IsNullOrEmpty(Convert.ToString(o)) ? "" : o.ToString();
            }
            catch
            {
                return "";
            }
        }

        public static string ToNepaliDate(this DateTime? dt)
        {
            try
            {
                if (dt == null)
                {
                    return string.Empty;
                }
                else
                {
                    DateTime dtt = Convert.ToDateTime(dt);
                    NepDate nepDate = NepDateConverter.EngToNep(dtt.Year, dtt.Month, dtt.Day);
                    return string.Format("{0}/{1}/{2}", nepDate.Year, nepDate.Month, nepDate.Day);
                }
            }
            catch
            {
                return null;
            }
        }

        public static DateTime? ToEnglishDate(this object o)
        {
            try
            {
                var chunks = o.ToText().Split('-', '/', '.');
                if (chunks.Length != 3)
                {
                    return null;
                }
                int year = chunks[0].ToInt32();
                int month = chunks[1].ToInt32();
                int day = chunks[2].ToInt32();
                return NepDateConverter.NepToEng(year, month, day);
            }
            catch
            {
                return null;
            }
        }
    }
}
