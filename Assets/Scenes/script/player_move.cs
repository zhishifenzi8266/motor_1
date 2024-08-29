using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;


public class player_move : MonoBehaviour
{
    private int d = 0;
    public float speed = 0.1f;
    public Vector2 vectormove;
    //public Regidbody body;
    //public float jump;
    //public Vector3 newPosotion;
    private Rigidbody rb;
    public float jump = 0.5f;
    public bool isdimian;
    public Collision pengzhuang; //碰撞检测2

    //private Rigidbody rb:

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("游戏开始");
        isdimian = true;
    }

    // Update is called once per frame
    void Update()
    {
        vectormove.x = Input.GetAxis("Horizontal");
        //vectormove.y = Input.GetAxis("Vertival");
        //Debug.Log("我不好");
        //测试testing

        if (Input.GetKeyDown(KeyCode.T))
        {
            d++;
            Debug.Log($"输出T{d}次");
        }

        //人物移动 《
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0.0f, 0f, speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, 0f, -speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed, 0f, 0f);
        }
        //人物移动 》

        //if(Input.GetKey(KeyCode.Space)) {
        //    Rigidbody.AddForce(0.0f, speed, 0.0f);

        //(检测是否是地面我的方法(碰撞检测1))Physics=物体 raycast=玩家下面生成一条线检测他的vector往下是否是1,5f 如果不是跳跃不了
        //isdimian = Physics.Raycast(transform.position, Vector3.down, 1.5f);


        //把isdimian函数绑定给jump
        if (Input.GetKeyDown(KeyCode.Space) && isdimian)
        {
            rb.AddForce(0f, jump, 0f, ForceMode.Impulse);
            isdimian = false;
        }

    }
    
    //碰撞检测2（老师的方法）
    private void OnCollisionEnter(Collision pengzhuan)
    {
        Debug.Log("我创到了：" +  pengzhuan.gameObject.tag + "!");

        if (pengzhuan.gameObject.CompareTag("dimian"))
        {
            isdimian = true;
        }
        if (pengzhuan.gameObject.CompareTag("KillZone"))
        {
            Debug.Log("KILL ME!!!");
        }
    }
}
