namespace Assets.Scripts
{
    using UnityEngine;

    public class Turret : MonoBehaviour {

        private Transform target;
        public float range = 15f;
        public string enemyTag = "Enemy";
        public Transform partToRotate;
        public float turnSpeed = 10f;

        public void Start()
        {
            this.InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }

        public void UpdateTarget()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(this.enemyTag);
            float shortestDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;
            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(this.transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }
            if (nearestEnemy != null && shortestDistance <= this.range)
            {
                this.target = nearestEnemy.transform;
            }
            else
            {
                this.target = null;
            }
        }

        public void Update()
        {
            if (this.target == null)
                return;

            Vector3 dir = this.target.position - this.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(this.partToRotate.rotation, lookRotation, Time.deltaTime * this.turnSpeed).eulerAngles;
            this.partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }

        public void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, this.range);
        }
    }
}
