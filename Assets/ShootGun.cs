using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    //銃口
    [SerializeField]
    private Transform bulletPrefab;
    //弾を飛ばす力
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
        //Rayの初期設定
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(ray.direction);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1f, LayerMask.GetMask("enemy")))
        {
            Destroy(this.gameObject);

        }
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
