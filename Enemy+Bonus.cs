using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    bool isHit = false;

    public GameObject drop;

    private void OnCollisionEnter2D(Collision2D collision) //в начале столкновения
    {
        if (collision.gameObject.tag == "Player" && !isHit) //объект столкновения = player ОБЯЗАТЕЛЬНО
        {
            collision.gameObject.GetComponent<Player>().RecountHP(-1); //уменьшаем хп на 1 
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 8f , ForceMode2D.Impulse); //типа отталкиваемся от того, что нас коцает
        }
    }

    public IEnumerator Death() //карутина на смЭрт
    {
        if(drop != null) //если дроп не пуст(есть объект)
        {
            Instantiate(drop, transform.position, Quaternion.identity); //он появляется на сцене
        }
        isHit = true; //мы ранимся
        GetComponent<Animator>().SetBool("dead", true); //делаем смерть правдой
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic; //делаем тело динамическим
        GetComponent<Collider2D>().enabled = false; //выключаем коллайдер
        transform.GetChild(1).GetComponent<Collider2D>().enabled = false; //1 располодение ребенка у объекта сверху в низ от 0 и тд

        yield return new WaitForSeconds(2f); //ждем 2 сек

        Destroy(gameObject); //удаляем объект
    }

    public void startDeath() //метод на смерть
    {
        StartCoroutine(Death()); //запуск карутины
    }
}    
