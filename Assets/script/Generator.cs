using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject generatedObject;
    [SerializeField]
    int enemyCount =0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("EnemyInstantiate");
    }

    // Update is called once per frame
   IEnumerator EnemyInstantiate()
    {
        float x = 0;
        for (int count = 0;count<enemyCount;count++)
        {
            yield return new WaitForSeconds(1f);
            Instantiate(generatedObject, new Vector3(x, 1, 0), Quaternion.identity);
            Debug.Log("test");
            x += 5;
        }
    }
}
