using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    //�e��
    [SerializeField]
    private Transform bulletPrefab;
    //�e���΂���
    [SerializeField]
    private float bulletPower = 300f;

    [SerializeField]
    private Transform muzzle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Ray�̏����ݒ�
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       Quaternion quaternion = Quaternion.LookRotation(ray.direction);
        float distance = 50;
       
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            
        }
       


    }
    void Shoot()
    {
        var bulletInstance = Instantiate<GameObject>(bullet, muzzle.position, muzzle.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(bulletInstance.transform.forward * bulletPower);
        Destroy(bulletInstance, 5f);
    }

}
