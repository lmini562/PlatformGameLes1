using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    public GameObject bullet;

    public Transform shoot;

    public float timeShoot = 4f;
   
    void Start() //при старте
    {
        shoot.transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z); //задаем позиции
        StartCoroutine(Shooting()); //начинаем карутину
    }


    void Update()
    {
        
    }

    IEnumerator Shooting() //карутина
    {
        yield return new WaitForSeconds(timeShoot); //ждем сек
        Instantiate(bullet, shoot.transform.position, transform.rotation); //создаем объект

        StartCoroutine(Shooting()); //запуск карутины на стреляние
    }
}
