using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

   public Transform[] patrolPoints;
    Transform currentPatrolPoint;
    int currentPatrolIndex;
   public float speed;

    public Transform target;
    public float chaseRange;
    public PlayerMovement playerMovement;
    public Hide hide;
    private BoxCollider2D box;


    // Start is called before the first frame update
    void Start()
    {
        currentPatrolIndex = 0;
        currentPatrolPoint = patrolPoints[currentPatrolIndex];
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(hide.canHide);
        //Have we reached the patrol point
        if (Vector3.Distance(transform.position, currentPatrolPoint.position) < 2f)
        {
            //We have reached the patrol point, get the next one 
            if (currentPatrolIndex + 1 < patrolPoints.Length)
            {
                currentPatrolIndex++;

            } else
            {//go back to the beginning if theres no more patrol points
                currentPatrolIndex = 0;
            }
                currentPatrolPoint = patrolPoints[currentPatrolIndex];
        }
          //Turn to face other point
          //find teh direction vector that points to the patrol point
    Vector3 patrolPointDir = currentPatrolPoint.position - transform.position;
        Vector3 newScale;
        //Figure out the rotation in degrees thats needed to turn towards
       /* float angle = Mathf.Atan2(patrolPointDir.x, patrolPointDir.z) * Mathf.Rad2Deg - 90f;
        //make a rotation thats we face
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.down);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180f);*/
        if (patrolPointDir.x < 0f)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            newScale = new Vector3(-1, 1, 1);
            transform.localScale = newScale;
        }
        if (patrolPointDir.x > 0f)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            newScale = new Vector3(1, 1, 1);
            transform.localScale = newScale;
        }

        //Get distance of target and see if its close enought to chase
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget < chaseRange)
        {
            //start chasing and move towards it
            Vector3 targetDir = target.position - transform.position;
            /*float angleToChase = Mathf.Atan2(targetDir.x, targetDir.z) * Mathf.Rad2Deg - 90f;
            Quaternion q2 = Quaternion.AngleAxis(angleToChase, Vector3.down);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q2, 180);*/

            // transform.Translate(Vector3.up * Time.deltaTime * speed);
            transform.Translate(targetDir.normalized * Time.deltaTime * speed);
           
        }


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player" && hide.canHide)
        {
            playerMovement.dead = false;
            box.enabled = false;
        }
        if (other.gameObject.name == "Player" && !hide.canHide)
        {
            playerMovement.dead = true;
            playerMovement.death();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        box.enabled = true;
    }


}
