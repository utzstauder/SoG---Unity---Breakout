using UnityEngine;

public class AlexanderInput : MonoBehaviour, IPlayerInput
{
    public float Horizontal
    {
        get
        {
            return horizontal;
        }
    }

    public float Vertical
    {
        get
        {
            return vertical;
        }
    }

    private float horizontal;
    private float vertical;

    private int timer = 1;
    private float speed = 0.01f;


    void Start()
    {

    }

    void Update()
    {
        timer ++;
        speed += 0.0001f;

        if (timer%120 < 30)
        {
            horizontal = timer%30 * speed;
            vertical = (30 - timer % 30) * speed;
        }

        else if (timer%120 >= 30 && timer%120 < 60)
        {
            horizontal = (30 - timer % 30) * speed;
            vertical = -timer % 30 * speed;
        }

        else if (timer % 120 >= 60 && timer % 120 < 90)
        {
            horizontal = -timer % 30 * speed;
            vertical = -(30 - timer % 30) * speed;
        }

        else if (timer % 120 >= 90 && timer % 120 < 120)
        {
            horizontal = -(30 - timer % 30) * speed;
            vertical = timer % 30 * speed;
        }


    }
}
