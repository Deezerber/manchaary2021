using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {
    /**
    ** Ускорение игрока
    **/
  [Header("Player velocity")]
    // Ось Ox
    public int xVelocity = 5;
    // Ось Oy
    public int yVelocity = 8;

  [SerializeField] private LayerMask ground;

    // Физическое поведение (тело) объекта
    private Rigidbody2D rigidBody;
    // Коллайдер, проверка на столкновения
    private Collider2D coll;

    public Joystick Joystick;

    private void Start() {
      // Получаем доступ к Rigidbody2D объекта Player
      rigidBody = gameObject.GetComponent<Rigidbody2D>();
      coll = gameObject.GetComponent<Collider2D>();
    }

    private void Update() {
      updatePlayerPosition();
    }

    // Обновляем местоположение игрока
    private void updatePlayerPosition() {
      // Получаем значение ввода горизонтального перемещение
      float moveInput = Joystick.Horizontal;
      // Получаем значение ввода прыжка
      float jumpInput = Input.GetAxis("Jump");

      // Значения xVelocity, yVelocity можно задать через инспектор

      if (moveInput < 0) { // Движ влево
        rigidBody.velocity = new Vector2(-xVelocity, rigidBody.velocity.y);
      } else if (moveInput > 0) { // Движ вправо
        rigidBody.velocity = new Vector2(xVelocity, rigidBody.velocity.y);
      } else if (coll.IsTouchingLayers(ground)) {
        rigidBody.velocity = Vector2.zero; // Лично меня дико бесит инерция вбок при приземлении персонажа, отключаем
      }

      if (jumpInput > 0 && coll.IsTouchingLayers(ground)) { //Тип прыгает, если стоит на земле
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, yVelocity);
      }
    }
}