using UnityEngine;
using Object = UnityEngine.Object;

public class UIBaseView
{
    public GameObject Instance;
    public virtual void OnShow()
    {

    }
    public virtual void Init()
    {

    }

    public virtual void OnHide()
    {

    }

    public void CloseSelf()
    {
        OnHide();
        Object.Destroy(Instance);
    }

    public UICompenent GetUIComponentAt(int index)
    {
        var children = Instance.transform.GetChild(index);
        return children.GetComponent<UICompenent>();
    }

    public UIButton GetUIButtonAt(int index)
    {
        var children = Instance.transform.GetChild(index);
        return children.GetComponent<UIButton>();
    }
}   
