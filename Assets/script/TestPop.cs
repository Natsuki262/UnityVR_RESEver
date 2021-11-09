using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPop : MonoBehaviour
{
    [SerializeField]
    PopPattern popPattern;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = Instantiate(popPattern.TargetIDList[0].TargetPrefab);
        obj.transform.position = popPattern.TargetIDList[0].TargetPosition;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Pop()
    {
        foreach ( TargetInstanceData tid in popPattern.TargetIDList)
        {

        }
    }
}
