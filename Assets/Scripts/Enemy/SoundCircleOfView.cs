using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCircleOfView : MonoBehaviour
{
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;// Start is called before the first frame update

    private float hitDistance;

    public LayerMask wallMask;
    public LayerMask AppleseedMask;

    public int edgeResolveIterations;
    public float edgeDistanceMin;

    //public MeshFilter viewMeshFilter;
    //Mesh viewMesh;



    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    public float meshResolution;

    void Start()
    {
        //viewMesh = new Mesh();
        //viewMesh.name = "View Mesh";
        //viewMeshFilter.mesh = viewMesh;
        StartCoroutine("FindTargetsDelayed", .2f);
    }

    private void LateUpdate()
    {
        DrawFieldOfView();
    }
    IEnumerator FindTargetsDelayed(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }
    void FindVisibleTargets()
    {
        visibleTargets.Clear();
        int layerMask = LayerMask.GetMask("Objects");
        int blockMask = LayerMask.GetMask("SmallWalls", "Pitfalls"); //Maybe Pitfalls, and SmallWalls or delete them...
        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), viewRadius, layerMask);//ytransform.position, viewRadius, AppleseedMask); ;

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(-transform.up, directionToTarget) < viewAngle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                EnemyController souldierEnemy = GetComponent<EnemyController>();
                RopeBaseController sandbag = target.gameObject.GetComponentInParent<RopeBaseController>();
                if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, blockMask) && souldierEnemy.GetHuntState() == false && souldierEnemy.GetArrestState() == false && sandbag.isCut == true)
                {
                    visibleTargets.Add(target);
                    PawnMovementController pawnMovement = GetComponent<PawnMovementController>();
                    pawnMovement.SetSoundSource(target.gameObject);
        
                }
            }
        }
    }

    void DrawFieldOfView()
    {
        int stepCount = Mathf.RoundToInt(viewAngle * meshResolution);
        float stepAngleSize = viewAngle / stepCount;
        List<Vector3> viewPoints = new List<Vector3>();
        ViewCastInfo oldViewCast = new ViewCastInfo();//new

        for (int i = 0; i <= stepCount; i++)
        {
            float angle = transform.eulerAngles.z - viewAngle / 2 + stepAngleSize * i;//or y
            ViewCastInfo newViewCast = ViewCast(angle);

            if (i > 0)
            {
                bool edgeDistanceMinExceeded = Mathf.Abs(oldViewCast.distance - newViewCast.distance) > edgeDistanceMin;
                if (oldViewCast.isHit != newViewCast.isHit || (oldViewCast.isHit && newViewCast.isHit && edgeDistanceMinExceeded))//new
                {
                    EdgeInfo edge = FindEdge(oldViewCast, newViewCast);
                    if (edge.pointA != Vector3.zero)
                    {
                        viewPoints.Add(edge.pointA);
                    }
                    if (edge.pointB != Vector3.zero)
                    {
                        viewPoints.Add(edge.pointB);
                    }
                }
            }

            viewPoints.Add(newViewCast.point);
            oldViewCast = newViewCast;//new
        }

        int vertexCount = viewPoints.Count + 1;
        Vector3[] verticies = new Vector3[vertexCount];
        int[] triangles = new int[(vertexCount - 2) * 3];

        verticies[0] = Vector3.zero;

        for (int i = 0; i < vertexCount - 1; i++)
        {
            verticies[i + 1] = transform.InverseTransformPoint(viewPoints[i]);
            if (i < vertexCount - 2)
            {
                triangles[i * 3] = 0;
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3 + 2] = i + 2;
            }
        }

        //viewMesh.Clear();
        //viewMesh.vertices = verticies;
        //viewMesh.triangles = triangles;
        //viewMesh.RecalculateNormals();
    }

    EdgeInfo FindEdge(ViewCastInfo min, ViewCastInfo max)//new
    {
        float minAngle = min.angle;
        float maxAngle = max.angle;
        Vector3 minPoint = Vector3.zero;
        Vector3 maxPoint = Vector3.zero;

        for (int i = 0; i < edgeResolveIterations; i++)
        {
            float angle = (minAngle + maxAngle) / 2;
            ViewCastInfo newViewCast = ViewCast(angle);

            bool edgeDistanceMinExceeded = Mathf.Abs(min.distance - newViewCast.distance) > edgeDistanceMin;
            if (newViewCast.isHit == min.isHit && !edgeDistanceMinExceeded)
            {
                minAngle = angle;
                minPoint = newViewCast.point;
            }
            else
            {
                maxAngle = angle;
                maxPoint = newViewCast.point;
            }
        }

        return new EdgeInfo(minPoint, maxPoint);
    }
    ViewCastInfo ViewCast(float globalAngle)
    {
        Vector3 direction = DirectionFromAngle(globalAngle, true);
        int blockMask = LayerMask.GetMask("SmallWalls");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(direction.x, direction.y), viewRadius, blockMask);

        if (hit && hit.collider != null)
        {
            return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);

        }
        else
        {
            return new ViewCastInfo(false, transform.position + direction * viewRadius, viewRadius, globalAngle);
        }
    }


    public Vector3 DirectionFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.z;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), -Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), 0);
    }

    public struct ViewCastInfo
    {
        public bool isHit;
        public Vector3 point;
        public float distance;
        public float angle;

        public ViewCastInfo(bool _hit, Vector3 _point, float _distance, float _angle)
        {
            isHit = _hit;
            point = _point;
            distance = _distance;
            angle = _angle;

        }
    }

    public struct EdgeInfo//new
    {
        public Vector3 pointA;
        public Vector3 pointB;

        public EdgeInfo(Vector3 _pointA, Vector3 _pointB)
        {
            pointA = _pointA;
            pointB = _pointB;
        }
    }
}

