using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public partial class UIManager : MonoBehaviour
{
    public List<UIBaseView> OpenList = new List<UIBaseView>();
    public static bool ShowUI<T>(int id) where T : UIBaseView,new()
    {
        if (Views.Length < id)
        {
            Debug.LogError($"UIID出错，比实际View数量大，id={id}");
            return false;
        }

        var view = CreatViewInstance<T>(Views[id]);
        if (view is null)
        {
            Debug.LogError($"创建View失败，没有获取到View组件");
            return false;
        }

        view.OnShow();

        return true;
    }

    public static UIBaseView  CreatViewInstance<T>(GameObject obj) where T : UIBaseView, new()
    {
        var view = new T
        {
            Instance = Instantiate(obj)
        };

        return view;
    }
}
