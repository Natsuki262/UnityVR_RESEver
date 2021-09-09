using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour
{

    // Start is called before the first frame update[

    //移動用変数
    float charaMoveX, charaMoveY, charaMoveZ;

    //移動速度
    [SerializeField]
    float charaSpeed;

    //camera取得
    [SerializeField]
    GameObject playerCamera;
    Quaternion cameraRot, charactorRot;
    //カメラの加速度
    [SerializeField]
    float cameraACX, cameraACY;

    //カーソル非表示表示状態
    bool cusorOnof = true;
    void Start()
    {
        //ゲーム開始時の現在の角度を格納
        cameraRot = playerCamera.transform.localRotation;
        charactorRot = transform.localRotation;



    }

    // Update is called once per frame
    void Update()
    {
        float xRot = Input.GetAxisRaw("Mouse X") * cameraACX;
        float yRot = Input.GetAxisRaw("Mouse Y") * cameraACY;
        cameraRot *= Quaternion.Euler(-yRot, 0, 0);
        charactorRot *= Quaternion.Euler(0, xRot, 0);

        playerCamera.transform.localRotation = cameraRot;
        transform.localRotation = charactorRot;

        UpdateCursolONOFF();


    }
    private void FixedUpdate()
    {
        charaMoveX = 0;
        charaMoveY = 0;
        charaMoveZ = 0;

        charaMoveX = Input.GetAxis("Horizontal") * charaSpeed;
        charaMoveZ = Input.GetAxisRaw("Vertical") * charaSpeed;

        //transform.position += new Vector3(charaMoveX, 0, charaMoveZ);
        transform.position += playerCamera.transform.forward * charaMoveZ + playerCamera.transform.right * charaMoveX;

    }
    public void UpdateCursolONOFF()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cusorOnof = false;


        }
        else if (Input.GetMouseButtonDown(0))
        {
            cusorOnof = true;
        }

        if (cusorOnof)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (!cusorOnof)
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }
}
