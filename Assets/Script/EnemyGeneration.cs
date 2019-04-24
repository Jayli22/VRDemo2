using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    public GameObject[] enemy;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector2 p = Random.insideUnitCircle * 250;
            Vector2 pos = p.normalized * (2 + p.magnitude);
            Vector3 pos2 = new Vector3(pos.x, 0, pos.y);
            Instantiate(enemy[0], pos2, Quaternion.identity);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
