using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCone : MonoBehaviour {

    public GameObject playerObj;

    public bool isPlayerInRange = false;

    [SerializeField]
    SpriteRenderer spr;

    [SerializeField]
    Transform lineOfSightEnd;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (IsPlayerSeen())
            spr.color = Color.red;
        else
            spr.color = Color.white;



    }

    bool IsPlayerSeen()
    {

        // we only need to check visibility if the player is within the enemy's visual range
        if (isPlayerInRange)
        {
            if (IsPlayerInFOV())
                return (!IsPlayerObstructed());
            else
                return false;

        }
        else
        {
            // always false if the player is not within the enemy's range
            return false;
        }

    }

    bool IsPlayerInFOV()
    {
        // find the angle between the enemy's 'forward' direction and the player's location and return true if it's within 65 degrees (for 130 degree field of view)

        Vector2 directionToPlayer = playerObj.transform.position - transform.position; // represents the direction from the enemy to the player    
        Debug.DrawLine(transform.position, playerObj.transform.position, Color.magenta); // a line drawn in the Scene window equivalent to directionToPlayer

        Vector2 lineOfSight = lineOfSightEnd.position - transform.position; // the centre of the enemy's field of view, the direction of looking directly ahead
        Debug.DrawLine(transform.position, lineOfSightEnd.position, Color.yellow); // a line drawn in the Scene window equivalent to the enemy's field of view centre

        // calculate the angle formed between the player's position and the centre of the enemy's line of sight
        float angle = Vector2.Angle(directionToPlayer, lineOfSight);

        if(angle < 180.0f)
        {
            return true;
        }
        return false;
    }

    bool IsPlayerObstructed()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerObj.transform.position);
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, playerObj.transform.position - transform.position, distanceToPlayer);
        Debug.DrawRay(transform.position, playerObj.transform.position - transform.position, Color.blue); // draw line in the Scene window to show where the raycast is looking

        List<float> distances = new List<float>();

        foreach(RaycastHit2D hit in hits)
        {
            if(hit.transform.tag == "Enemy")
            {
                continue;
            }
            else if(hit.transform.tag == "Player")
            {
                return false;
            }
        }
        return true;

    }

	private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
            isPlayerInRange = true;

    }

	private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerInRange = false;
        }

		
    }

    //public float viewRadius;

    //[Range(0,360)]
    //public float viewAngle;

    //public LayerMask targetMask;
    //public LayerMask obstacleMask;


    //public List<Transform> visibleTargets = new List<Transform>();

    //private void Start()
    //{
    //    StartCoroutine("FindTargetsWithDelay", 0.2f);
    //}

    //IEnumerator FindTargetsWithDelay(float delay)
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(delay);
    //        FindVisisbleTargets();
    //    }
    //}

    //void FindVisisbleTargets()
    //{
    //    visibleTargets.Clear();
    //    Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, targetMask);

    //    for(int i = 0; i < targetsInViewRadius.Length; i++)
    //    {
    //        Transform target = targetsInViewRadius[i].transform;
    //        Vector2 dirToTarget = (target.position - transform.position).normalized;
    //        if(Vector2.Angle(transform.forward, -dirToTarget) < viewAngle / 2){
    //            float distanceToTarget = Vector2.Distance(transform.position, target.position);

    //            Debug.Log(Vector2.Angle(transform.forward, dirToTarget));

    //            if(!Physics2D.Raycast(transform.position, dirToTarget, distanceToTarget, obstacleMask))
    //            {
    //                //no obstacles
    //                visibleTargets.Add(target);
    //            }
    //        }
    //    }
    //}

    //public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    //{
    //    if (!angleIsGlobal)
    //    {
    //        angleInDegrees += transform.eulerAngles.y; //keeps the angle relative to enemy
    //    }
    //    return new Vector2(Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), Mathf.Sin(angleInDegrees * Mathf.Deg2Rad));
    //}
}
