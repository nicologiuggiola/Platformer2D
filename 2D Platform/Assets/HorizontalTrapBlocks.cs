using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalTrapBlocks : MonoBehaviour
{
    public GameObject block1;
    public GameObject block2;
    public GameObject block3;
    public GameObject a;
    public GameObject b;
    public GameObject c;
    private float speed = 12;
    private bool isActivated = false;

    public enum Phases
    {
        SENDBLOCK1,
        SENDBLOCK2,
        SENDBLOCK3_STOP
    }

    public Phases phases;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated)
        {
            switch (phases)
            {
                case Phases.SENDBLOCK1:
                    block1.transform.position = Vector2.MoveTowards(block1.transform.position, a.transform.position, speed * Time.deltaTime);
                    if (block1.transform.position == a.transform.position)
                    {
                        phases = Phases.SENDBLOCK2;
                    }
                    break;
                case Phases.SENDBLOCK2:
                    block2.transform.position = Vector2.MoveTowards(block2.transform.position, b.transform.position, speed * Time.deltaTime);
                    if (block2.transform.position == b.transform.position)
                    {
                        phases = Phases.SENDBLOCK3_STOP;
                    }
                    break;
                case Phases.SENDBLOCK3_STOP:
                    block3.transform.position = Vector2.MoveTowards(block3.transform.position, c.transform.position, speed * Time.deltaTime);
                    if (block3.transform.position == c.transform.position)
                    {
                        Destroy(gameObject);
                    }
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isActivated = true;
        
    }
}
