using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TowerScript : MonoBehaviour
{
    [SerializeField]
    private int hp;
    private bool attackable = true;
    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if()
    }
    public void GetAttacked(int damage)
    {
        hp -= damage;
        if(hp<= 0)
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
