using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPotion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Cart cart = collision.transform.root.GetComponent<Cart>();

        if (cart != null)
        {
            StoneMovement.freezing = true;
            Destroy(gameObject);
        }
    }
}
