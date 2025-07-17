using UnityEngine;
using TMPro; // <<< ۱. این خط برای شناسایی کامپوننت‌های TextMeshPro حیاتی است
using GameAnalyticsSDK;

public class ReportManager : MonoBehaviour
{
    // این دو متغیر عمومی شما هستند
    public GameObject reportPanel;
    public TMP_InputField reportInputField; // <<< ۲. نوع متغیر باید دقیقا به این شکل باشد

    public void OpenReportPanel()
    {
        if (reportPanel != null)
        {
            reportPanel.SetActive(true);
            GameAnalytics.NewDesignEvent("UI:Report:PanelOpened");
        }
    }

    public void SubmitReport()
    {
        if (reportInputField == null) return;

        string reportText = reportInputField.text;

        if (string.IsNullOrEmpty(reportText))
        {
            Debug.LogWarning("گزارش خالی است و ارسال نشد.");
            return;
        }

        GameAnalytics.NewDesignEvent("UI:Report:Submitted");
        Debug.Log($"گزارش ثبت شد: {reportText}");
        reportInputField.text = "";

        if (reportPanel != null)
        {
            reportPanel.SetActive(false);
        }
    }
}