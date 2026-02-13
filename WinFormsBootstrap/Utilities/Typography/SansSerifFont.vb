Imports System.Drawing

Namespace Utilities.Typography

    Public Class SansSerifFont
        Inherits BaseFont

        Public Overloads Shared Function CreateFont() As Font
            Return CreateFont(TypographyUtility.DEFAULT_FONT_SIZE_IN_PX)
        End Function

        Public Overloads Shared Function CreateFont(size As Single) As Font
            Return CreateFont(size, FontStyle.Regular, GraphicsUnit.Pixel)
        End Function

        Public Overloads Shared Function CreateFont(size As Single, style As FontStyle) As Font
            Return CreateFont(size, style, GraphicsUnit.Pixel)
        End Function

        Public Overloads Shared Function CreateFont(size As Single, unit As GraphicsUnit) As Font
            Return CreateFont(size, FontStyle.Regular, unit)
        End Function

        Public Overloads Shared Function CreateFont(size As Single, style As FontStyle, unit As GraphicsUnit) As Font
            Return CreateFont(GetPreferredFontFamily(), size, style, unit)
        End Function

        Public Shared Function GetFontStack() As IEnumerable(Of FontFamily)
            Dim stack As New List(Of FontFamily)
            Dim systemUi As FontFamily = SystemFonts.MessageBoxFont.FontFamily
            If (systemUi IsNot Nothing) Then
                stack.Add(systemUi)
            End If

            Dim preferredFonts As String() = {
                "-apple-system",
                "Segoe UI",
                "Roboto",
                "Helvetica Neue",
                "Noto Sans",
                "Liberation Sans",
                "Arial",
                "Apple Color Emoji",
                "Segoe UI Emoji",
                "Segoe UI Symbol",
                "Noto Color Emoji"
            }

            For Each preferredFont As String In preferredFonts
                If (InstalledFontNames.Contains(preferredFont)) Then
                    Dim preferredFontFamily As New FontFamily(preferredFont)
                    If (Not stack.Contains(preferredFontFamily)) Then
                        stack.Add(New FontFamily(preferredFont))
                    End If
                End If
            Next

            Dim genericFontFamily As FontFamily = FontFamily.GenericSansSerif
            If (Not stack.Contains(genericFontFamily)) Then
                stack.Add(genericFontFamily)
            End If

            Return stack

        End Function

        Public Shared Function GetPreferredFontFamily() As FontFamily
            Return GetFontStack().First()
        End Function

    End Class

End Namespace
