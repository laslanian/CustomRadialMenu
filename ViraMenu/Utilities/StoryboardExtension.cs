using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace ViraMenu.Utilities
{
    public static class StoryboardExtensions
    {
        public static Task BeginAsync(this Storyboard storyboard)
        {
            Console.Write("new task     ");
            System.Threading.Tasks.TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            if (storyboard == null)
                tcs.SetException(new ArgumentNullException());
            else
            {
                EventHandler onComplete = null;
                onComplete = (s, e) =>
                {
                    storyboard.Completed -= onComplete;
                    tcs.SetResult(true);
                };
                storyboard.Completed += onComplete;
                storyboard.Begin();
            }
            return tcs.Task;
        }
    }

    //Start the storyboard and asynchronously await completion...
   // 
    //Do my other stuff here, after the storyboard completes...

}
