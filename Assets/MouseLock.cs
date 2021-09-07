using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour
{

    // Start is called before the first frame update[

    //�ړ��p�ϐ�
    float charaMoveX, charaMoveY, charaMoveZ;

    //�ړ����x
    [SerializeField]
    float charaSpeed;

    //camera�擾
    [SerializeField]
    GameObject playerCamera;

    Quaternion cameraRot, charactorRot;
    [SerializeField]
    float cameraACX,cameraACY;
    void Start()
    {
        //�Q�[���J�n���̌��݂̊p�x���i�[
        cameraRot = playerCamera.transform.localRotation;
        charactorRot=transform.localRotation;



    }

    // Update is called once per frame
    void Update()
    {
        float xRot = Input.GetAxisRaw("Mouse X");
        float yRot = Input.GetAxisRaw("Mouse Y");
        cameraRot *= Quaternion.Euler(-yRot, 0, 0);
        charactorRot *= Quaternion.Euler(0, xRot, 0);

        playerCamera.transform.localRotation = cameraRot;
        transform.localRotation = charactorRot;

    }
    private void FixedUpdate()
    {
        charaMoveX = 0;
        charaMoveY = 0;
        charaMoveZ = 0;

        charaMoveX = Input.GetAxis("Horizontal")*charaSpeed;
        charaMoveZ = Input.GetAxisRaw("Vertical")*charaSpeed;

        //transform.position += new Vector3(charaMoveX, 0, charaMoveZ);
        transform.position += playerCamera.transform.forward * charaMoveZ + playerCamera.transform.right * charaMoveX;

    }
}
