using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBindingData {
    public KeyCode KeyBindingA;

    public KeyCode KeyBindingB;

    public KeyBindingData() {

    }

    public KeyBindingData(KeyCode bindingA, KeyCode bindingB) {
        KeyBindingA = bindingA;
        KeyBindingB = bindingB;
    }


}
