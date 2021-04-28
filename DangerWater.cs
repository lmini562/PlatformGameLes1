using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerWater : MonoBehaviour
{
    float timer = 0f;
    float timerHit = 0f;
    void Start()
    {

    }


    void Update() //обновление по кадрам в сек
    {
        timer += Time.deltaTime; //чтобы движение было плавным

        if (timer >= 0.5f) //если увеличить значения, то вода будет медленнее двигаться
        {
            timer = 0; //аннулируем таймер

            transform.localScale = new Vector3(-1f, 1f, 1f); //смена изображения 
        }
        else if (timer >= 0.25f) //ну и тут увеличить, хы
        {
            transform.localScale = new Vector3(1f, 1f, 1f); //смена изображения в другую сторону
        }
    }

    private void OnTriggerStay2D(Collider2D collision) //метод на чела
    {
        if (collision.gameObject.tag == "Player") //если объект столкновения имеет тэг чела
        {
            collision.GetComponent<Player>().inWater = true; //включаем анимку на плаванье
            timerHit += Time.deltaTime; //отсчет таймера на время в воде
            if(timerHit >= 2f) //если таймер нахождения чела в воде больше 2сек
            {
                collision.gameObject.GetComponent<Player>().RecountHP(-1); //отнимаем жизнь
                timerHit = 0; //аннулируем таймер
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //выход
    {
        if (collision.gameObject.tag == "Player") //если столкновение с челом
        {
            collision.GetComponent<Player>().inWater = false; //терь он не в воде
            timerHit = 0; //аннулируем таймер
        }
    }
}
