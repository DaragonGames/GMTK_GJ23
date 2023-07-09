using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour
{
    public static List<Hunter> hunters = new List<Hunter>();
    private AudioSource audioSource;

    // The Hunters Attributes
    private float criticalShootRange = 15f;
    private float movementSpeed = 4;
    private float timeBetweenActions = 5f;
    public int patience = 100;

    // Event Variables
    private float actionTimer = 3f;
    private bool moving = false;
    private Vector3 movementGoal;
    private Vector3 campCordinates;
    public GameObject trap;
    private float traps = 1f;
    private float tracking = 15f;

    // Start is called before the first frame update
    void Start()
    {
        hunters.Add(this);
        audioSource = GetComponent<AudioSource>();
        campCordinates = transform.position;
        EventManager.DestructionOfPropertyAction += LosePatience;
    }

    void OnDestroy()
    {
        EventManager.DestructionOfPropertyAction -= LosePatience;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            Vector3 direction = (movementGoal - transform.position);
            transform.position += direction.normalized * Time.deltaTime * movementSpeed;
            if (direction.magnitude < 1)
            {
                moving = false;
            }
            return;
        }
        actionTimer -= Time.deltaTime;
        if (actionTimer <= 0)
        {
            // Do something
            if (PlayerDistance() < criticalShootRange)
            {
                TryToKill();
            }
            switch(Random.Range(0f,100f))
            {
                case float n when (n >= 0 && n < 50):
                    MoveRandomly();
                    break;
                case float n when (n >= 50 && n < 70):
                    MoveToCamp();
                    break;
                case float n when (n >= 70 && n < 85):
                    LayTrap();
                    break;
                case float n when (n >= 85 && n < 95):
                    TrackTarget();
                    break;
                case float n when (n >= 95):
                    ShootTarget();
                    break;
            }
            actionTimer = Random.Range(timeBetweenActions*0.75f, timeBetweenActions * 1.25f);
            patience--;
        }
        if (patience <= 0)
        {
            Debug.Log("A Hunter has run out of patience.");
        }
    }

    public float PlayerDistance()
    {
        Vector3 distance = Deer.player.transform.position - transform.position;
        return distance.magnitude;
    }

    public void TryToKill()
    {
        audioSource.Play();
        Vector3 direction = Deer.player.transform.position - transform.position;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, criticalShootRange+1))
        {
            if (hit.collider != null)
            {
                Deer deer = hit.collider.GetComponent<Deer>();
                if (deer !=null)
                {
                    deer.GetShoot(true);
                }
            }
        }
    }

    public void MoveRandomly()
    {
        Vector3 randomSpot = new Vector3(Random.Range(World.Border.x, World.Border.x), 2, Random.Range(World.Border.z, World.Border.z));
        Vector3 direction = randomSpot - transform.position;
        transform.position += direction.normalized * movementSpeed;
    }

    public void MoveToCamp()
    {
        moving = true;
        movementGoal = campCordinates;
    }

    public void LayTrap()
    {
        if (traps >= 1)
        {
            Instantiate(trap, transform.position, Quaternion.identity);
        }
        else
        {
            traps += Random.Range(0.1f, 0.3f);
            patience--;
        }
    }

    public void TrackTarget()
    {
        if (tracking > PlayerDistance())
        {
            moving = true;
            movementGoal = Deer.player.transform.position;
        }
        else
        {
            tracking += Random.Range(5f, 25f);
            patience--;
        }
    }

    public void ShootTarget()
    {
        audioSource.Play();
        Vector3 direction = Deer.player.transform.position - transform.position;
        if (direction.magnitude *2 > Random.Range(1,100) )
        {
            patience -= 5;
            return;
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, criticalShootRange + 1))
        {
            if (hit.collider != null)
            {
                Deer deer = hit.collider.GetComponent<Deer>();
                if (deer != null)
                {
                    deer.GetShoot(false);
                }
            }
        }
    }

    public void LosePatience(int n)
    {
        patience-= n;
    }



}
