using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float paddingRight = 0.5f;
    [SerializeField] float paddingLeft = 0.5f;
    [SerializeField] float paddingUp = 5f;
    [SerializeField] float paddingDown = 2f;

    Vector2 playerInput;
    Vector2 minBounds;
    Vector2 maxBounds;
    Shooter shooter;

    private void Awake()
    {
        shooter = GetComponent<Shooter>();
    }

    private void Start()
    {
        InitBounds();
    }

    void Update()
    {
        Move();
    }

    private void InitBounds()
    {
        var mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    private void Move()
    {
        Vector3 positionDelta = playerInput * moveSpeed * Time.deltaTime;
        Vector2 newPosition = new Vector2(Mathf.Clamp(transform.position.x + positionDelta.x, minBounds.x + paddingRight, maxBounds.x - paddingLeft),
                                          Mathf.Clamp(transform.position.y + positionDelta.y, minBounds.y + paddingDown, maxBounds.y - paddingUp));
        transform.position = newPosition;
    }

    void OnMove(InputValue inputValue)
    {
        playerInput = inputValue.Get<Vector2>();
    }

    void OnFire(InputValue inputValue)
    {
        shooter.isFiring = inputValue.isPressed;
    }
}
