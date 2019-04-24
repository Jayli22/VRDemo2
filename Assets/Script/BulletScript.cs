using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Timer timer;
    public GameObject[] explosioneffect;
    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 5f;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
     if(timer.Finished == true)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Instantiate(explosioneffect[0], transform.position, transform.rotation);
            Destroy(gameObject);
            
        }
    }

}
