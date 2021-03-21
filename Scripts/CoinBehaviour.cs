using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    // Активация триггера при попадании в него объекта
  void OnTriggerEnter2D(Collider2D collision) {
    /**
    * Проверяем, тэг объекта, активировавшего триггер
    * Если его тэг "Player", то условия выполнено
    **/
    if (collision.gameObject.tag == "Player") {
      // Уничтожаем наш объект
      Destroy(gameObject);
    }   
  }
    
}
