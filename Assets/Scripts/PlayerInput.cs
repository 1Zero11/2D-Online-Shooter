using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Player player;
    public bool inited;
    public float[] borders; // up down right left

    private void Start()
    {
        player = GetComponent<Player>();
    }
    void Update()
    {
        if (inited)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            if (transform.position.y > borders[0])
            {
                v = Mathf.Min(v, 0);
            }else if (transform.position.y < borders[1])
            {
                v = Mathf.Max(v, 0);
            }

            if (transform.position.x > borders[2])
            {
                h = Mathf.Min(h, 0);
            }
            else if (transform.position.x < borders[3])
            {
                h = Mathf.Max(h, 0);
            }

            float speed = 5f * Time.deltaTime;
            transform.Translate(new Vector2(h * speed, v * speed));

            if (Input.GetKeyDown(KeyCode.H))
            {
                player.ChangeHealthValue(player.Health - 1);
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Vector3 pos = Input.mousePosition;
                pos.z = 10f;
                pos = Camera.main.ScreenToWorldPoint(pos);

                player.SpawnBullet(pos);
            }
        }

    }

    public void Init()
    {
        inited = true;
        Debug.Log("Player Inited");
    }
}
