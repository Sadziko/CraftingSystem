using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.InputSystem.InputAction;

public class PlayerCollect : MonoBehaviour
{
    [SerializeField] float collectRadius = 5f;
    [SerializeField] LayerMask collectLayerMasks;

    [SerializeField] UnityEvent<ItemData> OnItemCollected;

    [SerializeField] bool debug;


    /// <summary>
    /// Collect items from sources in radius
    /// </summary>
    public void Collect(CallbackContext callbackContext)
    {
        if (callbackContext.phase != UnityEngine.InputSystem.InputActionPhase.Started) return;

        var colliders = Physics.OverlapSphere(transform.position, collectRadius, collectLayerMasks);
        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out ResourceSource resourceSource))
            {
                var collected = resourceSource.GatherResources();
                OnItemCollected.Invoke(collected);
                if (debug)
                {
                    Debug.Log("Collected " + collected);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out WorldItem item))
        {
            Debug.Log("Collect world item");
            OnItemCollected.Invoke(item.ItemData);
            item.OnPickup();
        }


    }

    private void OnDrawGizmosSelected()
    {
        if (debug)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, collectRadius);
        }
    }
}
