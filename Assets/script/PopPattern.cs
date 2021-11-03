using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "create PopPattern")]

public class PopPattern : ScriptableObject
{
    // Start is called before the first frame update
    /// <summary>
    ///TargetInstanceDataのリストIDはinstancedataの略
    /// </summary>
    [SerializeField]
    private List<TargetInstanceData> targetIDList = new List<TargetInstanceData>();
 
    /// <summary>外からもアクセスはできるが読み取り専用のリスト</summary>
    public  IReadOnlyList<TargetInstanceData> TargetIDList 
    {
        get => targetIDList;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
