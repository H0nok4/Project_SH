using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPrefsData {
    public Dictionary<KeyBindingDef, KeyBindingData> KeyPrefs = new Dictionary<KeyBindingDef, KeyBindingData>();

    public void ResetToDefaults() {
        KeyPrefs.Clear();
    }


}
