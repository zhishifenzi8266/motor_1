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
    public Collision pengzhuang; //��ײ���2

    //private Rigidbody rb:

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("��Ϸ��ʼ");
        isdimian = true;
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

        //�����ƶ� ��
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

    }
    
    //��ײ���2����ʦ�ķ�����
    private void OnCollisionEnter(Collision pengzhuan)
    {
        Debug.Log("�Ҵ����ˣ�" +  pengzhuan.gameObject.tag + "!");

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
