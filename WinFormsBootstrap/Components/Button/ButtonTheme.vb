Imports System.Drawing
Imports WinFormsBootstrap.Utilities.Colors

Namespace Components.Button

    Public Class ButtonTheme

        Public Shared Function BackColor(button As Button) As Color
            If (button.ThemeMode.Equals(ThemeModes.LightTheme)) Then
                Return LightTheme.BackColor(button)
            End If

            Return DarkTheme.BackColor(button)
        End Function

        Public Shared Function BorderColor(button As Button) As Color
            If (button.ThemeMode.Equals(ThemeModes.LightTheme)) Then
                Return LightTheme.BorderColor(button)
            End If

            Return DarkTheme.BorderColor(button)
        End Function

        Public Shared Function ForeColor(button As Button) As Color
            If (button.ThemeMode.Equals(ThemeModes.LightTheme)) Then
                Return LightTheme.ForeColor(button)
            End If

            Return DarkTheme.ForeColor(button)
        End Function

    End Class

End Namespace
