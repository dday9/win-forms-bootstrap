Imports System.Drawing
Imports System.Windows.Forms

Namespace Utilities.Typography
    Public Class TypographyUtility

        Public Const DEFAULT_FONT_SIZE_IN_PX As Integer = 16

        Public Shared Function CalculateEM(control As Control) As Double
            If (control Is Nothing) Then
                Throw New ArgumentNullException(NameOf(control), "Control cannot be null.")
            End If

            Dim dpiScale As Single = control.DeviceDpi / 96.0F
            Return CalculateEM(control.Font) * dpiScale
        End Function

        Public Shared Function CalculateEM(controlFont As Font) As Double
            If (controlFont Is Nothing) Then
                Throw New ArgumentNullException(NameOf(controlFont), "Font cannot be null.")
            End If

            Return controlFont.Size
        End Function

        Public Shared Function CalculateREM(control As Control) As Double
            If (control Is Nothing) Then
                Throw New ArgumentNullException(NameOf(control), "Control cannot be null.")
            End If

            Dim rootElement As Form = control.FindForm()
            If (rootElement Is Nothing) Then
                CalculateEM(control)
            End If

            Return CalculateEM(rootElement)
        End Function

    End Class
End Namespace
