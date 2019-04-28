using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyGeneration : MonoBehaviour
{
    private Timer generate_timer;
    public GameObject[] enemy;
    private int generatetime = 0;
    // Start is called before the first frame update
    void Start()
    {
        generate_timer = gameObject.AddComponent<Timer>();

        generate_timer.Duration = 5f;
        generate_timer.Run();

    }

    // Update is called once per frame
    void Update()
    {
        if(generate_timer.Finished == true && generatetime < 10)
        {
            for (int i = 0; i < generatetime; i++)
            {
                Vector2 p = Random.insideUnitCircle * 400;
                Vector2 pos = p.normalized * (2 + p.magnitude);
                Vector3 pos2 = new Vector3(pos.x, 0, pos.y);
                int n = Random.Range(0, 2);
                if (n == 0)
                    Instantiate(enemy[0], pos2, Quaternion.identity);
                else
                {
                    pos2.y = 14f;
                    Instantiate(enemy[1], pos2, Quaternion.identity);
                }

            }
            generate_timer.Run();
            generatetime++;
        }
        Debug.Log(generatetime);
        Debug.Log(GameObject.FindGameObjectWithTag("Enemy"));
        if (generatetime>=10 && GameObject.FindGameObjectWithTag("Enemy") == null)
        {
           
            SceneManager.LoadScene("WinScene");
        }

    }
}
