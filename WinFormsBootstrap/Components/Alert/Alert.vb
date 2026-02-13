Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Security
Imports System.Windows.Forms
Imports WinFormsBootstrap.Utilities.Colors
Imports WinFormsBootstrap.Utilities.Typography

Namespace Components.Alert
    Public Class Alert
        Inherits Panel

#Region "Constants"

        Private Const DEFAULT_PADDING_X_IN_REM As Double = 1
        Private Const DEFAULT_PADDING_Y_IN_REM As Double = 1
        Private Const DEFAULT_RADIUS_IN_REM As Double = 0.375
        Private Const FADE_DURATION As Integer = 255

#End Region

#Region "Property Variables"

        Private _alertVariant As AlertVariants? = Nothing
        Private _cornerRadius As Integer = 0
        Private _isDismissed As Boolean = False
        Private _isFadable As Boolean = True
        Private _showDismiss As Boolean = True
        Private _text As String = String.Empty
        Private _textAlign As ContentAlignment = ContentAlignment.TopLeft
        Private _themeMode As ThemeModes = ThemeModes.LightTheme

#End Region

#Region "Properties"

        Public Property AlertVariant As AlertVariants?
            Get
                Return _alertVariant
            End Get
            Set(value As AlertVariants?)
                _alertVariant = value
                OnAlertVariantChanged(EventArgs.Empty)
                Invalidate()
            End Set
        End Property

        Public Property CornerRadius As Integer
            Get
                Return _cornerRadius
            End Get
            Set(value As Integer)
                _cornerRadius = value
                OnCornerRadiusChanged(EventArgs.Empty)
                Invalidate()
            End Set
        End Property

        Public Property IsFadable As Boolean
            Get
                Return _isFadable
            End Get
            Set(value As Boolean)
                _isFadable = value
                OnIsFadableChanged(EventArgs.Empty)
            End Set
        End Property

        Public Property IsDismissed As Boolean
            Get
                Return _isDismissed
            End Get
            Set(value As Boolean)
                _isDismissed = value
                OnIsDismissedChanged(EventArgs.Empty)
                Invalidate()
            End Set
        End Property

        Public Property ShowDismiss As Boolean
            Get
                Return _showDismiss
            End Get
            Set(value As Boolean)
                _showDismiss = value
                OnShowDismissChanged(EventArgs.Empty)
                Invalidate()
            End Set
        End Property

        <Bindable(True)>
        <Browsable(True)>
        <Category("Appearance")>
        <Description("The text associated with the control.")>
        Public Overrides Property Text As String
            Get
                Return _text
            End Get
            Set(value As String)
                _text = value
                OnTextChanged(EventArgs.Empty)
                Invalidate()
            End Set
        End Property

        Public Property TextAlign As ContentAlignment
            Get
                Return _textAlign
            End Get
            Set(value As ContentAlignment)
                _textAlign = value
                OnTextAlignChanged(EventArgs.Empty)
                Invalidate()
            End Set
        End Property

        Public Property ThemeMode As ThemeModes
            Get
                Return _themeMode
            End Get
            Set(value As ThemeModes)
                _themeMode = value
                OnThemeModeChanged(EventArgs.Empty)
                Invalidate()
            End Set
        End Property

#End Region

        Private ReadOnly _fadeTimer As Timer
        Public Sub New()
            DoubleBuffered = True
            Cursor = Cursors.Default

            SetStyle(
                ControlStyles.UserPaint Or
                ControlStyles.AllPaintingInWmPaint Or
                ControlStyles.OptimizedDoubleBuffer Or
                ControlStyles.ResizeRedraw,
            True)

            Font = SansSerifFont.CreateFont()
            _fadeTimer = New Timer() With {
                .Interval = 15
            }
            AddHandler _fadeTimer.Tick, AddressOf FadeTimer_Tick
        End Sub

#Region "Base Class Override Methods"

        Protected Overrides Sub OnClick(e As EventArgs)
            MyBase.OnClick(e)

            If (_dismissBounds IsNot Nothing AndAlso _mouseLocation IsNot Nothing AndAlso _dismissBounds.Value.Contains(_mouseLocation.Value)) Then
                Dismiss()
            End If
        End Sub

        Protected Overrides Sub OnCreateControl()
            MyBase.OnCreateControl()

            _cornerRadius = CInt(TypographyUtility.CalculateREM(Me) * DEFAULT_RADIUS_IN_REM)
            SetDefaultPadding()
            SetDefaultForeColor()
        End Sub

        Protected Overrides Sub OnMouseLeave(e As EventArgs)
            MyBase.OnMouseLeave(e)
            Cursor = Cursors.Default
            _mouseLocation = Nothing
        End Sub

        Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
            MyBase.OnMouseMove(e)

            _mouseLocation = e.Location
            If (_dismissBounds IsNot Nothing AndAlso _dismissBounds.Value.Contains(_mouseLocation.Value)) Then
                Cursor = Cursors.Hand
            Else
                Cursor = Cursors.Default
            End If
        End Sub

        Private _dismissBounds As RectangleF?
        Private _mouseLocation As Point?
        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            If (Me Is Nothing) Then
                Return
            End If

            Dim deviceContext As Graphics = e.Graphics
            deviceContext.PixelOffsetMode = PixelOffsetMode.HighQuality
            deviceContext.SmoothingMode = SmoothingMode.AntiAlias

            Dim controlBounds As New Rectangle(0, 0, Width, Height)
            Dim bgColor As Color = AlertTheme.BackColor(Me)
            Dim borderColor As Color = AlertTheme.BorderColor(Me)

            Using backBrush As New SolidBrush(If(Parent IsNot Nothing, Parent.BackColor, BackColor))
                deviceContext.FillRectangle(backBrush, ClientRectangle)
            End Using

            Using path As GraphicsPath = WinFormUtility.GetRoundedRectangle(controlBounds, _cornerRadius)
                Dim fadedBackColor As Color = Color.FromArgb(_fadeAlpha, bgColor)
                Using brush As New SolidBrush(fadedBackColor)
                    deviceContext.FillPath(brush, path)
                End Using

                Dim fadedBorderColor As Color = Color.FromArgb(_fadeAlpha, borderColor)
                Using pen As New Pen(fadedBorderColor, 1)
                    deviceContext.DrawPath(pen, path)
                End Using
            End Using

            Dim foreColorUsed As Color = Color.FromArgb(_fadeAlpha, ForeColor)
            Dim contentRectangle As New Rectangle(Padding.Left, Padding.Top, Width - Padding.Left - Padding.Right, Height - Padding.Top - Padding.Bottom)
            If (_showDismiss) Then
                Dim rootEm As Single = CSng(TypographyUtility.CalculateREM(Me))

                Dim buttonSize As Single = rootEm
                Dim marginRight As Single = rootEm
                Dim marginTop As Single = rootEm * 0.75F
                _dismissBounds = New RectangleF(
                    Width - marginRight - buttonSize,
                    marginTop,
                    buttonSize,
                    buttonSize
                )
                Dim dismissBounds As RectangleF = _dismissBounds.Value

                Dim closeButtonPadding As Single = buttonSize * 0.25F
                Using pen As New Pen(foreColorUsed, 2)
                    pen.StartCap = LineCap.Round
                    pen.EndCap = LineCap.Round

                    deviceContext.DrawLine(pen,
                        dismissBounds.Left + closeButtonPadding,
                        dismissBounds.Top + closeButtonPadding,
                        dismissBounds.Right - closeButtonPadding,
                        dismissBounds.Bottom - closeButtonPadding)

                    deviceContext.DrawLine(pen,
                        dismissBounds.Left + closeButtonPadding,
                        dismissBounds.Bottom - closeButtonPadding,
                        dismissBounds.Right - closeButtonPadding,
                        dismissBounds.Top + closeButtonPadding)
                End Using

                contentRectangle.Height -= Convert.ToInt32(dismissBounds.Height)
                contentRectangle.Width -= Convert.ToInt32(dismissBounds.Width)
            End If

            Dim textFormattingFlags As TextFormatFlags = TextFormatFlags.EndEllipsis
            Select Case TextAlign
                Case ContentAlignment.BottomCenter
                    textFormattingFlags = textFormattingFlags Or TextFormatFlags.HorizontalCenter Or TextFormatFlags.Bottom
                Case ContentAlignment.BottomLeft
                    textFormattingFlags = textFormattingFlags Or TextFormatFlags.Left Or TextFormatFlags.Bottom
                Case ContentAlignment.BottomRight
                    textFormattingFlags = textFormattingFlags Or TextFormatFlags.Right Or TextFormatFlags.Bottom
                Case ContentAlignment.MiddleCenter
                    textFormattingFlags = textFormattingFlags Or TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter
                Case ContentAlignment.MiddleLeft
                    textFormattingFlags = textFormattingFlags Or TextFormatFlags.Left Or TextFormatFlags.VerticalCenter
                Case ContentAlignment.MiddleRight
                    textFormattingFlags = textFormattingFlags Or TextFormatFlags.Right Or TextFormatFlags.VerticalCenter
                Case ContentAlignment.TopCenter
                    textFormattingFlags = textFormattingFlags Or TextFormatFlags.HorizontalCenter Or TextFormatFlags.Top
                Case ContentAlignment.TopLeft
                    textFormattingFlags = textFormattingFlags Or TextFormatFlags.Left Or TextFormatFlags.Top
                Case ContentAlignment.TopRight
                    textFormattingFlags = textFormattingFlags Or TextFormatFlags.Right Or TextFormatFlags.Top
            End Select
            TextRenderer.DrawText(
                deviceContext,
                Text,
                Font,
                contentRectangle,
                foreColorUsed,
                textFormattingFlags
            )
        End Sub

        Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
            'Dim bg As Color = If(Parent IsNot Nothing, Parent.BackColor, BackColor)
            'Using b As New SolidBrush(bg)
            '    e.Graphics.FillRectangle(b, ClientRectangle)
            'End Using
        End Sub

        Protected Overrides Sub OnVisibleChanged(e As EventArgs)
            If (Visible AndAlso _isDismissed) Then
                Visible = False
                Return
            Else
                _fadeAlpha = Byte.MaxValue
            End If
            MyBase.OnVisibleChanged(e)
        End Sub

#End Region

#Region "Custom Events"

        Protected Overridable Sub OnAlertVariantChanged(e As EventArgs)
            RaiseEvent AlertVariantChanged(Me, e)
            SetDefaultForeColor()
        End Sub

        Protected Overridable Sub OnCornerRadiusChanged(e As EventArgs)
            RaiseEvent CornerRadiusChanged(Me, e)
        End Sub

        Protected Overridable Sub OnDismissed(e As EventArgs)
            _fadeAlpha = 0
            _isDismissed = True
            Visible = False
            RaiseEvent Dismissed(Me, e)
        End Sub

        Protected Overridable Sub OnIsDismissedChanged(e As EventArgs)
            RaiseEvent IsDismissedChanged(Me, e)
            If (_isDismissed) Then
                OnDismissed(e)
            Else
                Visible = True
            End If
        End Sub

        Protected Overridable Sub OnIsFadableChanged(e As EventArgs)
            RaiseEvent IsFadableChanged(Me, e)
        End Sub

        Protected Overridable Sub OnShowDismissChanged(e As EventArgs)
            RaiseEvent ShowDismissChanged(Me, e)
        End Sub

        Protected Overridable Sub OnTextAlignChanged(e As EventArgs)
            RaiseEvent TextAlignChanged(Me, e)
        End Sub

        Protected Overridable Sub OnThemeModeChanged(e As EventArgs)
            RaiseEvent ThemeModeChanged(Me, e)
        End Sub

        Public Event AlertVariantChanged(sender As Object, e As EventArgs)
        Public Event CornerRadiusChanged(sender As Object, e As EventArgs)
        Public Event Dismissed(sender As Object, e As EventArgs)
        Public Event IsDismissedChanged(sender As Object, e As EventArgs)
        Public Event IsFadableChanged(sender As Object, e As EventArgs)
        Public Event ShowDismissChanged(sender As Object, e As EventArgs)
        Public Event TextAlignChanged(sender As Object, e As EventArgs)
        Public Event ThemeModeChanged(sender As Object, e As EventArgs)

#End Region

#Region "Custom Methods"

        Public Sub Dismiss()
            If (_isDismissed) Then
                Return
            End If
            If (_isFadable) Then
                _fadeStartTime = DateTime.Now
                _fadeTimer.Start()
            Else
                OnDismissed(EventArgs.Empty)
            End If
        End Sub

#End Region

#Region "Fading Mechanics"

        Private _fadeAlpha As Byte = Byte.MaxValue
        Private _fadeStartTime As DateTime
        Private Sub FadeTimer_Tick(sender As Object, e As EventArgs)
            Dim elapsed As Double = (DateTime.Now - _fadeStartTime).TotalMilliseconds
            Dim progress As Double = elapsed / FADE_DURATION
            If (progress >= 1) Then
                _fadeTimer.Stop()
                OnDismissed(EventArgs.Empty)
                Return
            End If

            _fadeAlpha = Convert.ToByte(Byte.MaxValue * (1 - progress))
            Invalidate()
        End Sub

#End Region

        Private Sub SetDefaultPadding()
            Dim fontSize As Double = TypographyUtility.CalculateREM(Me)
            Dim paddingXMultiplier As Double = DEFAULT_PADDING_X_IN_REM
            Dim paddingYMultiplier As Double = DEFAULT_PADDING_Y_IN_REM
            Dim paddingX As Integer = Convert.ToInt32(fontSize * paddingXMultiplier)
            Dim paddingY As Integer = Convert.ToInt32(fontSize * paddingYMultiplier)
            Padding = New Padding(paddingX, paddingY, paddingX, paddingY)
        End Sub

        Private Sub SetDefaultForeColor()
            ForeColor = AlertTheme.ForeColor(Me)
        End Sub

    End Class
End Namespace
