Imports WinFormsBootstrap.Components.Alert

Public Class FormAlerts

    Private Sub CheckBoxShowDismiss_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShowDismiss.CheckedChanged
        Dim alerts As IEnumerable(Of Alert) = GetAllAlerts()
        For Each control As Alert In alerts
            control.ShowDismiss = CheckBoxShowDismiss.Checked
        Next
        CheckBoxIsFadable.Enabled = CheckBoxShowDismiss.Checked
    End Sub

    Private Sub CheckBoxIsFadable_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxIsFadable.CheckedChanged
        Dim alerts As IEnumerable(Of Alert) = GetAllAlerts()
        For Each control As Alert In alerts
            control.IsFadable = CheckBoxIsFadable.Checked
        Next
    End Sub

    Private Sub ButtonReset_Click(sender As Object, e As EventArgs) Handles ButtonReset.Click
        Dim alerts As IEnumerable(Of Alert) = GetAllAlerts()
        For Each control As Alert In alerts
            control.IsDismissed = False
        Next
    End Sub

    Private Function GetAllAlerts() As IEnumerable(Of Alert)
        Dim alertsInLightMode As IEnumerable(Of Alert) = GroupBoxAlertsLightMode.Controls.OfType(Of Alert)
        Dim alertsInDarkMode As IEnumerable(Of Alert) = GroupBoxAlertsDarkMode.Controls.OfType(Of Alert)
        Return alertsInLightMode.Concat(alertsInDarkMode)
    End Function

End Class