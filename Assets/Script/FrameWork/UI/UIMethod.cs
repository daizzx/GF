using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMethod 
{
    private static UIMethod instance;

    public static UIMethod GetInstance()
    {
        if (instance == null)
        {
            
            return new UIMethod();
        }
        return instance;
    }

    public GameObject FindCanvas()
    {
        GameObject m_GameObject = GameObject.FindObjectOfType<Canvas>().gameObject;

        if (m_GameObject == null)
        {
            Debug.Log("NULL");
            return null;
        }

            return m_GameObject;
    }

    public GameObject FindChild(GameObject _father,string child_Name)
    {
        Transform[]transforms=_father.GetComponentsInChildren<Transform>();


        foreach (Transform t in transforms)
        {
            if(t.name == child_Name)
            {
                return t.gameObject;
            }
        }

        return null;
    }

    public T GetOrAddComponent<T>(GameObject Get_Obj) where T : Component
    {
        if (Get_Obj.GetComponent<T>() != null)
        {
            return Get_Obj.GetComponent<T>();
        }


        return null;
    }

    public T GetOrAddSingleComponentInChild<T>(GameObject panel, string ComponentName) where T : Component
    {
        Transform[] transforms = panel.GetComponentsInChildren<Transform>();

        foreach (Transform tra in transforms)
        {
            if (tra.gameObject.name == ComponentName)
            {
                return tra.gameObject.GetComponent<T>();

            }
        }

        Debug.LogWarning($"没有在{panel.name}中找到{ComponentName}物体！");
        return null;
    }


}
