using System;
using System.Threading.Tasks;

namespace Subtle.Model
{
    internal static class TaskExtensions
    {
        public static async Task<TResult> WithTimeout<TResult>(this Task<TResult> task, TimeSpan timeout)
        {
            if (await Task.WhenAny(task, Task.Delay(timeout)) == task)
            {
                return task.GetAwaiter().GetResult();
            }

            throw new TimeoutException("Request timed out");
        }
    }
}
