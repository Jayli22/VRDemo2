using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    [SerializeField]
    private int hp;
    private bool attackable = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if()
    }
    public void GetAttacked()
    {
        hp -= 10;
        if(hp<= 0)
        {

        }
    }
}
