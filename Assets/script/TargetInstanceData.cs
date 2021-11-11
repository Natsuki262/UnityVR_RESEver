
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//スクリプタブルオブジェクトを使うので継承
[CreateAssetMenu(fileName ="",menuName = "create TargetInstanceData")]
public class TargetInstanceData : ScriptableObject

{
    [SerializeField]
    private GameObject targetPrefab;
    /// <summary>
    /// Generatorにアクセスしプレハブデータを返す
    /// targetプレハブへの代入は防ぐのでSetは定義しない
    /// </summary>
    public GameObject TargetPrefab
    {
        get => targetPrefab;

    }
    /// <summary>
    /// GeneratorにアクセスしPositionデータを返す
    /// </summary>
    [SerializeField]
    private Vector3 targetPosition;

    public Vector3 TargetPosition
    {
        get => targetPosition;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
