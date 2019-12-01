using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int stage;
    public GameObject player;
    public BossStats[] phases;

    // Start is called before the first frame update
    void Start()
    {
        this.stage = 0;

        //Estadisticas fase 1
        phases[0] = new BossStats(15, 5.0f, 10.0f, 2.0f, true);

        //Estadisticas fase 2
        phases[1] = new BossStats(3, 25.0f, 30.0f, 1.0f, false);

        //Estadisticas fase 3
        phases[2] = new BossStats(10, 10.0f, 15.0f, 3.0f, true);

    }

    IEnumerator bossAI()
    {
        yield return new WaitForSeconds(this.phases[stage].attackWait);
        float dist = Vector3.Distance(transform.position, this.player.transform.position);
        int attack = (int) Random.Range(0.0f, 3.0f);

    }


    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator damage()
    {
        this.phases[stage].health--;
        if(this.phases[stage].health == 0)
        {
            this.stage++;

            // Aquí iría script si se necesita cambiar la animación




            yield return new WaitForSeconds(this.phases[stage].stunTime * 2);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            damage();
        }
    }
}
