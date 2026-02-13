Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows
Imports System.Windows.Forms
Imports WinFormsBootstrap.Utilities.Colors
Imports WinFormsBootstrap.Utilities.Typography

Namespace Components.Button
    Public Class Button
        Inherits Forms.Button

#Region "Constants"

        Private Const DEFAULT_PADDING_X_IN_REM As Double = 0.75
        Private Const DEFAULT_PADDING_Y_IN_REM As Double = 0.375
        Private Const DEFAULT_PADDING_X_LARGE_IN_REM As Double = 1
        Private Const DEFAULT_PADDING_Y_LARGE_IN_REM As Double = 0.5
        Private Const DEFAULT_PADDING_X_SMALL_IN_REM As Double = 0.5
        Private Const DEFAULT_PADDING_Y_SMALL_IN_REM As Double = 0.25
        Private Const DEFAULT_RADIUS_IN_REM As Double = 0.375

#End Region

#Region "Property Variables"

        Private _buttonSize As ButtonSizes = ButtonSizes.Default
        Private _buttonStyle As ButtonStyles = ButtonStyles.Solid
        Private _buttonVariant As ButtonVariants? = Nothing
        Private _cornerRadius As Integer = 0
        Private _themeMode As ThemeModes = ThemeModes.LightTheme
        Private _isHovering As Boolean
        Private _isPressing As Boolean

#End Region

#Region "Properties"

        Public Property ButtonSize As ButtonSizes
            Get
                Return _buttonSize
            End Get
            Set(value As ButtonSizes)
                _buttonSize = value
                OnButtonSizeChanged(EventArgs.Empty)
                Invalidate()
            End Set
        End Property

        Public Property ButtonStyle As ButtonStyles
            Get
                Return _buttonStyle
            End Get
            Set(value As ButtonStyles)
                _buttonStyle = value
                OnButtonStyleChanged(EventArgs.Empty)
                Invalidate()
            End Set
        End Property

        Public Property ButtonVariant As ButtonVariants?
            Get
                Return _buttonVariant
            End Get
            Set(value As ButtonVariants?)
                _buttonVariant = value
                OnButtonVariantChanged(EventArgs.Empty)
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

        Public ReadOnly Property IsHovering As Boolean
            Get
                Return _isHovering
            End Get
        End Property

        Public ReadOnly Property IsPressing As Boolean
            Get
                Return _isPressing
            End Get
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

        Public Sub New()
            FlatStyle = FlatStyle.Flat
            FlatAppearance.BorderSize = 0
            FlatAppearance.MouseDownBackColor = Color.Transparent
            FlatAppearance.MouseOverBackColor = Color.Transparent
            UseVisualStyleBackColor = False
            DoubleBuffered = True
            Cursor = Cursors.Hand

            SetStyle(
                ControlStyles.UserPaint Or
                ControlStyles.AllPaintingInWmPaint Or
                ControlStyles.OptimizedDoubleBuffer Or
                ControlStyles.ResizeRedraw,
            True)

            Font = SansSerifFont.CreateFont()
        End Sub

#Region "Base Class Override Methods"

        Protected Overrides Sub OnCreateControl()
            MyBase.OnCreateControl()

            _cornerRadius = CInt(TypographyUtility.CalculateREM(Me) * DEFAULT_RADIUS_IN_REM)
            ButtonSizeUpdate()
        End Sub

        Protected Overrides Sub OnMouseEnter(e As EventArgs)
            MyBase.OnMouseEnter(e)
            _isHovering = True
            Invalidate()
        End Sub

        Protected Overrides Sub OnMouseLeave(e As EventArgs)
            MyBase.OnMouseLeave(e)
            _isHovering = False
            _isPressing = False
            Invalidate()
        End Sub

        Protected Overrides Sub OnMouseDown(mevent As MouseEventArgs)
            MyBase.OnMouseDown(mevent)
            _isPressing = True
            Invalidate()
        End Sub

        Protected Overrides Sub OnMouseUp(mevent As MouseEventArgs)
            MyBase.OnMouseUp(mevent)
            _isPressing = False
            Invalidate()
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            If (Me Is Nothing) Then
                Return
            End If

            Dim deviceContext As Graphics = e.Graphics
            deviceContext.PixelOffsetMode = PixelOffsetMode.HighQuality
            deviceContext.SmoothingMode = SmoothingMode.AntiAlias

            Dim controlBounds As New Rectangle(0, 0, Width, Height)
            Dim bgColor As Color = ButtonTheme.BackColor(Me)
            Dim borderColor As Color = ButtonTheme.BorderColor(Me)
            Dim foreColor As Color = ButtonTheme.ForeColor(Me)

            Using backBrush As New SolidBrush(If(Parent IsNot Nothing, Parent.BackColor, BackColor))
                deviceContext.FillRectangle(backBrush, ClientRectangle)
            End Using

            Using path As GraphicsPath = WinFormUtility.GetRoundedRectangle(controlBounds, _cornerRadius)
                Using brush As New SolidBrush(bgColor)
                    deviceContext.FillPath(brush, path)
                End Using

                Using pen As New Pen(borderColor, 1)
                    deviceContext.DrawPath(pen, path)
                End Using
            End Using

            Dim textRect As Rectangle = Rectangle.FromLTRB(
                Padding.Left,
                Padding.Top,
                Width - Padding.Right,
                Height - Padding.Bottom
            )
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
                textRect,
                foreColor,
                textFormattingFlags
            )
        End Sub

        Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
            Dim bg As Color = If(Parent IsNot Nothing, Parent.BackColor, BackColor)
            Using b As New SolidBrush(bg)
                e.Graphics.FillRectangle(b, ClientRectangle)
            End Using
        End Sub

#End Region

#Region "Custom Events"

        Protected Overridable Sub OnButtonSizeChanged(e As EventArgs)
            ButtonSizeUpdate()
            RaiseEvent ButtonSizeChanged(Me, e)
        End Sub

        Protected Overridable Sub OnButtonStyleChanged(e As EventArgs)
            RaiseEvent ButtonStyleChanged(Me, e)
        End Sub

        Protected Overridable Sub OnButtonVariantChanged(e As EventArgs)
            RaiseEvent ButtonVariantChanged(Me, e)
        End Sub

        Protected Overridable Sub OnCornerRadiusChanged(e As EventArgs)
            RaiseEvent CornerRadiusChanged(Me, e)
        End Sub

        Protected Overridable Sub OnThemeModeChanged(e As EventArgs)
            RaiseEvent ThemeModeChanged(Me, e)
        End Sub

        Public Event ButtonSizeChanged(sender As Object, e As EventArgs)
        Public Event ButtonStyleChanged(sender As Object, e As EventArgs)
        Public Event ButtonVariantChanged(sender As Object, e As EventArgs)
        Public Event CornerRadiusChanged(sender As Object, e As EventArgs)
        Public Event ThemeModeChanged(sender As Object, e As EventArgs)

#End Region

        Private Sub ButtonSizeUpdate()
            Dim fontSize As Integer = TypographyUtility.DEFAULT_FONT_SIZE_IN_PX
            Dim paddingXMultiplier As Double = DEFAULT_PADDING_X_IN_REM
            Dim paddingYMultiplier As Double = DEFAULT_PADDING_Y_IN_REM

            If (_buttonSize.Equals(ButtonSizes.Small)) Then
                fontSize = Convert.ToInt32(fontSize * 0.875)
                paddingXMultiplier = DEFAULT_PADDING_X_SMALL_IN_REM
                paddingYMultiplier = DEFAULT_PADDING_Y_SMALL_IN_REM
            ElseIf (_buttonSize.Equals(ButtonSizes.Large)) Then
                fontSize = Convert.ToInt32(fontSize * 1.25)
                paddingXMultiplier = DEFAULT_PADDING_X_LARGE_IN_REM
                paddingYMultiplier = DEFAULT_PADDING_Y_LARGE_IN_REM
            End If

            Font = New Font(Font.FontFamily, fontSize, Font.Style, GraphicsUnit.Pixel)

            Dim paddingX As Integer = Convert.ToInt32(fontSize * paddingXMultiplier)
            Dim paddingY As Integer = Convert.ToInt32(fontSize * paddingYMultiplier)
            Padding = New Padding(paddingX, paddingY, paddingX, paddingY)

            Dim textSize As Size = TextRenderer.MeasureText(
                "Ag",
                Font,
                New Size(Integer.MaxValue, Integer.MaxValue),
                TextFormatFlags.SingleLine
            )

            Dim minimumHeight As Integer = textSize.Height + (paddingY * 2)
            Size = New Size(Width, minimumHeight)
        End Sub

    End Class
End Namespace
