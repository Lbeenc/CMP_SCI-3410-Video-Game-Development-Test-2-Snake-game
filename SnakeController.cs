// Author: Curtis Been
// Date: 2025-05-18
// Controls snake movement and collision

using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public Transform bodyPrefab;         // Prefab for snake segments (cube)
    public GameObject applePrefab;       // Prefab for apple (sphere)
    public float moveRate = 0.2f;        // Time between snake moves

    private List<Transform> bodyParts = new List<Transform>();
    private Vector3 direction = Vector3.forward;
    private float timer = 0f;
    private int growAmount = 0;

    private void Start()
    {
        // Spawn initial snake body (5 units long) in vertical stack
        for (int i = 0; i < 5; i++)
        {
            Vector3 pos = new Vector3(0, 1, 0 - i); // Start at center of grid
            Transform segment = Instantiate(bodyPrefab, pos, Quaternion.identity);
            bodyParts.Add(segment);
        }

        SpawnApple();
    }

    private void Update()
    {
        HandleInput(); // Detect arrow key input
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer >= moveRate)
        {
            timer = 0f;
            Move();
        }
    }

    private void HandleInput()
    {
        // Prevent 180-degree turns
        if (Input.GetKeyDown(KeyCode.UpArrow) && direction != Vector3.back)
            direction = Vector3.forward;
        else if (Input.GetKeyDown(KeyCode.DownArrow) && direction != Vector3.forward)
            direction = Vector3.back;
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && direction != Vector3.right)
            direction = Vector3.left;
        else if (Input.GetKeyDown(KeyCode.RightArrow) && direction != Vector3.left)
            direction = Vector3.right;
    }

    private void Move()
    {
        Vector3 nextPos = bodyParts[0].position + direction;

        // Check wall or self collision (ignore Apple tag)
        Collider[] collisions = Physics.OverlapBox(nextPos, Vector3.one * 0.45f);
        foreach (var col in collisions)
        {
            if (!col.CompareTag("Apple"))
            {
                GameManager.Instance.GameOver();
                return;
            }
        }

        // Shift all body parts forward
        for (int i = bodyParts.Count - 1; i > 0; i--)
        {
            bodyParts[i].position = bodyParts[i - 1].position;
        }

        // Move head last
        bodyParts[0].position = nextPos;

        // Check for apple collision
        Collider[] hits = Physics.OverlapSphere(nextPos, 0.4f);
        foreach (var hit in hits)
        {
            if (hit.CompareTag("Apple"))
            {
                Destroy(hit.gameObject);
                growAmount += 3; // Grow by 3 units
                GameManager.Instance.AddScore();
                SpawnApple();
            }
        }

        // Grow if needed
        if (growAmount > 0)
        {
            AddBodyPart();
            growAmount--;
        }
    }

    private void AddBodyPart()
    {
        // Add new segment at tail's position
        Vector3 spawnPos = bodyParts[bodyParts.Count - 1].position;
        Transform segment = Instantiate(bodyPrefab, spawnPos, Quaternion.identity);
        bodyParts.Add(segment);
    }

    private void SpawnApple()
    {
        Vector3 newPos;
        bool valid = false;

        while (!valid)
        {
            int x = Random.Range(-9, 9);  // excludes 9
            int z = Random.Range(-9, 9);  // excludes 9
            newPos = new Vector3(x, 1, z);

            // far from head and not on the snake
            if (Vector3.Distance(bodyParts[0].position, newPos) >= 5f)
            {
                bool isOccupied = false;

                foreach (Transform part in bodyParts)
                {
                    if (part.position == newPos)
                    {
                        isOccupied = true;
                        break;
                    }
                }

                if (!isOccupied)
                {
                    Instantiate(applePrefab, newPos, Quaternion.identity);
                    valid = true;
                }
            }
        }
    }
}
