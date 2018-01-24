using UnityEngine;

public class BrickHealth : Brick {
    public int maxHp = 2;

    int currentHp;

    private void Start()
    {
        currentHp = maxHp;
    }

    protected override void Hit()
    {
        // base.Hit();

        currentHp--;

        if (currentHp <= 0)
        {
            Die();
        }
    }
}
