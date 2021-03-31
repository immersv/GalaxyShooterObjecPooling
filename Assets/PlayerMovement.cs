using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public Slider healthBar;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            healthBar.value -= 0.1f;
            if (healthBar.value <= 0)
            {
                Destroy(healthBar.gameObject, 1.0f);
                Destroy(gameObject, 1.0f);
            }
        }
    }

    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bulletObj = ObjectPool.singleTon.GetSpawnObj("Bullet");
            if (bulletObj != null)
            {
                bulletObj.transform.position = this.transform.position;
                bulletObj.SetActive(true);
            }
        }

        Vector3 sliderPos = Camera.main.WorldToScreenPoint(this.transform.position);
        healthBar.transform.position = sliderPos+new Vector3(0,-250.0f,0);
    }
}