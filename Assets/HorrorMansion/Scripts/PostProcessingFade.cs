using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class PostProcessingFade : MonoBehaviour
{
    private Volume globalVolume; // Referencia automática
    private VolumeProfile volumeProfile;

    private MotionBlur motionBlur;
    private ChromaticAberration chromaticAberration;
    private Vignette vignette;
    private Bloom bloom;
    private LensDistortion lensDistortion;

    void Start()
    {
        // Obtén automáticamente el Global Volume en este objeto
        globalVolume = GetComponent<Volume>();
        if (globalVolume != null && globalVolume.profile != null)
        {
            volumeProfile = globalVolume.profile;

            // Intenta obtener todas las referencias necesarias
            if (!volumeProfile.TryGet(out motionBlur)) motionBlur = null;
            if (!volumeProfile.TryGet(out chromaticAberration)) chromaticAberration = null;
            if (!volumeProfile.TryGet(out vignette)) vignette = null;
            if (!volumeProfile.TryGet(out bloom)) bloom = null;
            if (!volumeProfile.TryGet(out lensDistortion)) lensDistortion = null;
        }
    }

    public void FadeOutEffects()
    {
        StartCoroutine(FadeEffectsCoroutine());
    }

     public void EnableGlobalVolume()
    {
        if (globalVolume != null)
        {
            globalVolume.enabled = true;
        }
    }

    private IEnumerator FadeEffectsCoroutine()
    {
        float duration = 3f; // Duración de la transición
        float elapsedTime = 0f;

        // Guarda los valores iniciales de cada efecto
        float initialMotionBlur = motionBlur != null ? motionBlur.intensity.value : 0f;
        float initialChromaticAberration = chromaticAberration != null ? chromaticAberration.intensity.value : 0f;
        float initialVignette = vignette != null ? vignette.intensity.value : 0f;
        float initialBloom = bloom != null ? bloom.intensity.value : 0f;
        float initialLensDistortion = lensDistortion != null ? lensDistortion.intensity.value : 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration; // Progreso de interpolación (0 a 1)

            // Ajusta los valores con interpolación lineal
            if (motionBlur != null) motionBlur.intensity.value = Mathf.Lerp(initialMotionBlur, 0f, t);
            if (chromaticAberration != null) chromaticAberration.intensity.value = Mathf.Lerp(initialChromaticAberration, 0f, t);
            if (vignette != null) vignette.intensity.value = Mathf.Lerp(initialVignette, 0f, t);
            if (bloom != null) bloom.intensity.value = Mathf.Lerp(initialBloom, 0f, t);
            if (lensDistortion != null) lensDistortion.intensity.value = Mathf.Lerp(initialLensDistortion, 0f, t);

            yield return null;
        }

        // Asegúrate de que los valores finales sean exactamente 0
        if (motionBlur != null) motionBlur.intensity.value = 0f;
        if (chromaticAberration != null) chromaticAberration.intensity.value = 0f;
        if (vignette != null) vignette.intensity.value = 0f;
        if (bloom != null) bloom.intensity.value = 0f;
        if (lensDistortion != null) lensDistortion.intensity.value = 0f;
    }
}
