using ReportingModule.Models;
using System.Linq;

namespace ReportingModule.Reporting
{
    public class ReportGenerator
    {
        public TaskReport GenerateTaskReport(IEnumerable<Task> tasks)
        {
            var totalCount = tasks.Count();
            var completedCount = tasks.Count(t => t.Completed);
            var completionRate = ((double)completedCount / totalCount) * 100;

            return new TaskReport
            {
                Tasks = tasks,
                CompletionRate = completionRate
            };
        }
    }
}
