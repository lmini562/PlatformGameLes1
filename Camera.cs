using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    float speed = 3f; //скорость

    public Transform target; //цель за которой следует камера

    void Start() //1раз
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z); //изменения перемещений камеры
    }

    void Update()//постоянно
    {
        Vector3 position = target.position; //опредделяем цель 

        position.z = transform.position.z; //слой за камерой или z

        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime); //то как мы следуем, за чем следуем, с какой скоростью
    }
}
