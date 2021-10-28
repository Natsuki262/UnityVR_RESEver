using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetInstanceDataTest : MonoBehaviour
{
    [SerializeField]
    TargetInstanceData instanceData;
    // Start is called before the first frame update
    void Start()
    {
             
       GameObject obj= Instantiate(instanceData.TargetPrefab);
        obj.transform.position = instanceData.TargetPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
