using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "new TimeSource", menuName = "TimeSource")]
public class TimeSource : ScriptableObject
{
    public int hour;
    public int minute;
    public int second;

    public bool systemTime;
    public bool elapsedTime;

    
}
