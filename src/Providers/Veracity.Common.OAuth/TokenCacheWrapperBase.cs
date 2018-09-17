﻿using Microsoft.Identity.Client;

namespace Veracity.Common.OAuth
{
    public abstract class TokenCacheBase
    {
        protected internal abstract TokenCache GetCacheInstance();

        public static implicit operator TokenCache(TokenCacheBase b)
        {
            return b.GetCacheInstance();
        }
    }
}