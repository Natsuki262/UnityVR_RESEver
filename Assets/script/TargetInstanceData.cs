
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�X�N���v�^�u���I�u�W�F�N�g���g���̂Ōp��
[CreateAssetMenu(fileName ="",menuName = "create TargetInstanceData")]
public class TargetInstanceData : ScriptableObject

{
    [SerializeField]
    private GameObject targetPrefab;
    /// <summary>
    /// Generator�ɃA�N�Z�X���v���n�u�f�[�^��Ԃ�
    /// target�v���n�u�ւ̑���͖h���̂�Set�͒�`���Ȃ�
    /// </summary>
    public GameObject TargetPrefab
    {
        get => targetPrefab;

    }
    /// <summary>
    /// Generator�ɃA�N�Z�X��Position�f�[�^��Ԃ�
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
