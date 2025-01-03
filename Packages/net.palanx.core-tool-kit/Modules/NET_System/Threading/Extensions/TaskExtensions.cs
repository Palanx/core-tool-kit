using System;
using ILogger = CoreToolKit.Logger.ILogger;

namespace CoreToolKit.Task.Extensions
{
  using System.Threading.Tasks;

  /// <summary>
  /// Extension methods for <see cref="Task"/> type.
  /// </summary>
  public static class TaskExtensions
  {
    /// <summary>
    /// Handle the possible exceptions thrown by the <see cref="Task"/>. Implementation
    /// for the Fire-and-Forget pattern.
    /// </summary>
    /// <param name="task">Instance.</param>
    /// <param name="log">Used to log the possible exceptions.</param>
    public static async void Forget( this Task task, ILogger log )
    {
      try
      {
        await task;
      }
      catch ( Exception ex )
      {
        log?.Exception( $"Exception thrown while executing Task ID {task.Id}.", ex );
      }
    }

    // TODO: Create a timer method to log an error if the task isn't completed in X amount of time.
  }
}