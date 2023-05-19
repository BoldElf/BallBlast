using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProtect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Cart cart = collision.transform.root.GetComponent<Cart>();

        if (cart != null)
        {
            Cart.protect = true;
            Destroy(gameObject);
        }
    }
}
