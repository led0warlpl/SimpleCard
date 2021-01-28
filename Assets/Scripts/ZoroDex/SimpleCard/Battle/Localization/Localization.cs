using System;
using System.Collections.Generic;
using ZoroDex.SimpleCard.Patterns;

namespace ZoroDex.SimpleCard.Battle.Localization
{
    /// <summary>
    ///     TODO: Not fully implemented. Demands to load the [tag, text] from a file.
    /// </summary>
    public class Localization : Singleton<Localization>
    {
        readonly Dictionary<LocalizationIds, string> data = new Dictionary<LocalizationIds, string>();

        public Localization()
        {
            foreach (var id in Enum.GetValues(typeof(LocalizationIds))) ;
        }

        public string Get(LocalizationIds id) => data[id];

    }
}