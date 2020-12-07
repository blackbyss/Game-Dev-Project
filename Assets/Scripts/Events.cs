using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Events
{
    public static event Action<bool> OnEndLevel;
    public static void EndLevel(bool isWin) => OnEndLevel?.Invoke(isWin);

    //public static event Action<ScenarioData> OnStartLevel;
    //public static void StartLevel(ScenarioData data) => OnStartLevel?.Invoke(data);


    public static event Action<int> OnSetLives;
    public static void SetLives(int value) => OnSetLives?.Invoke(value);


    public static event Func<int> OnRequestLives;
    public static int RequestLives() => OnRequestLives?.Invoke() ?? 0;
}
