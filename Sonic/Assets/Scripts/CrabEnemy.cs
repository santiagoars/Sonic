using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabEnemy : MonoBehaviour
{

    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        target = new Vector2(-10,-3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, 2 * Time.deltaTime);
    }
}
