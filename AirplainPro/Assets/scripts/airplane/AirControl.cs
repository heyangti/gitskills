using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirControl : MonoBehaviour {
    private Transform m_transform;
    public float speed = 600f;
    private float rotation = 0.0f;
    public float rotationSpeed_AxisZ = 45f;
    public float rotationSpeed_AxisY = 20f;
    private Vector2 touchPosition;
    private float screenWeight;

    void backToBlance()
    {
        //todo
    }

	// Use this for initialization
	void Start () {
        m_transform = this.transform;
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        screenWeight = Screen.width;
	}
	
	// Update is called once per frame
	void Update () {
        m_transform.Translate(new Vector3(0, 0, speed*Time.deltaTime));
        GameObject.Find("propeller").transform.Rotate(new Vector3(0, 10000f * Time.deltaTime, 0));

        //控制飞机的左右倾斜
        float rotationz = this.transform.eulerAngles.z;
        if (Input.touchCount > 0){
            for (int i = 0; i < Input.touchCount; i++)
            {
                //实例化
                Touch touch = Input.touches[i];
                if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                {
                    //获取当前触摸的位置
                    touchPosition = touch.position;
                    if (touchPosition.x < screenWeight / 2)
                    {
                        //飞机左转
                        //todo
                    }
                    else if (touchPosition.x >= screenWeight / 2)
                    {
                        //飞机右转
                        //todo
                    }
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    backToBlance();
                }
            }
        }
        if (Input.touchCount == 0){
            backToBlance();
        }
	}
}
