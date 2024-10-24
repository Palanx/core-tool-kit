using System;
using System.Threading;
using UnityEngine;

namespace CoreToolKit.UnityEngine.Scheduler
{
  using System.Threading.Tasks;

  /// <summary>
  /// Provides a mechanism to schedule threads against Unity's UnitySynchronizationContext.
  /// </summary>
  public static class UnityTaskRunner
  {
    private static TaskScheduler _taskScheduler;

    public static int MainThreadId { get; private set; }
    public static SynchronizationContext UnitySynchronizationContext { get; private set; }

    [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSceneLoad )]
    private static void Init()
    {
      _taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
      MainThreadId = Environment.CurrentManagedThreadId;
      UnitySynchronizationContext = SynchronizationContext.Current;
    }

#if UNITY_EDITOR
    /// <summary>
    /// Override the Task Scheduler for test purposes.
    /// </summary>
    /// <param name="taskScheduler">New Task Scheduler.</param>
    public static void OverrideTaskScheduler( TaskScheduler taskScheduler )
    {
      _taskScheduler = taskScheduler;
    }
#endif

    /// <summary>
    /// Schedule a function async execution in the Unity Task Scheduler, and get the Task that returns the future
    /// result of the provided function.
    /// </summary>
    /// <param name="func">The function to schedule its async execution.</param>
    /// <param name="ct">(Optional) <see cref="CancellationToken"/> used in the function execution.</param>
    /// <param name="tco">(Optional) <see cref="TaskCreationOptions"/> used in the function execution.</param>
    /// <typeparam name="T">Return type of the provided function.</typeparam>
    /// <returns>The Task that returns the future result of the provided function.</returns>
    public static Task<T> Run<T>( Func<T> func, CancellationToken ct = default, TaskCreationOptions tco = default )
    {
      return Task.Factory.StartNew( func, ct, tco, _taskScheduler );
    }

    /// <summary>
    /// Schedule an action async execution in the Unity Task Scheduler.
    /// </summary>
    /// <param name="action">The action to schedule its async execution.</param>
    /// <param name="ct">(Optional) <see cref="CancellationToken"/> used in the function execution.</param>
    /// <param name="tco">(Optional) <see cref="TaskCreationOptions"/> used in the function execution.</param>
    /// <returns>The Task that is execution the provided action.</returns>
    public static Task Run( Action action, CancellationToken ct = default, TaskCreationOptions tco = default )
    {
      return Task.Factory.StartNew( action, ct, tco, _taskScheduler );
    }

    /// <summary>
    /// Schedule a function async execution in the Unity Task Scheduler, unwrap the function's returned Task, and get
    /// the unwrapped Task that returns the future result.
    /// </summary>
    /// <param name="funcAsync">The function to schedule its async execution.</param>
    /// <param name="ct">(Optional) <see cref="CancellationToken"/> used in the function execution.</param>
    /// <param name="tco">(Optional) <see cref="TaskCreationOptions"/> used in the function execution.</param>
    /// <typeparam name="T">Return type of the Task that the provided function returns.</typeparam>
    /// <returns>The unwrapped Task that returns the future result.</returns>
    public static Task<T> Run<T>( Func<Task<T>> funcAsync, CancellationToken ct = default, TaskCreationOptions tco = default )
    {
      return Task.Factory.StartNew( funcAsync, ct, tco, _taskScheduler ).Unwrap();
    }

    /// <summary>
    /// Schedule a function async execution in the Unity Task Scheduler, unwrap the function's returned Task and get it.
    /// </summary>
    /// <param name="funcAsync">The function to schedule its async execution.</param>
    /// <param name="ct">(Optional) <see cref="CancellationToken"/> used in the function execution.</param>
    /// <param name="tco">(Optional) <see cref="TaskCreationOptions"/> used in the function execution.</param>
    /// <returns>The unwrapped Task.</returns>
    public static Task Run( Func<Task> funcAsync, CancellationToken ct = default, TaskCreationOptions tco = default )
    {
      return Task.Factory.StartNew( funcAsync, ct, tco, _taskScheduler ).Unwrap();
    }

    /// <summary>
    /// Invoke the provided action if it's in the main thread, or schedule its async execution in the Unity Task Scheduler.
    /// </summary>
    /// <param name="action">The action to invoke or schedule its async execution.</param>
    public static async Task EnsureOnMainThread( Action action )
    {
      if ( Environment.CurrentManagedThreadId == MainThreadId )
      {
        action?.Invoke();
      }
      else
      {
        await Run( action );
      }
    }
  }
}