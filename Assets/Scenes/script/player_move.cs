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
    private Rigidbody rb;
    public float jump = 0.5f; // 跳跃高度
    public bool isdimian; // 检测地面碰撞是否可以跳跃
    public int bitcoin;
    public TMPro.TextMeshProUGUI scoretext; // 显示分数
    public TMPro.TextMeshProUGUI warning; // 终点提示
    public float moveSpeed; // 摄像头跟踪鼠标

    // Start is called before the first frame update
    void Start()
    {
        warning.enabled = false;
        rb = GetComponent<Rigidbody>();
        Debug.Log("游戏开始");
        isdimian = true;
        moveSpeed = 600f; // 摄像头跟踪鼠标移动速度
    }

    // Update is called once per frame
    void Update()
    {
        vectormove.x = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.T))
        {
            d++;
            Debug.Log($"输出T{d}次");
        }

        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        rb.AddForce(new Vector3(h, 0, v) * force);

        if (Input.GetKeyDown(KeyCode.Space) && isdimian)
        {
            rb.AddForce(0f, jump, 0f, ForceMode.Impulse);
            isdimian = false;
        }

        Vector3 angle = Vector3.zero;
        angle.x = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * moveSpeed * Time.deltaTime;
        angle.y = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * moveSpeed * Time.deltaTime;
        transform.localEulerAngles = angle;
    }

    private void OnCollisionEnter(Collision pengzhuan)
    {
        Debug.Log("我创到了：" + pengzhuan.gameObject.tag + "!");

        if (pengzhuan.gameObject.CompareTag("dimian"))
        {
            isdimian = true;
        }
        if (pengzhuan.gameObject.CompareTag("KillZone"))
        {
            Debug.Log("KILL ME!!!");
            SceneManager.LoadScene(0);
        }
    }

    void OnTriggerEnter(Collider pengzhuan2)
    {
        Debug.Log("我创到了：" + pengzhuan2.gameObject.tag + "!");
        if (pengzhuan2.gameObject.CompareTag("bitcoin"))
        {
            Destroy(pengzhuan2.gameObject);
            bitcoin++;
            scoretext.text = bitcoin.ToString();
        }
        if (pengzhuan2.gameObject.CompareTag("win"))
        {
            warning.enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("我正在呆在：" + other.gameObject.tag + "!");
    }

}
