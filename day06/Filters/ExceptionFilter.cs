using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace day06.Filters
{
    /// <summary>
    /// 异常过滤
    /// </summary>
    public class ExceptionFilter:ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {

            context.Result=new ContentResult()
            {
                Content = "系统发生异常"
            };
        }
    }
}