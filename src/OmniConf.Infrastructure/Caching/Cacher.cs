using Microsoft.Framework.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace OmniConf.Infrastructure.Caching
{
    public class Cacher
    {
        private readonly IMemoryCache _cache;
        public Cacher(IMemoryCache cache)
        {
            _cache = cache;
        }

        public T CacheAction<T>(Expression<Func<T>> action, [CallerMemberName] string memberName = "") where T : class
        {
            MethodCallExpression body = (MethodCallExpression)action.Body;

            ICollection<object> parameters = new List<object>();

            foreach (MemberExpression expression in body.Arguments)
            {
                parameters.Add(((FieldInfo)expression.Member).GetValue(((ConstantExpression)expression.Expression).Value));
            }

            StringBuilder builder = new StringBuilder(100);
            builder.Append(GetType().FullName);
            builder.Append(".");
            builder.Append(memberName);

            parameters.ToList().ForEach(x =>
            {
                builder.Append("_");
                builder.Append(x);
            });

            string cacheKey = builder.ToString();

            T value = _cache.Get<T>(cacheKey);

            if (value == null)
            {
                value = action.Compile().Invoke();
                _cache.Set(cacheKey, value);
            }

            return value;
        }
    }
}
