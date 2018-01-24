using UnityEngine;

public class PowerUpBallSpeed : PowerUp {

    public float deltaSpeed = 2f;

    public override void Trigger()
    {
        base.Trigger();

        // find BallContainer object reference
        BallContainer ballContainer = FindObjectOfType<BallContainer>();

        if (ballContainer != null)
        {
            // change speed
            ballContainer.ChangeBallSpeed(deltaSpeed);
        }
    }
}
