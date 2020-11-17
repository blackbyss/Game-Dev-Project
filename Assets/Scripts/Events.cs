using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Events
{
    public static event Action<bool> OnEndLevel;
    public static void EndLevel(bool isWin) => OnEndLevel?.Invoke(isWin);
}
