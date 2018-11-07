namespace Assets.Scripts
{
    using UnityEngine;

    public class Weapoints : MonoBehaviour
    {
        public static Transform[] points;

        public void Awake()
        {
            points = new Transform[this.transform.childCount];
            for (var i = 0; i < points.Length; i++)
            {
                points[i] = this.transform.GetChild(i);
            }
        }
    }
}
