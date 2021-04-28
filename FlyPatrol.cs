using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPatrol : MonoBehaviour
{
    public Transform point1;
    public Transform point2;

    public float speed = 2f;
    public float waitTime = 3f; //для карутины

    bool CanGo = true;
  
    void Start()
    {
        gameObject.transform.position = new Vector3(point1.position.x, point1.position.y, transform.position.z);   //задаем начальное положение
    }

    
    void Update()
    {
        if (CanGo) //если может лететь
        
            transform.position = Vector3.MoveTowards(transform.position, point1.position, speed * Time.deltaTime); //тек.пол/куда двигаться/скорость //двигаемся к 1 точке

            if (transform.position == point1.position) //если долетел
            {
                //меняем точки местами
                Transform temp = point1;
                point1 = point2;
                point2 = temp;

                CanGo = false; //меняем значение

                StartCoroutine(Waiting()); //запуск карутины на задержку

            }
        
    }

    IEnumerator Waiting() //карутина на задержку
    {
        yield return new WaitForSeconds(waitTime); //ждем 1 сек
        if (transform.rotation.y == 0) //если мы на 0
        {
            transform.eulerAngles = new Vector3(0, transform.rotation.y + 180, 0); //меняем наш рисунок на отзеркаленный
        }
        else //иначе
        {
            transform.eulerAngles = new Vector3(0, transform.rotation.y, 0);//переворачиваемя на другую сторону
        }
        CanGo = true; //терь можем снова лететь
    }
}
