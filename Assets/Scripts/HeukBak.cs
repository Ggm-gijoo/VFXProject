using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.VFX;

public class HeukBak : MonoBehaviour
{
    [SerializeField] Volume volume;
    [SerializeField] GameObject[] poses;
    [SerializeField] VisualEffect[] vfxs;

    CameraShake camereShake;
    ColorAdjustments colorAd;

    public float speed = 0f;
    int i = 0;

    private void Awake()
    {
        camereShake = GetComponent<CameraShake>();
        volume.profile.TryGet(out colorAd);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (i >= vfxs.Length)
                i = 0;

            foreach (var pose in poses)
                pose.SetActive(false);
            var stateValue = vfxs[i].GetComponent<StateValue>();
            poses[(int)stateValue.pose].SetActive(true);
            //StartCoroutine(testSaturation());
            camereShake.Shake();
            vfxs[i].Play();
            i++;
        }
    }

    IEnumerator testSaturation()
    {
        colorAd.saturation.value = 0;
        colorAd.active = true;

        while(colorAd.saturation.value > -100f)
        {
            colorAd.saturation.value -= Time.deltaTime * 100 * speed;
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        while (colorAd.saturation.value < 0f)
        {
            colorAd.saturation.value += Time.deltaTime * 200 * speed;
            yield return null;
        }
        colorAd.active = false;
    }
}
