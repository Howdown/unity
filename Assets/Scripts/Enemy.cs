namespace Assets.Scripts
{
    using UnityEngine;

    public class Enemy : MonoBehaviour
    {
        public float speed = 10f;

        private Transform target;

        private int wavepointIndex = 0;
        
        public void Start()
        {
            this.target = Weapoints.points[0];
        }

        public void Update()
        {
            Vector3 dir = this.target.position - this.transform.position;
            this.transform.Translate(dir.normalized * this.speed * Time.deltaTime, Space.World);
            if (Vector3.Distance(this.transform.position, this.target.position) <= 0.3f)
            {
                this.GetNextWaypoint();
            }
        }

        public void GetNextWaypoint()
        {
            if (this.wavepointIndex >= Weapoints.points.Length - 1)
            {
                Destroy(this.gameObject);
                return;
            }
            this.wavepointIndex++;
            this.target = Weapoints.points[this.wavepointIndex];
        }
    }
}
