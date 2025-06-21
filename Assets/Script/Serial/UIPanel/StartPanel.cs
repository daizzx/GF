using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : BasePanel
{
    private static string name = "StartPanel";
    private static string path = "UIPanel/StartPanel";
    public static readonly UIType uitype = new UIType(name, path);
      

    public StartPanel() : base(uitype)
    {
    }

    public override void OnStart()
    {
        base.OnStart();

        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(activeObejctPanel, "AAA").onClick.AddListener(A);
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(activeObejctPanel, "Load").onClick.AddListener(B);

    }

    private void A()
    {
        GameManager.GetInstance().UIManager_Root.Pop(false);
    }
    private void B()
    {
        Scene2 scene2=new Scene2();
        SceneControl.GetInstance().LoadScene(scene2.sceneName, scene2);
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnDisable()
    {

        Debug.Log("Disable");
        base.OnDisable();
    }

    public override void OnDestroy()
    {
        Debug.Log("Destory");
        base.OnDestroy();
    }
}
