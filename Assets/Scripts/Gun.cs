using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Rigidbody ziDan;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Spawn Manager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive && Input.GetButtonDown("Fire1"))
        {
            //�����ĸ�������ʲôλ�ô�������ʲô�Ƕȴ���
            //���������λ�úͽǶ�

            Rigidbody ziDanFei = Instantiate(ziDan,this.transform.position,this.transform.rotation);
            //���÷���Ϊ��ǰ���ǰ��
            Vector3 fangXiang = this.transform.TransformDirection(Vector3.forward);

            //�ӷ���;���
            ziDanFei.AddForce(fangXiang * 2000);

        }
    }
}
