using System.Net;
using System.Threading.Tasks;

namespace Subtle.Model
{
    static class TaskExtensions
    {
        public static async Task<TResult> WithTimeout<TResult>(this Task<TResult> task, int timeout)
        {
            if (await Task.WhenAny(task, Task.Delay(timeout)) == task)
            {
                return task.Result;
            }

            throw new WebException("Request timed out");
        }
    }
}
