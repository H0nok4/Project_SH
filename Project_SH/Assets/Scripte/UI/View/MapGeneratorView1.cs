using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MapGeneratorView
{
    public override void OnShow()
    {
        NoneButton.onClick.AddListener(() => { OnClickButton(MapGeneratorType.Move); });
        DrawButton.onClick.AddListener(() => { OnClickButton(MapGeneratorType.Move); });
        EarseButton.onClick.AddListener(() => { OnClickButton(MapGeneratorType.Move); });
        ReplaceButton.onClick.AddListener(() => { OnClickButton(MapGeneratorType.Move); });
    }

    public void OnClickButton(MapGeneratorType type)
    {
        
    }
}
