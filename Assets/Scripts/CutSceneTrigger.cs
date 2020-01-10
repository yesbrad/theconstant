using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(Collider))]
public class CutSceneTrigger : MonoBehaviour
{
    [SerializeField] PlayableDirector director;

    private void OnTriggerEnter (Collider col)
    {
        if(col.tag == Constants.TAG_PLAYER && director)
        {
            director.Play();
        }
    }

    private void OnDrawGizmos ()
    {
        Gizmos.color = new Color(0, 0.5f, 1, 0.3f);
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
        Gizmos.DrawCube(Vector3.zero, Vector3.one);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
        Gizmos.color = new Color(0, 0.5f, 1, 0.3f);
        Gizmos.DrawCube(Vector3.zero, Vector3.one);
    }

}
