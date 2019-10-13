﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartStore.Core;
using SmartStore.Services.Directory;

namespace SmartStore.Services.Cart.Rules.Impl
{
    public class IPCountryRule : ListRuleBase<string>
    {
        private readonly IGeoCountryLookup _countryLookup;
        private readonly IWebHelper _webHelper;

        public IPCountryRule(IGeoCountryLookup countryLookup, IWebHelper webHelper)
        {
            _countryLookup = countryLookup;
            _webHelper = webHelper;
        }

        protected override string GetValue(CartRuleContext context)
        {
            var country = _countryLookup.LookupCountry(_webHelper.GetCurrentIpAddress());
            return country?.IsoCode ?? string.Empty;
        }
    }
}
