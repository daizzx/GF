using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel 
{

    public UIType uiType;
    public GameObject activeObejctPanel;

    public BasePanel(UIType _type) 
    {
        uiType = _type;
    }



    public virtual void OnStart()
    {
        UIMethod.GetInstance().GetOrAddComponent<CanvasGroup>(activeObejctPanel).interactable = true;

    }

    public virtual void OnEnable()
    {
        UIMethod.GetInstance().GetOrAddComponent<CanvasGroup>(activeObejctPanel).interactable = true;

    }

    public virtual void OnDisable()
    {
        UIMethod.GetInstance().GetOrAddComponent<CanvasGroup>(activeObejctPanel).interactable = false;
    }

    public virtual void OnDestroy()
    {
        UIMethod.GetInstance().GetOrAddComponent<CanvasGroup>(activeObejctPanel).interactable = false;

    }
}
