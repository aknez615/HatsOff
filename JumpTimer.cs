using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using JetBrains.Annotations;
using UnityEngine;

public abstract class JumpTimer
{
    protected float initialTime;

    protected float Time { get; set; }

    public bool isRunning { get; protected set; }

    public float Progress => Time / initialTime;

    public Action OnTimerStart = delegate { };
    public Action OnTimerStop = delegate { };

    protected JumpTimer(float value)
    {
        initialTime = value;
        isRunning = false;
    }

    public void Start()
    {
        Time = initialTime;
        if (!isRunning)
        {
            isRunning = true;
            OnTimerStart.Invoke();
        }
    }

    public void Stop()
    {
        if (isRunning)
        {
            isRunning = false;
            OnTimerStop.Invoke();
        }
    }

    public void Resume() => isRunning = true;
    public void Pause() => isRunning = false;

    public abstract void Tick(float deltaTime);
}

//Countdown/cooldown timer
public class CountdownTimer : JumpTimer
{
    public CountdownTimer(float value) : base(value) { }

    public override void Tick(float deltaTime)
    {
        if (isRunning && Time > 0)
        {
            Time -= deltaTime;
        }

        if (isRunning && Time <= 0)
        {
            Stop();
        }
    }

    public bool isFinished => Time <= 0;

    public void Reset() => Time = initialTime;

    public void Reset(float newTime)
    {
        initialTime = newTime;
        Reset();
    }
}

//Stopwatch timer
public class StopwatchTimer : JumpTimer
{
    public StopwatchTimer() : base(0) { }

    public override void Tick(float deltaTime)
    {
        if (isRunning)
        {
            Time += deltaTime;
        }
    }

    public void Reset() => Time = 0;

    public float GetTime() => Time;
}
