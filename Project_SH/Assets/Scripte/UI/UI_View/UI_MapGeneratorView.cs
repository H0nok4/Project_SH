using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MapGeneratorView : UIBaseView
{
    public UIButton NoneButton;
    public UIButton DrawButton;
    public UIButton EarseButton;
    public UIButton ReplaceButton;

    public override void Init()
    {
        NoneButton = GetUIButtonAt(0);
        DrawButton = GetUIButtonAt(1);
        EarseButton = GetUIButtonAt(2);
        ReplaceButton = GetUIButtonAt(3);
    }

}
