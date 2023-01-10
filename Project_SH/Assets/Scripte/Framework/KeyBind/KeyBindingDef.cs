using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBindingDef {
    public KeyCode DefaultKeyCodeA;

    public KeyCode DefaultKeyCodeB;

    public bool DevModeOnly;

    public KeyCode MainKey {
        get {
            if (DefaultKeyCodeA != KeyCode.None) {
                return DefaultKeyCodeA;
            }

            //if (DefaultKeyCodeB != KeyCode.None) {
            //    return DefaultKeyCodeB;
            //}

            return KeyCode.None;
        }
    }

    public bool KeyDownEvent {
        get {
            if (Input.GetKeyDown(MainKey)) {
                return true;
            }

            return false;
        }
    }
}
