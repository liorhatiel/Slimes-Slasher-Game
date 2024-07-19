using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{

    // For the WhiteFlash effect, we:
    // 1. Create a new Material
    // 2. Set the Shader to "GUI/Text Shader".

    SpriteRenderer sr;                                      // Referece to the SpriteRendere component.

    [SerializeField] Material whiteFlashMat;                // Refrence to the White Flash Material.
    [SerializeField] Material defaultMat;                   // Refrence to the default Material.

    [SerializeField] float whiteFlashTimeRoutine;           // How much time the White Flash Material work.

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        defaultMat = sr.material;

    }

    public IEnumerator WhiteFlashRoutine()
    {
        sr.material = whiteFlashMat;
        yield return new WaitForSeconds(whiteFlashTimeRoutine);
        sr.material = defaultMat;
    }

}
