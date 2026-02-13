
Imports System.Drawing
Imports System.Drawing.Text

Namespace Utilities.Typography

    Public MustInherit Class BaseFont

        Protected Shared ReadOnly InstalledFontNames As HashSet(Of String) =
            New InstalledFontCollection().
                Families.
                Select(Function(f) f.Name).
                ToHashSet(StringComparer.OrdinalIgnoreCase)

        Protected Shared Function CreateFont(fontFamily As FontFamily, size As Single, style As FontStyle, unit As GraphicsUnit) As Font
            Return New Font(fontFamily, size, style, unit)
        End Function

    End Class
End Namespace
