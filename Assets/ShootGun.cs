using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    //èeå˚
    [SerializeField]
    private Transform bulletPrefab;
    //íeÇîÚÇŒÇ∑óÕ
    [SerializeField]
    private float bulletPower = 300f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        

    }
}
