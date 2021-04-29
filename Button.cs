using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn : MonoBehaviour
{
    public GameObject[] block; //массив на эл-ты, которые будут исчезать при нажатии кнопки
    public Sprite btnDown; //спрайт кнопки, когда она вкл
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) //метод 
    {
        if(collision.gameObject.tag == "MarkBox") //если объект столкновения коробка
        {
            GetComponent<SpriteRenderer>().sprite = btnDown; //присваиваем новый спрайт
            GetComponent<EdgeCollider2D>().enabled = false; //выключаем коллайдер, когда кнопка вкл
            foreach (GameObject obj in block) //цикл для каждого объекта ля удаления, после вкл кнопки
            {
                Destroy(obj); //удаляем
            }
        }
    }
}
