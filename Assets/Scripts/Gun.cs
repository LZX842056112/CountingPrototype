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
            //创建哪个对象，在什么位置创建，以什么角度创建
            //创造在相机位置和角度

            Rigidbody ziDanFei = Instantiate(ziDan,this.transform.position,this.transform.rotation);
            //设置方向为当前相机前方
            Vector3 fangXiang = this.transform.TransformDirection(Vector3.forward);

            //加方向和距离
            ziDanFei.AddForce(fangXiang * 2000);

        }
    }
}
