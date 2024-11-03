using System;
using System.Reflection;
using CoreToolKit.UnityEngine.Scheduler;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace CoreToolKit.Tests.EditMode.UnityEngine.Scheduler
{
  using System.Threading.Tasks;

  public class UnityTaskRunnerTest
  {
    private const int MsDelay = 1;

    [SetUp]
    public void SetUp()
    {
      InitializeUnityScheduler();
    }

    [Test]
    public async Task UnityScheduler_RunFunction_IsRunningInMainThread()
    {
      int Func()
      {
        Assert.IsTrue( UnityTaskRunner.IsMainThread(), $"{nameof( Func )} isn't running in the Main Thread, it's running in {Environment.CurrentManagedThreadId}." );
        return 1;
      }

      await UnityTaskRunner.Run( Func );
      LogAssert.NoUnexpectedReceived();
    }

    [Test]
    public async Task UnityScheduler_RunAction_IsRunningInMainThread()
    {
      void Action() => Assert.IsTrue( UnityTaskRunner.IsMainThread(), $"{nameof( Action )} isn't running in the Main Thread, it's running in {Environment.CurrentManagedThreadId}." );

      await UnityTaskRunner.Run( Action );
      LogAssert.NoUnexpectedReceived();
    }

    [Test]
    public async Task UnityScheduler_RunFuncThatReturnTaskWithReturnType_IsRunningInMainThread()
    {
      async Task<int> DelayAsync()
      {
        Assert.IsTrue( UnityTaskRunner.IsMainThread(), $"{nameof( DelayAsync )} isn't running in the Main Thread, it's running in {Environment.CurrentManagedThreadId}." );
        await Task.Delay( MsDelay );
        return 1;
      }
      Func<Task<int>> funcAsync = DelayAsync;

      await UnityTaskRunner.Run( funcAsync );
      LogAssert.NoUnexpectedReceived();
    }

    [Test]
    public async Task UnityScheduler_RunFuncThatReturnTask_IsRunningInMainThread()
    {
      async Task DelayAsync()
      {
        Assert.IsTrue( UnityTaskRunner.IsMainThread(), $"{nameof( DelayAsync )} isn't running in the Main Thread, it's running in {Environment.CurrentManagedThreadId}." );
        await Task.Delay( MsDelay );
      }
      Func<Task> funcAsync = DelayAsync;

      await UnityTaskRunner.Run( funcAsync );
      LogAssert.NoUnexpectedReceived();
    }

    [Test]
    public async Task UnityScheduler_EnsureRunInMainThread_IsRunningInMainThread()
    {
      void Action() => Assert.IsTrue( UnityTaskRunner.IsMainThread(), $"{nameof( Action )} isn't running in the Main Thread, it's running in {Environment.CurrentManagedThreadId}." );

      await UnityTaskRunner.EnsureOnMainThread( Action );
      LogAssert.NoUnexpectedReceived();
    }

    private void InitializeUnityScheduler()
    {
      const string methodName = "Init";

      // Get the type of the static class.
      Type type = typeof( UnityTaskRunner );

      // Use Reflection to get the private static method information.
      MethodInfo privateStaticMethodInfo = type.GetMethod( methodName, BindingFlags.NonPublic | BindingFlags.Static );

      // Check if the method was found (null check).
      Assert.IsNotNull( privateStaticMethodInfo, $"Private static method {methodName} not found in {nameof( UnityTaskRunner )}." );

      // Invoke the private static method with a parameter and cast the result if needed
      privateStaticMethodInfo.Invoke( null, null );

      // Assert the expected output
      Assert.IsTrue( UnityTaskRunner.MainThreadId > -1, $"Main thread Id is {UnityTaskRunner.MainThreadId}." );
      Assert.IsNotNull( UnityTaskRunner.UnitySynchronizationContext , "Unity Synchronization Context is null." );
    }
  }
}