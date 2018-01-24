using UnityEngine;

public class PowerUpBallMultiplier : PowerUp {

    // override base class function
    public override void Trigger()
    {
        base.Trigger();
        // Debug.Log("BallMultiplier");

        // find BallContainer object reference
        BallContainer ballContainer = FindObjectOfType<BallContainer>();

        if (ballContainer != null)
        {
            // multiply balls
            ballContainer.MultiplyBalls(2);
        }
    }

}
