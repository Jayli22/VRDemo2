using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 15f;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished == true)
            {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
