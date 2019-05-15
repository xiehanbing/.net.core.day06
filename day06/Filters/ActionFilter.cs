using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace day06.Filters
{
    /// <summary>
    /// 方法过滤
    /// </summary>
    public class ActionFilter:Attribute,IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //context.Result= new ContentResult()
            //{
            //    Content = "方法执行没有权限"
            //};
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}
