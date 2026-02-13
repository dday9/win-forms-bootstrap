Namespace Controls
    Public Class GlobalNavigation
        Inherits MenuStrip

        Private _alertsMenuItem As ToolStripMenuItem
        Private _buttonsMenuItem As ToolStripMenuItem

        Public Sub New()
            MyBase.New()

            InitializeMenu()
        End Sub

        Private Sub InitializeMenu()
            Dock = DockStyle.Top

            AddNavigationItem("Alerts", GetType(FormAlerts))
            AddNavigationItem("Buttons", GetType(FormButtons))
        End Sub

        Private Sub AddNavigationItem(text As String, formType As Type)
            Dim item As New ToolStripMenuItem(text)
            AddHandler item.Click, Sub() NavigateTo(formType)
            Items.Add(item)
        End Sub

        Private Sub NavigateTo(targetFormType As Type)
            Dim currentForm As Form = Me.FindForm()

            If (currentForm Is Nothing) Then
                Return
            End If

            If (currentForm.GetType() Is targetFormType) Then
                Return
            End If

            Dim newForm As Form = CType(Activator.CreateInstance(targetFormType), Form)

            newForm.StartPosition = FormStartPosition.CenterScreen
            newForm.Show()

            currentForm.Close()
        End Sub
        Protected Overrides Sub OnParentChanged(e As EventArgs)
            MyBase.OnParentChanged(e)

            Dim parentForm As Form = Me.FindForm()

            If (parentForm IsNot Nothing) Then
                parentForm.MainMenuStrip = Me
            End If
        End Sub

    End Class
End Namespace
