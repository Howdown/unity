namespace Assets.Scripts
{
    using UnityEngine;

    public class Bullet : MonoBehaviour {

        private Transform target;
        public float speed = 70f; 
        public GameObject bulletEffect; 

        public void Seek(Transform _target)
        {
            this.target = _target;
        }

        public void Update()
        {
            if (this.target == null)
            {
                Destroy(this.gameObject);
                return;
            }
            Vector3 dir = this.target.position - this.transform.position; 
            float distanceThisFrame = this.speed * Time.deltaTime;
            if (dir.magnitude <= distanceThisFrame)
            {
                this.HitTarget();
                return;
            }
            this.transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        }

        public void HitTarget()
        { 
            GameObject effectIns = (GameObject)Instantiate(this.bulletEffect, this.transform.position, this.transform.rotation);
            Destroy(effectIns, 2f);
            Destroy(this.target.gameObject);
            Destroy(this.gameObject);
        }
    }
}
