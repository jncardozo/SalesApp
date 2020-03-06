using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.CrossCutting.MultiLanguaje
{
    /// <summary>
    /// LanguageFactory  implementation 
    /// </summary>
    public sealed class LanguageFactory
    {
        #region Singleton

        private static readonly Lazy<LanguageFactory> _instance = new Lazy<LanguageFactory>(() => new LanguageFactory());

        /// <summary>
        /// Get singleton instance of IoCFactory
        /// </summary>
        public static LanguageFactory Instance
        {
            get { return _instance.Value; }
        }

        #endregion

        #region Members

        private ILanguage _current;

        /// <summary>
        /// Get current configured IContainer
        /// <remarks>
        /// At this moment only IoCUnityContainer existss
        /// </remarks>
        /// </summary>
        public ILanguage Current
        {
            get
            {
                if (_current == null)
                    throw new InvalidOperationException("Set the container before using");
                return _current;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Only for singleton pattern, remove before field init IL anotation
        /// </summary>
        static LanguageFactory()
        {
        }

        private LanguageFactory()
        {

        }
        #endregion


        public void SetCurrent(ILanguage language, CultureInfo culture)
        {
            language.Initialize(culture);
            _current = language;
        }
    }
}
