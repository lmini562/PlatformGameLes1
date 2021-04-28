using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    float TimeToDisable = 10f;
    float speed = 3f;
    
    void Start() //при старте
    {
        StartCoroutine(SetDisabled()); //запуск карутины на удаление пули
    }

    
    void Update() //на каждом кадре
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime); //движение снарядов в низ со скоростью и плавно
    }

    IEnumerator SetDisabled() //карутина
    {
        yield return new WaitForSeconds(TimeToDisable); //ждем сек
        gameObject.SetActive(false); //удаляем объект
    }

    private void OnCollisionEnter2D(Collision2D collision) //метод на объекте
    {
        StopCoroutine(SetDisabled()); //удаляем объект
        gameObject.SetActive(false); //изменяем значение
    }
}
