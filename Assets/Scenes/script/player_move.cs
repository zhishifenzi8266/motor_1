using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;


public class player_move : MonoBehaviour
{
    private int d = 0;
    public float speed = 0.1f;
    //public Vector2 vector;
    //public Regidbody body;
    //public float jump;
    //public Vector3 newPosotion;
    private Rigidbody rb;
    public float jump = 0.5f;
    private bool isdimian;

    //private Rigidbody rb:

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("��Ϸ��ʼ");
    }

    // Update is called once per frame
    void Update()
    {
        //vector.x = Input.GetAxis("Horizontal");
        //vector.y = Input.GetAxis("Vertival");
        //Debug.Log("�Ҳ���");
        //����testing
        if (Input.GetKeyDown(KeyCode.T))
        {
            d++;
            Debug.Log($"���T{d}��");
        }

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
        //if(Input.GetKey(KeyCode.Space)) {
        //    Rigidbody.AddForce(0.0f, speed, 0.0f);

        //Physics=���� raycast=�����������һ���߼������vector�����Ƿ���1,5f ���������Ծ����
        isdimian = Physics.Raycast(transform.position, Vector3.down, 1.5f);
        

        //��isdimian�����󶨸�jump
        if (Input.GetKeyDown(KeyCode.Space) && isdimian)
        {
            rb.AddForce(0f, jump, 0f, ForceMode.Impulse);

        }


    }
}
