using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 銃関連の名前空間
/// </summary>
namespace Guns
{


    public class BulletHit : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject hitObject;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            hitObject = other.gameObject.gameObject;
            Debug.Log(hitObject);
            Destroy(this.gameObject);
            Debug.Log("hit");
        }
    }
}