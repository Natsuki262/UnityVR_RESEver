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

    //カメラの角度制限
    [SerializeField]
    float minAngle, maxAngle;
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
        //指定の数値内にcameraRotを制限する
        cameraRot = ClampRotation(cameraRot);

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
    //カーソルをオンオフ切り替える関数 
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
    //プレイヤーのカメラ角度制限関数
    public Quaternion ClampRotation(Quaternion q)
    {
        //q=X,Y,Z,W(xyzベクトル（量と向き）：Wはスカラー（座標とは無関係の量：回転するあとで調べる）
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w /= 1f;
        //四次元座標Qutaternionを三次元系で使えるようにするため必要　

        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;
        //Quaternionからオイラーに変換するために必要らしいここもあとで
        //Mathfというのは三角関数　これは三角関数から角度を求めている　が
        //求めた角度がラジアン値なので、度数に変換している処理

        angleX = Mathf.Clamp(angleX, minAngle, maxAngle);
        //ClanmpはXの値を引数に設定した値まで下げる処理
        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);
        //角度から三角関数を求める度数らラジアンに戻す処理
        return q;
    }
}
