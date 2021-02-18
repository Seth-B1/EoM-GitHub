using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupAnimationEvents : MonoBehaviour
{

    // Start is called before the first frame update

    void DestroyWindow()
    {
        FindObjectOfType<ItemPickupTextList>().windows.Remove(transform.parent.GetComponent<ItemPickedUpText>());
        StartCoroutine(waitCoroutine());
        
    }

    IEnumerator waitCoroutine()
    {
        yield return new WaitForSeconds(3);
        Destroy(transform.parent.gameObject);
    }
}
