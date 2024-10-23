using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.Member;
using UnityEngine.UI;


public class PlayerMove : MonoBehaviour
{
    private int d = 0;
    public int force = 3;
    public Vector2 vectormove;
    private Rigidbody rb;
    public float jump = 0.5f; // ��Ծ�߶�
    public bool isdimian; // ��������ײ�Ƿ������Ծ
    public int bitcoin;
    public TMPro.TextMeshProUGUI scoretext; // ��ʾ����
    public TMPro.TextMeshProUGUI warning; // �յ���ʾ
    public float moveSpeed = 600f; // ����ͷ�������

    void Start()
    {
        warning.enabled = false;
        rb = GetComponent<Rigidbody>();
        Debug.Log("��Ϸ��ʼ");
        isdimian = true;
    }

    void Update()
    {
        vectormove.x = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.T))
        {
            d++;
            Debug.Log($"���T{d}��");
        }

        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        rb.AddForce(new Vector3(h, 0, v) * force);

        if (Input.GetKeyDown(KeyCode.Space) && isdimian)
        {
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            isdimian = false;
        }

        Vector3 angle = transform.localEulerAngles;
        angle.x -= Input.GetAxis("Mouse Y") * moveSpeed * Time.deltaTime;
        angle.y += Input.GetAxis("Mouse X") * moveSpeed * Time.deltaTime;
        transform.localEulerAngles = angle;
    }

    private void OnCollisionEnter(Collision pengzhuan)
    {
        Debug.Log("�Ҵ����ˣ�" + pengzhuan.gameObject.tag + "!");

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

    private void OnTriggerEnter(Collider pengzhuan2)
    {
        Debug.Log("�Ҵ����ˣ�" + pengzhuan2.gameObject.tag + "!");
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
}
