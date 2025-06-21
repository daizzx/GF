using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIType 
{
    private string name;

    public string Name { get=>name;}

    private string path;

    public string Path { get=>path;}    


    public UIType(string _name, string _path)
    {
        name = _name;
        path = _path;
    }

}
