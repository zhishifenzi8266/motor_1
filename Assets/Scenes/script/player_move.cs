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
    public Collision pengzhuang; //��ײ���2
    public int bitcoin;
    public TMPro.TextMeshProUGUI    scoretext;
    public float moveSpeed; //����ͷ�������

    //private Rigidbody rb:

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("��Ϸ��ʼ");
        isdimian = true;
        moveSpeed = 600f; //����ͷ��������ƶ��ٶ�
    }

    // Update is called once per frame
    void Update()
    {
        vectormove.x = Input.GetAxis("Horizontal");
        //vectormove.y = Input.GetAxis("Vertival");
        //Debug.Log("�Ҳ���");
        //����testing

        if (Input.GetKeyDown(KeyCode.T))
        {
            d++;
            Debug.Log($"���T{d}��");
        }

        //�����ƶ�2.0��
        rb = this.GetComponent<Rigidbody>();

        float v = Input.GetAxis("Vertical");

        float h = Input.GetAxis("Horizontal");//�õ��������ҿ���

        rb.AddForce(new Vector3(h, 0, v) * force);//������ʩ����


        //��
        //�����ƶ� ��
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
        //�����ƶ� ��

        //if(Input.GetKey(KeyCode.Space)) {
        //    Rigidbody.AddForce(0.0f, speed, 0.0f);

        //(����Ƿ��ǵ����ҵķ���(��ײ���1))Physics=���� raycast=�����������һ���߼������vector�����Ƿ���1,5f ���������Ծ����
        //isdimian = Physics.Raycast(transform.position, Vector3.down, 1.5f);


        //��isdimian�����󶨸�jump
        if (Input.GetKeyDown(KeyCode.Space) && isdimian)
        {
            rb.AddForce(0f, jump, 0f, ForceMode.Impulse);
            isdimian = false;
        }
        //����ͷ�������ķ�����
        Vector3 angle = Vector3.zero;

        angle.x = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * moveSpeed * Time.deltaTime;
        angle.y = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * moveSpeed * Time.deltaTime;

        transform.localEulerAngles = angle;
        //����ͷ�������ķ�����

    }

    //��ײ���2����ʦ�ķ�����
    private void OnCollisionEnter(Collision pengzhuan)
    {
        Debug.Log("�Ҵ����ˣ�" +  pengzhuan.gameObject.tag + "!");

        if (pengzhuan.gameObject.CompareTag("dimian"))
        {
            isdimian = true;
        }
        //������ʱ����ص�ͼLoadScene(0)
        if (pengzhuan.gameObject.CompareTag("KillZone"))
        {
            Debug.Log("KILL ME!!!");
            SceneManager.LoadScene(0);
        }
        //Ӯ��ʱ����ص�ͼLoadScene(1)
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
