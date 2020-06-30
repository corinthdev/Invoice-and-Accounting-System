using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace AccountingSystems.Localization
{
    public static class AccountingSystemsLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(AccountingSystemsConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(AccountingSystemsLocalizationConfigurer).GetAssembly(),
                        "AccountingSystems.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
