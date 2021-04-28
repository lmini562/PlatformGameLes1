using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) //метод на объекте
    {
        if(collision.gameObject.tag == "Player") //если объект столкновения игрок
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 8f, ForceMode2D.Impulse); //задаем толчок
            gameObject.GetComponentInParent<Enemy>().startDeath(); //обращаемся к главному объекту и начинаем умирать
        }
    }
}
