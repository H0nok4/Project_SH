using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICompenent : MonoBehaviour
{
    public Action OnClick;

    public bool Visible
    {
        get
        {
            return gameObject.activeSelf;
        }

        set => gameObject.SetActive(value);
    }
}
