Imports System.Drawing

Namespace Utilities.Colors
    Friend Class ColorUtility

        Friend Shared Function HexToRGB(hexValue As String) As Color
            If (hexValue.StartsWith("#")) Then
                hexValue = hexValue.Substring(1)
            End If

            If (hexValue.Length <> 6) Then
                Throw New ArgumentException("Invalid hex code length. Must be 6 characters.")
            End If

            Dim rgbVal As Integer = Convert.ToInt32(hexValue, 16)

            Dim r As Integer = (rgbVal >> 16) And &HFF
            Dim g As Integer = (rgbVal >> 8) And &HFF
            Dim b As Integer = rgbVal And &HFF

            Return Color.FromArgb(r, g, b)
        End Function

    End Class
End Namespace
