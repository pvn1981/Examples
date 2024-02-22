﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace CultureInfoExplorer
{
    public class MainViewModel
    {
        public ReadOnlyCollection<CultureInfo> Cultures { get; private set; }
        public CultureInfo SelectedCulture { get; set; }

        public ReadOnlyCollection<CultureInfoProperty> Properties { get; private set; }
        public CultureInfoProperty SelectedProperty { get; set; }
        public string SelectedPropertyValue { get; set; }

        public ReadOnlyCollection<Pattern> Patterns { get; private set; }
        public Pattern SelectedPattern { get; set; }
        public string SelectedPatternValue { get; set; }

        public MainViewModel()
        {
            Cultures = ExploreHelper.AllCultures;

            SelectedCulture = CultureInfo.InvariantCulture;

            Properties = ExploreHelper.AllProperties;
            SelectedProperty = Properties.First();

            Patterns = ExploreHelper.AllPatterns;
            SelectedPattern = Patterns.First();
        }
    }
}