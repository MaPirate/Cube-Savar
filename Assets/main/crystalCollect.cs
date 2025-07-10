using Unity.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
public class crystalCollect : MonoBehaviour
{
    private int collectedCrystals = 0;
    private int score = 0;
    void Start()
    {
        UIManager.Instance.UpdateScoreText(score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // از این تابع برای جمع‌آوری آیتم‌ها استفاده می‌کنیم
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[DEBUG] A trigger event occurred with: '{other.gameObject.name}' which has the tag: '{other.gameObject.tag}'");

        // با استفاده از CompareTag که روش بهینه‌تری است، تگ را چک می‌کنیم
        if (other.CompareTag("crystal")) // فرض می‌کنیم تگ کریستال شما "Crystal" است
        {
            // روش صحیح برای افزایش امتیاز
            score++;

            // به مدیر UI خبر می‌دهیم تا متن را آپدیت کند
            if (UIManager.Instance != null)
            {
                UIManager.Instance.UpdateScoreText(score);
            }

            // کریستال جمع‌شده را نابود می‌کنیم
            Destroy(other.gameObject);
        }
    }

}
