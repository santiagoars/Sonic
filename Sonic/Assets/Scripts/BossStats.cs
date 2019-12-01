using System.Collections;
using System.Collections.Generic;

public class BossStats
{
    public bool canThrow;
    public int health; 
    public float jumpHeight,
                 movSpeed,
                 stunTime,
                 attackWait;

    public BossStats(int h, float j, float m, float s, float a, bool c)
    {
        this.health = h;
        this.jumpHeight = j;
        this.movSpeed = m;
        this.stunTime = s;
        this.attackWait = a;
        this.canThrow = c;
    } 

}
