using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    // Start is called before the first frame update
   
    // Allocate an initial capacity; this will be resized if needed.
    private static Camera[] AllCameras = new Camera[32];
    public GameObject[] bullet;
    private CharacterController controller;
    public GameObject rifle;
    private GameObject rifleeffect;
    private bool isfire;
    private Timer shootcooldown;

    private string currentButton;//当前按下的按键
    private string currentAxis;//当前移动的轴向
    private float Xaxis;
    private float Yaxis;
    private float axis3;
    private float axis4;
    private float axis5;
    private float axis6;
    private float axis7;
    private float axis8;
    private float axis9;
    private float axis10;
    private float axis11;
    private float axis12;
    private float axis13;
    private float axis14;
    private float axis15;

    private float translationy;
    private float translationx;
    private float axisInput;//当前轴向的值


    Vector3 movement;

    void Start()
    {
        controller = GetComponentInParent<CharacterController>();
        shootcooldown = gameObject.AddComponent<Timer>();
        shootcooldown.Duration = 0.3f;
        shootcooldown.Run();
    }
    // Update is called once per frame
    void Update()
    {
        getAxis();
        getButtons();
   
    }
    void getButtons()
    {
        var values = Enum.GetValues(typeof(KeyCode));//存储所有的按键
        for (int x = 0; x < values.Length; x++)
        {
            if (Input.GetKeyDown((KeyCode)values.GetValue(x)))
            {
                currentButton = values.GetValue(x).ToString();//遍历并获取当前按下的按键

            }
        }
        if (Input.GetKey(KeyCode.JoystickButton7))
        {
            if (shootcooldown.Finished == true)
            {
                isfire = true;
                shootcooldown.Run();
            }
        }
        if (Input.GetKeyUp(KeyCode.JoystickButton7))
        {
            isfire = false;

        }
        Fire();

    }

    /// <summary>
    /// Get Axis data of the joysick
    /// </summary>
    void getAxis()
    {
        Yaxis = 0;
        Xaxis = 0;

        if (Input.GetAxisRaw("X axis") > 0.3 || Input.GetAxisRaw("X axis") < -0.3)
        {
            currentAxis = "X axis";
            Xaxis = Input.GetAxisRaw("X axis");
        }

        if (Input.GetAxisRaw("Y axis") > 0.3 || Input.GetAxisRaw("Y axis") < -0.3)
        {
            currentAxis = "Y axis";
            Yaxis = Input.GetAxisRaw("Y axis");
        }

        if (Input.GetAxisRaw("3rd axis") > 0.3 || Input.GetAxisRaw("3rd axis") < -0.3)
        {
            currentAxis = "3rd axis";
            axis3 = Input.GetAxisRaw("3rd axis");
        }

        if (Input.GetAxisRaw("4th axis") > 0.3 || Input.GetAxisRaw("4th axis") < -0.3)
        {
            currentAxis = "4th axis";
            axis4 = Input.GetAxisRaw("4th axis");
        }

        if (Input.GetAxisRaw("5th axis") > 0.3 || Input.GetAxisRaw("5th axis") < -0.3)
        {
            currentAxis = "5th axis";
            axis5 = Input.GetAxisRaw("5th axis");
        }

        if (Input.GetAxisRaw("6th axis") > 0.3 || Input.GetAxisRaw("6th axis") < -0.3)
        {
            currentAxis = "6th axis";
            axis6 = Input.GetAxisRaw("6th axis");
        }

        if (Input.GetAxisRaw("7th axis") > 0.3 || Input.GetAxisRaw("7th axis") < -0.3)
        {
            currentAxis = "7th axis";
            axis7 = Input.GetAxisRaw("7th axis");
        }

        if (Input.GetAxisRaw("8th axis") > 0.3 || Input.GetAxisRaw("8th axis") < -0.3)
        {
            currentAxis = "8th axis";
            axis8 = Input.GetAxisRaw("8th axis");
        }

        if (Input.GetAxisRaw("9th axis") > 0.3 || Input.GetAxisRaw("9th axis") < -0.3)
        {
            currentAxis = "9th axis";
            axis9 = Input.GetAxisRaw("9th axis");
        }

        if (Input.GetAxisRaw("10th axis") > 0.3 || Input.GetAxisRaw("10th axis") < -0.3)
        {
            currentAxis = "10th axis";
            axis10 = Input.GetAxisRaw("10th axis");
        }

        if (Input.GetAxisRaw("11th axis") > 0.3 || Input.GetAxisRaw("11th axis") < -0.3)
        {
            currentAxis = "11th axis";
            axis11 = Input.GetAxisRaw("11th axis");
        }

        if (Input.GetAxisRaw("12th axis") > 0.3 || Input.GetAxisRaw("12th axis") < -0.3)
        {
            currentAxis = "12th axis";
            axis12 = Input.GetAxisRaw("12th axis");
        }

        if (Input.GetAxisRaw("13th axis") > 0.3 || Input.GetAxisRaw("13th axis") < -0.3)
        {
            currentAxis = "13th axis";
            axis13 = Input.GetAxisRaw("13th axis");
        }

        if (Input.GetAxisRaw("14th axis") > 0.3 || Input.GetAxisRaw("14th axis") < -0.3)
        {
            currentAxis = "14th axis";
            axis14 = Input.GetAxisRaw("14th axis");
        }


        Vector3 direction = new Vector3(0,0,0);
        Vector3 look_direction = new Vector3(0, 0, 0);
        look_direction = new Vector3(axis4, 0, axis7);
            direction = transform.TransformDirection(Xaxis, 0, Yaxis);

        if (!controller.isGrounded)
        {//判断人物是否在地面上 
            direction.y -= 9.8f * 10 * Time.deltaTime;//不在地面上 
            //if (_vertSpeed < -10.0f)
            //{
            //    _vertSpeed = -10.0f;
            //}
        }
       
       // controller.Move(movement）
        if (direction != Vector3.zero)
        {
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(look_direction), Time.deltaTime * 10);
            // transform.Translate(direction * Time.deltaTime * 5);
            //getcomparen
            controller.Move(direction * Time.deltaTime * 10);
        }
    }




    /// <summary>
    /// show the data onGUI
    /// </summary>
    //void OnGUI()
    //{
    //    GUI.TextArea(new Rect(200, 0, 250, 50), "Current Button : " + currentButton);//使用GUI在屏幕上面实时打印当前按下的按键
    //    GUI.TextArea(new Rect(200, 50, 250, 50), "Current Axis : " + currentAxis);//使用GUI在屏幕上面实时打印当前按下的轴
    //    GUI.TextArea(new Rect(200, 100, 250, 50), "X Value : " + Xaxis);//使用GUI在屏幕上面实时打印当前按下的轴的量
    //    GUI.TextArea(new Rect(200, 150, 250, 50), "Y Value : " + Yaxis);//使用GUI在屏幕上面实时打印当前按下的轴的量
    //    GUI.TextArea(new Rect(200, 200, 250, 50), "3 : " + axis3);//使用GUI在屏幕上面实时打印当前按下的轴的量
    //    GUI.TextArea(new Rect(200, 250, 250, 50), "4 : " + axis4);//使用GUI在屏幕上面实时打印当前按下的轴的量
    //    GUI.TextArea(new Rect(200, 300, 250, 50), "5 : " + axis5);//使用GUI在屏幕上面实时打印当前按下的轴的量
    //    GUI.TextArea(new Rect(200, 350, 250, 50), "6 : " + axis6);//使用GUI在屏幕上面实时打印当前按下的轴的量 
    //    GUI.TextArea(new Rect(300, 0, 250, 50), "7 : " + axis7);//使用GUI在屏幕上面实时打印当前按下的轴的量
    //    GUI.TextArea(new Rect(300, 50, 250, 50), "8 : " + axis8);//使用GUI在屏幕上面实时打印当前按下的轴的量
    //    GUI.TextArea(new Rect(300, 100, 250, 50), "9 : " + axis9);//使用GUI在屏幕上面实时打印当前按下的轴的量 
    //    GUI.TextArea(new Rect(300, 150, 250, 50), "10 : " + axis10);//使用GUI在屏幕上面实时打印当前按下的轴的量
    //    GUI.TextArea(new Rect(300, 200, 250, 50), "11 : " + axis11);//使用GUI在屏幕上面实时打印当前按下的轴的量 GUI.TextArea(new Rect(100, 700, 250, 50), "6 : " + axis6);//使用GUI在屏幕上面实时打印当前按下的轴的量 
    //    GUI.TextArea(new Rect(300, 250, 250, 50), "12 : " + axis12);//使用GUI在屏幕上面实时打印当前按下的轴的量
    //    GUI.TextArea(new Rect(300, 300, 250, 50), "13 : " + axis13);//使用GUI在屏幕上面实时打印当前按下的轴的量
    //}

    public void Fire()
    {
        if (isfire)
        {
            Vector3 pos = GameObject.Find("rifleposition").transform.position;
            //pos.z += 2;
            if (rifleeffect == null)
            {
                
               rifleeffect = Instantiate(rifle, pos , transform.rotation);
            }
            rifleeffect.transform.position = pos;

            GameObject shootbullet =  Instantiate(bullet[0], pos, transform.rotation);
            shootbullet.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * 10000);
            //Debug.Log(rifleeffect.transform.position);
        }
        else
        {
            Destroy(rifleeffect);
        }
    }
}
