using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager {
    private Dictionary<string, Delegate> Registed = new Dictionary<string, Delegate>();

    public void RegisterEvent(string eventName, Action action) {
        if (!Registed.ContainsKey(eventName)) {
            Registed.Add(eventName, null);
        }

        Delegate.Combine(Registed[eventName], action);
    }
     
    public void TriggerEvent(string eventName) {
        if (Registed.ContainsKey(eventName)) {
            var list = Registed[eventName].GetInvocationList();
            foreach (var @delegate in list) {
                if (@delegate != null && @delegate is Action action) {
                    try {
                        action();
                    }
                    catch (Exception e) {
                        Console.WriteLine(e);
                        throw;
                    }
                }
               
            }
        }
    }
}
