using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public Text text;
    public Slider slider;
    public int health = 5;

    private void Update() {
        // 채력이 1보다 적으면 죽게 만들기
        if(health < 1) {
            gameObject.SetActive(false);
            slider.gameObject.SetActive(false);
            text.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // 총알에 닿았다면 채력을 1깎고 총알을 없애기
        health--;
        slider.value--;
        Destroy(other.gameObject);
    }
}
