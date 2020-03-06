using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.CrossCutting.MultiLanguaje
{
    public interface ILanguage
    {
        void Initialize(CultureInfo culture);
        CultureInfo Culture { get; set; }
        string GetText(string key, params object[] values);

        string GetError(ErrorTexts type);
        string GetError(string field);

        string GetDisplay(string displayKey);
    }
}
