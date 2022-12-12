using System.Collections;
using System.Collections.Generic;
using MapBuild;
using UnityEngine;

public partial class MapGeneratorView
{
    public override void OnShow()
    {
        NoneButton.onClick.AddListener(() => { OnClickButton(MapGeneratorType.Move); });
        DrawButton.onClick.AddListener(() => { OnClickButton(MapGeneratorType.DrawTile); });
        EarseButton.onClick.AddListener(() => { OnClickButton(MapGeneratorType.EarseTile); });
        ReplaceButton.onClick.AddListener(() => { OnClickButton(MapGeneratorType.Replace); });
    }

    public void OnClickButton(MapGeneratorType type)
    {
        switch (type) {
            case MapGeneratorType.DrawTile:
                Find.MapGenerator.CurGeneratorType = MapGeneratorType.DrawTile;
                break;
            case MapGeneratorType.EarseTile:
                Find.MapGenerator.CurGeneratorType = MapGeneratorType.EarseTile;
                break;
            case MapGeneratorType.Move:
                Find.MapGenerator.CurGeneratorType = MapGeneratorType.Move;
                break;
            case MapGeneratorType.Replace:
                Find.MapGenerator.CurGeneratorType = MapGeneratorType.Replace;
                break;
        }
    }
}
