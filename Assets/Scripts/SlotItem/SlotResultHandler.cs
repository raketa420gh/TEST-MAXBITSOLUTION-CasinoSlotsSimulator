using UnityEngine;

public class SlotResultHandler : MonoBehaviour
{
    [SerializeField] private ReelSlots _reelSlots;

    private void OnEnable() => _reelSlots.OnSpinFinished += OnSpinFinished;

    private void OnDisable() => _reelSlots.OnSpinFinished -= OnSpinFinished;

    private void HandleOppositeSlot()
    {
        Ray ray = new Ray(transform.position, Vector3.forward);
        
        Debug.DrawRay(ray.origin, ray.direction, Color.red);

        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit)) 
            return;
        
        var slotItem = hit.collider.GetComponent<ISlotItem>();

        slotItem?.Select();
    }

    private void HandleOppositeSlotDelayed() => Invoke(nameof(HandleOppositeSlot), 0.05f);

    private void OnSpinFinished() => HandleOppositeSlotDelayed();
}
