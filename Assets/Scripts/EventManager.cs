using System.Collections;
using System.Collections.Generic;
using System;

public class EventManager 
{
    public static event Action<int> DestructionOfPropertyAction;
    public static void DestructionOfPropertyEvent(int damageValue)
    {
        DestructionOfPropertyAction?.Invoke(damageValue);
    }

    public static event Action<bool> GameOverAction;
    public static void GameOverEvent(bool victory)
    {
        GameOverAction?.Invoke(victory);
    }

    public static event Action SniffingAction;
    public static void SniffingEvent()
    {
        SniffingAction?.Invoke();
    }
}
