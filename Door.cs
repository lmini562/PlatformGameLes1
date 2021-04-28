using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;

    public Transform door;

    public Sprite mid, top;
    void Start()
    {
        
    }

 
    void Update()
    {
        
    }

    public void Unlock() //метод на разблокировку двери
    {
        isOpen = true; //терь открыта 

        GetComponent<SpriteRenderer>().sprite = mid; //меняем кусок двери на другой рисунок

        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = top; //тут тоже меняем, тока верхнюю часть
    }

    public void Teleport (GameObject player) //метод на телепорт
    {
        player.transform.position = new Vector3(door.position.x, door.position.y, player.transform.position.z); //блокаем позицию z и тпшимся
    }
}
