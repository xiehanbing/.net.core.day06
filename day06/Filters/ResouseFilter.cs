using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace day06.Filters
{
    /// <summary>
    /// 资源过滤器
    /// </summary>
    public class ResouseFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            string token = context.HttpContext.User.FindFirstValue(ClaimTypes.Sid);
            //context.Result=new ContentResult()
            //{
            //    Content = "结束执行"
            //};
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
           
        }
    }
}