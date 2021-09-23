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
    //�J�����̉����x
    [SerializeField]
    float cameraACX, cameraACY;

    //�J�[�\����\���\�����
    bool cusorOnof = true;

    Rigidbody _rigidbody;
    //�J�����̊p�x����
    [SerializeField]
    float minAngle, maxAngle;
    void Start()
    {
        //�Q�[���J�n���̌��݂̊p�x���i�[
        cameraRot = playerCamera.transform.localRotation;
        charactorRot = transform.localRotation;



    }

    // Update is called once per frame
    void Update()
    {

        /*float xRot = Input.GetAxisRaw("Mouse X") * cameraACY;
        float yRot = Input.GetAxisRaw("Mouse Y") * cameraACX;
        cameraRot *= Quaternion.Euler(-yRot,0, 0);
        charactorRot *= Quaternion.Euler(0,xRot, 0);
        //�w��̐��l����cameraRot�𐧌�����
        cameraRot = ClampRotation(cameraRot);

        playerCamera.transform.localRotation = cameraRot;
        transform.localRotation = charactorRot;*/


        UpdateCursolONOFF();




    }
    private void FixedUpdate()
    {
        _rigidbody = GetComponent<Rigidbody>();
        charaMoveX = 0;
        charaMoveY = 0;
        charaMoveZ = 0;

        //charaMoveX = Input.GetAxis("Horizontal") * charaSpeed;
        //charaMoveZ = Input.GetAxisRaw("Vertical") * charaSpeed;
        float xVec = Input.GetAxis("Horizontal");
        float zVec = Input.GetAxis("Vertical");
        //transform.position += new Vector3(charaMoveX, 0, charaMoveZ);
        //transform.position += playerCamera.transform.forward * charaMoveZ + playerCamera.transform.right * charaMoveX;
        //_rigidbody.AddForce(playerCamera.transform.forward,1);//���ƂŒ���
        //_rigidbody.AddForce(playerCamera.transform.transform.forward *charaSpeed );
        //_rigidbody.AddForce(charaMoveX, 0, charaMoveZ);
        Vector3 camVec = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized;
        Vector3 rightVec = new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z);
        Vector3 input = new Vector3(xVec, 0, zVec);
        Vector3 moveVec = (camVec * input.z + rightVec * input.x).normalized;
        _rigidbody.velocity = moveVec * charaSpeed;

    }
    //�J�[�\�����I���I�t�؂�ւ���֐� 
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
    //�v���C���[�̃J�����p�x�����֐���������̂ō���͎g���Ă��܂���
    public Quaternion ClampRotation(Quaternion q)
    {
        //q=X,Y,Z,W(xyz�x�N�g���i�ʂƌ����j�FW�̓X�J���[�i���W�Ƃ͖��֌W�̗ʁF��]���邠�ƂŒ��ׂ�j
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w /= 1f;
        //�l�������WQutaternion���O�����n�Ŏg����悤�ɂ��邽�ߕK�v�@

        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;
        //Quaternion����I�C���[�ɕϊ����邽�߂ɕK�v�炵�����������Ƃ�
        //Mathf�Ƃ����͎̂O�p�֐��@����͎O�p�֐�����p�x�����߂Ă���@��
        //���߂��p�x�����W�A���l�Ȃ̂ŁA�x���ɕϊ����Ă��鏈��

        angleX = Mathf.Clamp(angleX, minAngle, maxAngle);
        //Clanmp��X�̒l�������ɐݒ肵���l�܂ŉ����鏈��
        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);
        //�p�x����O�p�֐������߂�x���烉�W�A���ɖ߂�����
        return q;
    }
}
