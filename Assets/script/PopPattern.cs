using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "create PopPattern")]

public class PopPattern : ScriptableObject
{
    // Start is called before the first frame update
    /// <summary>
    ///TargetInstanceData�̃��X�gID��instancedata�̗�
    /// </summary>
    [SerializeField]
    private List<TargetInstanceData> targetIDList = new List<TargetInstanceData>();
 
    /// <summary>�O������A�N�Z�X�͂ł��邪�ǂݎ���p�̃��X�g</summary>
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
