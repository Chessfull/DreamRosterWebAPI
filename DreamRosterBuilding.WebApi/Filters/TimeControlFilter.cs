using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DreamRosterBuilding.WebApi.Filters
{
    public class TimeControlFilter:ActionFilterAttribute // -> This is a actionfilter will work on executing, managing times
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var currentTime=DateTime.Now.TimeOfDay;

            StartTime = "00:00";
            EndTime = "23:59";

            if (currentTime>=TimeSpan.Parse(StartTime) && currentTime<=TimeSpan.Parse(EndTime))
            {
                base.OnActionExecuting(context);
            }
            else
            {
                context.Result = new ContentResult
                {
                    Content = "At this time you can not request endpoints.",
                    StatusCode = 403 // -> Forbidden
                };
            }
        }
    }
}
