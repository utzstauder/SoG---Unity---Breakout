using UnityEngine;

public class PowerUp : MonoBehaviour {

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    public virtual void Trigger()
    {
        Debug.LogFormat("PowerUp {0} triggered!", gameObject.name);
    }
}
