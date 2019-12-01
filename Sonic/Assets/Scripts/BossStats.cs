using System.Collections;
using System.Collections.Generic;

public class BossStats
{
    public bool canThrow = false;
    public int health = 6; 
    public float jumpHeight = 10.0f,
                 movSpeed = 5.0f,
                 stunTime = 1.5f;

    public BossStats(int h, float j, float m, float s, bool c)
    {
        this.health = h;
        this.jumpHeight = j;
        this.movSpeed = m;
        this.stunTime = s;
        this.canThrow = c;
    } 

}
