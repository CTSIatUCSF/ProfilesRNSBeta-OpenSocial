namespace Subgurim.Controles
{
    internal class Utilidades
    {
        internal static string prepareJS(string inJS, bool changeQuotes)
        {
            string sRet = inJS.Replace("\n", " ").Replace("\r", " ").Replace("\t", " ");

            if (changeQuotes)
                sRet = sRet.Replace("'", "\"");

            while (sRet.Contains("  "))
                sRet = sRet.Replace("  ", " ");

            return sRet;
        }

        internal static string prepareJS(string inJS)
        {
            return prepareJS(inJS, true);
        }
    }
}