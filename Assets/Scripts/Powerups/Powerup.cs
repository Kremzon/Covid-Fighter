using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] PowerupTypes poweupType;

    Vector2 minBounds;

    void Start()
    {
        var mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += new Vector3(0, -moveSpeed * Time.deltaTime);

        if (transform.position.y < minBounds.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PowerupPicker powerupPicker = collision.GetComponent<PowerupPicker>();

        if (powerupPicker != null)
        {
            powerupPicker.Pickup(poweupType);
            Destroy(gameObject);
        }
    }
}
