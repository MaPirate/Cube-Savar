using UnityEngine;
// این خط را اگر ندارید، اضافه کنید
using TMPro;
using GameAnalyticsSDK;

public class ReportManager : MonoBehaviour
{
    public GameObject reportPanel;
    // این خط را تغییر دهید
    public TMP_InputField reportInputField; // <--- تغییر اصلی اینجاست

    // بقیه کد بدون تغییر باقی می‌ماند
    public void OpenReportPanel()
    {
        // ...
    }

    public void SubmitReport()
    {
        // نحوه خواندن متن از هر دو نوع یکسان است، پس این بخش نیازی به تغییر ندارد
        string reportText = reportInputField.text;

        if (string.IsNullOrEmpty(reportText))
        {
            Debug.LogWarning("گزارش خالی است و ارسال نشد.");
            return;
        }

        GameAnalytics.NewDesignEvent("UI:Report:Submitted");
        Debug.Log($"گزارش ثبت شد: {reportText}");
        reportInputField.text = "";
        reportPanel.SetActive(false);
    }
}