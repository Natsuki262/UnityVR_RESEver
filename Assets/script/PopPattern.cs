using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopPattern : ScriptableObject
{
    // Start is called before the first frame update
    /// <summary>
    ///TargetInstanceDataのリストIDはinstancedataの略
    /// </summary>
    [SerializeField]
    private List<TargetInstanceData> tagetIDList = new List<TargetInstanceData>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
