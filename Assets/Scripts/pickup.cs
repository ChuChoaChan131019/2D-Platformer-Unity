using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public enum pickupType { coin,gem,health}

    public pickupType pt;
    [SerializeField] GameObject PickupEffect;
    [SerializeField] private AudioClip coinSFX; 
    [SerializeField] private AudioClip gemSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Da cham vao: " + collision.gameObject.name);
        if(pt == pickupType.coin)
        {
            if(collision.gameObject.tag == "Player")
            {
                GameManager.instance.IncrementCoinCount();
                
                if(coinSFX != null) 
            AudioSource.PlayClipAtPoint(coinSFX, transform.position);
            
                Instantiate(PickupEffect, transform.position, Quaternion.identity);

                Destroy(this.gameObject,0.2f);
                
            }
            
        }

        if (pt == pickupType.gem)
        {
            if (collision.gameObject.tag == "Player")
            {
                GameManager.instance.IncrementGemCount();

                if(gemSFX != null) AudioSource.PlayClipAtPoint(gemSFX, transform.position);

                Instantiate(PickupEffect, transform.position, Quaternion.identity);
                
                Destroy(this.gameObject, 0.2f);

            }

        }
    }
}
