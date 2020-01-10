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
}
