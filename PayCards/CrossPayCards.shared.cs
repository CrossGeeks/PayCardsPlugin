using System;

namespace Plugin.PayCards
{
    /// <summary>
    /// Cross platform PayCards implemention
    /// </summary>
    public static class CrossPayCards
    {
        private static Lazy<IPayCardsRecognizerService> implementation = new Lazy<IPayCardsRecognizerService>(() => CreatePayCards(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Gets if the plugin is supported on the current platform.
        /// </summary>
        public static bool IsSupported => implementation.Value == null ? false : true;

        /// <summary>
        /// Current settings to use
        /// </summary>
        public static IPayCardsRecognizerService Current
        {
            get
            {
                var ret = implementation.Value;
                if (ret == null)
                {
                    throw NotImplementedInReferenceAssembly();
                }
                return ret;
            }
        }

#if ANDROID
        public static PayCardsRecognizerService Android => (PayCardsRecognizerService)Current;
#elif IOS
        public static PayCardsRecognizerService IOS => (PayCardsRecognizerService)Current;
#endif

        private static IPayCardsRecognizerService CreatePayCards()
        {

#if NETSTANDARD1_0 || NETSTANDARD2_0
            return null;
#else
#pragma warning disable IDE0022 // Use expression body for methods
            return new PayCardsRecognizerService();
#pragma warning restore IDE0022 // Use expression body for methods
#endif
        }

        internal static Exception NotImplementedInReferenceAssembly()
        {
            return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
        }
    }
}
