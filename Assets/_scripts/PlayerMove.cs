using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{

    void Update()
    {
        float x = Input.GetAxis("Horizontal") * .1f;
        float z = Input.GetAxis("Vertical") * .1f;

        transform.Translate(x, 0, z);
    }

}
