using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.Member;
using UnityEngine.UI;


public class player_move : MonoBehaviour
{
    private int d = 0;
    public int force = 3;
    public Vector2 vectormove;
    //public Regidbody body;
    //public float jump;
    //public Vector3 newPosotion;
    private Rigidbody rb;
    public float jump = 0.5f;
    public bool isdimian;
    public Collision pengzhuang; //碰撞检测2
    public int bitcoin;
    public TMPro.TextMeshProUGUI    scoretext;
    public float moveSpeed; //摄像头跟踪鼠标

    //private Rigidbody rb:

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("游戏开始");
        isdimian = true;
        moveSpeed = 600f; //摄像头跟踪鼠标移动速度
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

        //人物移动2.0《
        rb = this.GetComponent<Rigidbody>();

        float v = Input.GetAxis("Vertical");

        float h = Input.GetAxis("Horizontal");//得到键盘左右控制

        rb.AddForce(new Vector3(h, 0, v) * force);//对物体施加力


        //》
        //人物移动 《
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.Translate(0.0f, 0f, speed);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Translate(-speed, 0f, 0f);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.Translate(0f, 0f, -speed);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Translate(speed, 0f, 0f);
        //}
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
        //摄像头跟踪鼠标的方法《
        Vector3 angle = Vector3.zero;

        angle.x = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * moveSpeed * Time.deltaTime;
        angle.y = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * moveSpeed * Time.deltaTime;

        transform.localEulerAngles = angle;
        //摄像头跟踪鼠标的方法》

    }

    //碰撞检测2（老师的方法）
    private void OnCollisionEnter(Collision pengzhuan)
    {
        Debug.Log("我创到了：" +  pengzhuan.gameObject.tag + "!");

        if (pengzhuan.gameObject.CompareTag("dimian"))
        {
            isdimian = true;
        }
        //死亡的时候加载地图LoadScene(0)
        if (pengzhuan.gameObject.CompareTag("KillZone"))
        {
            Debug.Log("KILL ME!!!");
            SceneManager.LoadScene(0);
        }
        //赢的时候加载地图LoadScene(1)
        if (pengzhuan.gameObject.CompareTag("win"))
        {
            SceneManager.LoadScene(2);
        }
        if (pengzhuan.gameObject.CompareTag("bitcoin"))
        {
            Destroy(pengzhuan.gameObject);
            bitcoin++;
            scoretext.text = bitcoin.ToString();
        }
    }
}
