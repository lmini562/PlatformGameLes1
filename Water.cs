using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    float timer = 0f;
    void Start()
    {
        
    }

    
    void Update()
    {
        timer += Time.deltaTime; //для плавности

        if(timer >= 1f) //если увеличить значения, то вода будет медленнее двигаться
        {
            timer = 0; //таймер на 0

            transform.localScale = new Vector3(-1f, 1f, 1f); //изображение одно
        }
        else if (timer >= 0.5f) //ну и тут увеличить, хы
        {
            transform.localScale = new Vector3(1f, 1f, 1f); //переворачиваем изображение
        }
    }

    private void OnTriggerStay2D(Collider2D collision) //коллайдер на нахождение в воде
    {
        if (collision.gameObject.tag == "Player") //если объект столкновения чел
        {
            collision.GetComponent<Player>().inWater = true; //то он в воде епта
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //коллайдер на выход из воды
    {
        if (collision.gameObject.tag == "Player") //если объект столкновения чел
        {
            collision.GetComponent<Player>().inWater = false; //терь он не в воде епта
        }
    }
}
