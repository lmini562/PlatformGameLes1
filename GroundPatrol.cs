using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPatrol : MonoBehaviour
{
    public float speed = 0.5f; //скорость

    public bool moveLeft = true; //движение

    public Transform groundDetect; //переменная для точки
 
    void Start()
    {
        
    }


    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime); //движение влево

        RaycastHit2D GroundInfo = Physics2D.Raycast(groundDetect.position, Vector2.down, 1f); //движение

        if (GroundInfo.collider == false) //колайдер для луча вниз платформы для поворотов
        {
            if(moveLeft == true) //идем влево, земля заканчивается -> разворот
            {
                transform.eulerAngles = new Vector3(0,180,0); //поворот вправо
                moveLeft = false;
            }

            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0); //поворот влево
                moveLeft = true;
            }
        }
    }
}
