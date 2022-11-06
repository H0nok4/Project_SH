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
            Debug.LogError($"UIID������ʵ��View������id={id}");
            return false;
        }

        var view = CreatViewInstance<T>(Views[id]);
        if (view is null)
        {
            Debug.LogError($"����Viewʧ�ܣ�û�л�ȡ��View���");
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
