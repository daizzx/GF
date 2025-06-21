using System.Collections;
using System.Collections.Generic;
using UnityEditor.Purchasing;
using UnityEngine;

public class UIManager
{
    private static UIManager Instance;


    public Stack<BasePanel> stack_UI;
    public Dictionary<string, GameObject> dict_UIObeject;

    public GameObject uiCanvasObj;

    public static UIManager GetInstance()
    {
        if (Instance == null)
        {
            Debug.Log("null");
            return Instance;
        }

        else return Instance;
    }
    
    public UIManager()
    {
        Instance = this;
        stack_UI = new Stack<BasePanel>();
        dict_UIObeject = new Dictionary<string, GameObject>();
    }

    public GameObject GetSingleObject(UIType _UIType)
    {
        if(dict_UIObeject.ContainsKey(_UIType.Name))
        {
            return dict_UIObeject[_UIType.Name];
        }
        if(uiCanvasObj == null)
        {
            uiCanvasObj=UIMethod.GetInstance().FindCanvas();
        }
        GameObject gameObject = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>(_UIType.Path),uiCanvasObj.transform);


        return gameObject;
     
    }

    public void Push(BasePanel _basepanel)
    {
        if(stack_UI.Count>0)
        {
            stack_UI.Peek().OnDisable();
        }

        GameObject uiObject=GetSingleObject(_basepanel.uiType);

        dict_UIObeject.Add(uiObject.name, uiObject);


        _basepanel.activeObejctPanel = uiObject;

        if(stack_UI.Count==0) 
        {
            stack_UI.Push(_basepanel);

        }
        else
        {
            if(stack_UI.Peek().uiType.Name!=_basepanel.uiType.Name)
            {
                stack_UI.Push(_basepanel);
            }
            else
            {
                stack_UI.Pop();
                stack_UI.Push(_basepanel);
            }
        }

        _basepanel.OnStart();
    }

    public void Pop(bool _isLoad)
    {
        if(_isLoad)
        {
            while(stack_UI.Count>0)
            {
                stack_UI.Peek().OnDisable();
                stack_UI.Peek().OnDestroy();
                GameObject.Destroy(dict_UIObeject[stack_UI.Peek().uiType.Name+ "(Clone)"]);
                dict_UIObeject.Remove(stack_UI.Peek().uiType.Name);
                stack_UI.Pop();
            }
        }
        else
        {
            stack_UI.Peek().OnDisable();
            stack_UI.Peek().OnDestroy();




            GameObject.Destroy(dict_UIObeject[stack_UI.Peek().uiType.Name+ "(Clone)"]);

            dict_UIObeject.Remove(stack_UI.Peek().uiType.Name);
            stack_UI.Pop();
            if (stack_UI.Count>0 ) 
                stack_UI.Peek().OnEnable();
            
        }


    }


}
