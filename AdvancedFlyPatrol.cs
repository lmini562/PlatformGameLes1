using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedFlyPatrol : MonoBehaviour
{
    public Transform[] points;

    public float speed = 2f;
    public float WaitTime = 3f;

    int i = 1;

    bool CanGo = true;
    void Start() //при старте игры
    {
        gameObject.transform.position = new Vector3(points[0].position.x, points[0].position.y, transform.position.z); //позиция у точек 0
        transform.eulerAngles = new Vector3(0, transform.rotation.y + 180, 0); //изображение повернуто в одну сторону
    }


    void Update() //по кадрам
    {
        if (CanGo) //если может идти
        {

            transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime); //тек.пол/куда двигаться/скорость //двигаемся к 1 точке

            if (transform.position == points[i].position) //если дошел до точки
            {
                //меняем точки местами
                if (i < points.Length - 1) //или отнимаем
                {
                    i++;
                }
                else //или аннулируем
                {
                    i = 0;
                }

                CanGo = false; //меняем значение на ложное

                StartCoroutine(Waiting()); //запуск карутины на задержку

            }

        }
    }

    IEnumerator Waiting() //карутина на задержку
    {
        yield return new WaitForSeconds(WaitTime); //ждем секунду  для красоты ля
        CanGo = true; //теперь можем внова жвигаться
    }
}
