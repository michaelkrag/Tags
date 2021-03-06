﻿using System;
using System.Globalization;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Globalization;
using EPiServer.Web;
using Geta.Tags.Attributes;

namespace Geta.Tags.Helpers
{
    public static class TagsHelper
    {
        public static string GetGroupKeyFromAttributes(
            TagsGroupKeyAttribute groupKeyAttribute, CultureSpecificAttribute cultureSpecificAttribute)
        {
            var groupKey = string.Empty;

            if (groupKeyAttribute != null)
            {
                groupKey += groupKeyAttribute.Key;
            }

            if (cultureSpecificAttribute != null && cultureSpecificAttribute.IsCultureSpecific)
            {
                groupKey += ContentLanguage.PreferredCulture ?? CultureInfo.CurrentCulture;
            }

            return groupKey;
        }

        public static ContentReference GetContentReference(Guid contentGuid)
        {
            return PermanentLinkUtility.FindContentReference(contentGuid) ?? ContentReference.EmptyReference;
        }

        public static bool IsTagProperty(PropertyDefinition propertyDefinition)
        {
            return propertyDefinition != null
                   && propertyDefinition.TemplateHint == "Tags";
        }
    }
}