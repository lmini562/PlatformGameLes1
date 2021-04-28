using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beatle : MonoBehaviour
{
    public float speed = 4f; //скорость прыжка
    public float waitTime = 4f; //время ожидания

    public Transform point; //куда выпригивает-скрывается

    bool isWait = false;
    bool isHidden = false;
   
    void Start() //при старте игры
    {
        point.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z); //задаем начальное положение
    }

    
    void Update()
    {
        if(isWait == false) //если он не ждет
        {
            transform.position = Vector3.MoveTowards(transform.position, point.position, speed * Time.deltaTime);  //идем под землю

        }
        if(transform.position == point.position) //если его положение у точки
        {
            if(isHidden) //если скрыт
            {
                point.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z); //выходим наружу
                isHidden = false; //меняем значение на другое
            }
            else //если снаружи
            {
                point.transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z); //уходим под землю
                isHidden = true; //меняем значение
            }

            isWait = true; //меняем значение на правду

            StartCoroutine(Waiting()); //запуск карутины на ожидание
        }
    }

    IEnumerator Waiting() //сама карутина на ожидание
    {
        yield return new WaitForSeconds(waitTime); //ждем секунду 
        isWait = false; //делаем ожидание ложным, чобы дальше двигаться гы
    }
}
