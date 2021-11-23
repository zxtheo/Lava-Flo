using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchController : MonoBehaviour
{
    public float punchSpeed;
    Rigidbody2D punchRB;
    public float aliveTime;
    // Start is called before the first frame update
    private void Awake()
    {
        punchRB = GetComponent<Rigidbody2D>();
        if (transform.rotation.z > 0)
        {
            punchRB.AddForce(new Vector2(-1, 0) * punchSpeed, ForceMode2D.Impulse);
        }
        else
        {
            punchRB.AddForce(new Vector2(1, 0) * punchSpeed, ForceMode2D.Impulse);
        }

        Destroy(gameObject, aliveTime);
    }

    public void RemoveForce()
    {
        punchRB.velocity = new Vector2(0, 0);
    }


}
