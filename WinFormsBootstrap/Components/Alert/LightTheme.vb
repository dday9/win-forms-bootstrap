Imports System.Drawing
Imports System.Windows.Forms
Imports WinFormsBootstrap.Utilities.Colors

Namespace Components.Alert
    Public Class LightTheme

#Region "Danger"

        Public Shared ReadOnly DangerBackColor As Color = Utilities.Colors.LightTheme.DangerBgSubtle
        Public Shared ReadOnly DangerBorderColor As Color = Utilities.Colors.LightTheme.DangerBorderSubtle
        Public Shared ReadOnly DangerForeColor As Color = Utilities.Colors.LightTheme.DangerTextEmphasis

#End Region

#Region "Dark"

        Public Shared ReadOnly DarkBackColor As Color = Utilities.Colors.LightTheme.DarkBgSubtle
        Public Shared ReadOnly DarkBorderColor As Color = Utilities.Colors.LightTheme.DarkBorderSubtle
        Public Shared ReadOnly DarkForeColor As Color = Utilities.Colors.LightTheme.DarkTextEmphasis

#End Region

#Region "Info"

        Public Shared ReadOnly InfoBackColor As Color = Utilities.Colors.LightTheme.InfoBgSubtle
        Public Shared ReadOnly InfoBorderColor As Color = Utilities.Colors.LightTheme.InfoBorderSubtle
        Public Shared ReadOnly InfoForeColor As Color = Utilities.Colors.LightTheme.InfoTextEmphasis

#End Region

#Region "Light"

        Public Shared ReadOnly LightBackColor As Color = Utilities.Colors.LightTheme.LightBgSubtle
        Public Shared ReadOnly LightBorderColor As Color = Utilities.Colors.LightTheme.LightBorderSubtle
        Public Shared ReadOnly LightForeColor As Color = Utilities.Colors.LightTheme.LightTextEmphasis

#End Region

#Region "Primary"

        Public Shared ReadOnly PrimaryBackColor As Color = Utilities.Colors.LightTheme.PrimaryBgSubtle
        Public Shared ReadOnly PrimaryBorderColor As Color = Utilities.Colors.LightTheme.PrimaryBorderSubtle
        Public Shared ReadOnly PrimaryForeColor As Color = Utilities.Colors.LightTheme.PrimaryTextEmphasis

#End Region

#Region "Secondary"

        Public Shared ReadOnly SecondaryBackColor As Color = Utilities.Colors.LightTheme.SecondaryBgSubtle
        Public Shared ReadOnly SecondaryBorderColor As Color = Utilities.Colors.LightTheme.SecondaryBorderSubtle
        Public Shared ReadOnly SecondaryForeColor As Color = Utilities.Colors.LightTheme.SecondaryTextEmphasis

#End Region

#Region "Success"

        Public Shared ReadOnly SuccessBackColor As Color = Utilities.Colors.LightTheme.SuccessBgSubtle
        Public Shared ReadOnly SuccessBorderColor As Color = Utilities.Colors.LightTheme.SuccessBorderSubtle
        Public Shared ReadOnly SuccessForeColor As Color = Utilities.Colors.LightTheme.SuccessTextEmphasis

#End Region

#Region "Warning"

        Public Shared ReadOnly WarningBackColor As Color = Utilities.Colors.LightTheme.WarningBgSubtle
        Public Shared ReadOnly WarningBorderColor As Color = Utilities.Colors.LightTheme.WarningBorderSubtle
        Public Shared ReadOnly WarningForeColor As Color = Utilities.Colors.LightTheme.WarningTextEmphasis

#End Region

        Public Shared Function BackColor(alert As Alert) As Color
            Select Case alert.AlertVariant
                Case AlertVariants.Danger
                    Return DangerBackColor
                Case AlertVariants.Dark
                    Return DarkBackColor
                Case AlertVariants.Info
                    Return InfoBackColor
                Case AlertVariants.Light
                    Return LightBackColor
                Case AlertVariants.Primary
                    Return PrimaryBackColor
                Case AlertVariants.Secondary
                    Return SecondaryBackColor
                Case AlertVariants.Success
                    Return SuccessBackColor
                Case AlertVariants.Warning
                    Return WarningBackColor
            End Select

            Return Color.Transparent
        End Function

        Public Shared Function BorderColor(alert As Alert) As Color
            Select Case alert.AlertVariant
                Case AlertVariants.Danger
                    Return DangerBorderColor
                Case AlertVariants.Dark
                    Return DarkBorderColor
                Case AlertVariants.Info
                    Return InfoBorderColor
                Case AlertVariants.Light
                    Return LightBorderColor
                Case AlertVariants.Primary
                    Return PrimaryBorderColor
                Case AlertVariants.Secondary
                    Return SecondaryBorderColor
                Case AlertVariants.Success
                    Return SuccessBorderColor
                Case AlertVariants.Warning
                    Return WarningBorderColor
            End Select

            Return Color.Transparent
        End Function

        Public Shared Function ForeColor(alert As Alert) As Color
            Select Case alert.AlertVariant
                Case AlertVariants.Danger
                    Return DangerForeColor
                Case AlertVariants.Dark
                    Return DarkForeColor
                Case AlertVariants.Info
                    Return InfoForeColor
                Case AlertVariants.Light
                    Return LightForeColor
                Case AlertVariants.Primary
                    Return PrimaryForeColor
                Case AlertVariants.Secondary
                    Return SecondaryForeColor
                Case AlertVariants.Success
                    Return SuccessForeColor
                Case AlertVariants.Warning
                    Return WarningForeColor
            End Select

            Dim parentControl As Control = alert.Parent
            Dim inheritedColor As Color = If(parentControl IsNot Nothing, parentControl.ForeColor, Utilities.Colors.LightTheme.BodyColor)

            Return Color.Transparent
        End Function

    End Class
End Namespace
