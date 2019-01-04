using System;
using UnityEngine;
using UnityEngine.AI;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling

        public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
        {
            Vector3 randDirection = UnityEngine.Random.insideUnitSphere * dist;
            randDirection += origin;
            NavMeshHit navHit;
            NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
            return navHit.position;
        }

        private GameObject player;
        private int wanderTimer = 1000;

        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
            player = GameObject.FindGameObjectWithTag("Player");

	        agent.updateRotation = false;
	        agent.updatePosition = true;
        }


        private void Update()
        {
            if (Vector3.Distance(this.transform.position, player.transform.position) > 1000)
            {
                agent.isStopped = true;
            }
            else if(Vector3.Distance(this.transform.position,player.transform.position) > 250)
            {
                agent.isStopped = false;
                wanderTimer = 0;
                agent.SetDestination(player.transform.position);
                Vector3 speed = new Vector3(agent.desiredVelocity.x * 2, agent.desiredVelocity.y * 2, agent.desiredVelocity.z * 2);
                character.Move(speed, false, false);
            }
            else if (agent.remainingDistance > agent.stoppingDistance)
            {
                agent.isStopped = false;
                Vector3 speed = new Vector3(agent.desiredVelocity.x / 2, agent.desiredVelocity.y / 2 , agent.desiredVelocity.z / 2);
                character.Move(speed, false, false);
            }
            else
            {
                agent.isStopped = false;
                character.Move(Vector3.zero, false, false);
            }
                
        }

        private void FixedUpdate()
        {
            wanderTimer++;
            if(wanderTimer >= 1000)
            {
                wanderTimer = 0;
                Vector3 newPos = RandomNavSphere(transform.position, 1000, -1);
                agent.SetDestination(newPos);
            }
        }
    }
}
