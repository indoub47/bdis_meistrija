using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace bdis_meistrija.Server.Helpers
{
    public static class HttpContextExtensions
    {
        public static void InsertPaginationParametersInResponse<T>(this HttpContext httpContext, IQueryable<T> queryable, int recordsPerPage)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            double count = queryable.Count();
            double totalAmountPages = Math.Ceiling(count / recordsPerPage);
            httpContext.Response.Headers.Add("totalAmountPages", totalAmountPages.ToString());
        }
        public async static Task InsertPaginationParametersInResponseAsync<T>(this HttpContext httpContext, IQueryable<T> queryable, int recordsPerPage)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            double count = await queryable.CountAsync();
            double totalAmountPages = Math.Ceiling(count / recordsPerPage);
            httpContext.Response.Headers.Add("totalAmountPages", totalAmountPages.ToString());
        }
    }
}
