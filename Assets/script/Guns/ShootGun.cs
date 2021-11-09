using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    /// <summary>�e</summary>
    [SerializeField]
    private GameObject bullet;
    
    /// <summary>
    ///�e�ۂ̏���
    /// </summary>
    [SerializeField]
    private float bulletPower;
    /// <summary>
    /// �}�Y���̈ʒu
    /// </summary>
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
       
       
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            
        }
       


    }
    void Shoot()
    {
        GameObject bulletInstance = Instantiate<GameObject>(bullet, muzzle.position, muzzle.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(bulletInstance.transform.forward * bulletPower);
        Destroy(bulletInstance, 5f);
    }

}
