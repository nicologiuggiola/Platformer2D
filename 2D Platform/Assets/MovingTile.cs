using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTile : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public float speed;
    public bool isActive = false;

    public enum Phases
    {
        MOVINGUP,
        MOVINGDOWN,
        MOVINGDOWN2
    }

    public Phases phases;
    // Start is called before the first frame update
    void Start()
    {
        phases = Phases.MOVINGUP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        switch (phases)
        {
            case Phases.MOVINGUP:
                transform.position = Vector2.MoveTowards(transform.position, obj1.transform.position, speed * Time.deltaTime);
                if (transform.position == obj1.transform.position)
                {
                    phases = Phases.MOVINGDOWN;
                }
                break;
            case Phases.MOVINGDOWN:
                transform.position = Vector2.MoveTowards(transform.position, obj2.transform.position, speed * Time.deltaTime);
                if (transform.position == obj2.transform.position)
                {
                    phases = Phases.MOVINGUP;
                }
                else if (isActive)
                {
                    phases = Phases.MOVINGDOWN2;
                }
                break;
            case Phases.MOVINGDOWN2:
                transform.position = Vector2.MoveTowards(transform.position, obj3.transform.position, speed * Time.deltaTime);
                if (transform.position == obj3.transform.position)
                {
                    phases = Phases.MOVINGUP;
                }
                break;
        }
    }
}
