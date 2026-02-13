Imports System.Drawing
Imports WinFormsBootstrap.Utilities.Colors

Namespace Components.Alert
    Public Class AlertTheme
        Public Shared Function BackColor(alert As Alert) As Color
            If (alert.ThemeMode.Equals(ThemeModes.LightTheme)) Then
                Return LightTheme.BackColor(alert)
            End If

            Return DarkTheme.BackColor(alert)
        End Function

        Public Shared Function BorderColor(alert As Alert) As Color
            If (alert.ThemeMode.Equals(ThemeModes.LightTheme)) Then
                Return LightTheme.BorderColor(alert)
            End If

            Return DarkTheme.BorderColor(alert)
        End Function

        Public Shared Function ForeColor(alert As Alert) As Color
            If (alert.ThemeMode.Equals(ThemeModes.LightTheme)) Then
                Return LightTheme.ForeColor(alert)
            End If

            Return DarkTheme.ForeColor(alert)
        End Function
    End Class
End Namespace