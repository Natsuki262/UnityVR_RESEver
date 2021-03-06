using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    /// <summary>弾</summary>
    [SerializeField]
    private GameObject bullet;
    
    /// <summary>
    ///弾丸の初速
    /// </summary>
    [SerializeField]
    private float bulletPower;
    /// <summary>
    /// マズルの位置
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
        //Rayの初期設定
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       Quaternion quaternion = Quaternion.LookRotation(ray.direction);
       
       
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            SoundManager.soundInstance.PlaySE(SoundManager.se_Types.fire);
            
        }
       


    }
    void Shoot()
    {
        GameObject bulletInstance = Instantiate<GameObject>(bullet, muzzle.position, muzzle.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(bulletInstance.transform.forward * bulletPower);
        Destroy(bulletInstance, 5f);
    }

}
