﻿using Sitecore.Analytics.Aggregation.Data.Model;
using Sitecore.Analytics.Model;
using Sitecore.Diagnostics;
using Sitecore.ExperienceAnalytics.Aggregation.Data.Model;
using Sitecore.ExperienceAnalytics.Aggregation.Data.Schema;
using Sitecore.ExperienceAnalytics.Aggregation.Dimensions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hi.UrlRewrite.Analytics
{
    internal class ByUrlRewriteRedirect : PageEventDimensionBase
    {
        private readonly Guid redirectEventId = new Guid(Constants.RedirectEventItemId);

        public ByUrlRewriteRedirect(Guid dimensionId)
            : base(dimensionId)
        {
        }

        protected override string ExtractDimensionKey(PageEventData pageEvent)
        {
            Assert.IsNotNull(pageEvent, "pageEvent");

            var redirectItem = Sitecore.Data.Database.GetDatabase("master").GetItem(pageEvent.ItemId.ToString());

            return redirectItem.Paths.ContentPath;
        }

        protected override bool Filter(PageEventData pageEvent)
        {
            Assert.IsNotNull(pageEvent, "pageEvent");
            return pageEvent.PageEventDefinitionId.Equals(this.redirectEventId);
        }

    }
}