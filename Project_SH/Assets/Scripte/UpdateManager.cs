using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour {
    private readonly List<IUpdatable> _updateRunner = new List<IUpdatable>(); 
    public void RegisterUpdate(IUpdatable update) {
        _updateRunner.Add(update);
    }

    public void UnRegisterUpdate(IUpdatable update) {
        _updateRunner.Remove(update);
    }

    private void Update() {
        foreach (var updatable in _updateRunner) {
            updatable.Update();
        }
    }
}

public interface IUpdatable {
    public void Update();
}
