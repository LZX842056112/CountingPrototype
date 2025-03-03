using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;
using UnityEngine.UIElements;
using System;


public class Counter : MonoBehaviour
{
    public Rigidbody ziDan;
    public float lookSpeed = 1f;  // 定义视角控制速度，可以在Unity编辑器中修改
    private float rotationX = 0f;  // 初始化水平旋转角度为0
    private float rotationY = 0f;  // 初始化垂直旋转角度为0
    public float rotation = 40f;  // 初始化垂直旋转角度为0

    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Spawn Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            // 视角控制
            rotationX += Input.GetAxis("Mouse X") * lookSpeed;  // 根据鼠标水平移动改变水平角度
            rotationY += Input.GetAxis("Mouse Y") * lookSpeed;  // 根据鼠标垂直移动改变垂直角度
            rotationX = Mathf.Clamp(rotationX, -rotation, rotation);
            rotationY = Mathf.Clamp(rotationY, -rotation, rotation);  // 限制垂直角度在 -90 度到 90 度之间

            transform.localRotation = Quaternion.Euler(-rotationY, rotationX, 0f);  // 根据水平和垂直角度旋转物体的局部坐标系

            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 10f, 100f);  // 根据输入改变相机的视野大小，并限制在10到100的范围内
        }
    }
}
