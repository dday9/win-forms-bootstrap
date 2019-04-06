Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.Runtime.InteropServices
Imports System.Windows
Namespace Bootstrap

    Namespace Control

        Public Class Control
            Inherits Forms.Control

            Private _borderColor As Color
            Public Property BorderColor() As Color
                Get
                    Return _borderColor
                End Get
                Set(ByVal value As Color)
                    If _borderColor <> value Then
                        _borderColor = value
                        Me.OnBorderColorChanged()
                    End If
                End Set
            End Property

            Private _drawBorder As Boolean
            Public Property DrawBorder() As Boolean
                Get
                    Return _drawBorder
                End Get
                Set(ByVal value As Boolean)
                    If _drawBorder <> value Then
                        _drawBorder = value
                        Me.OnDrawBorderChanged()
                    End If
                End Set
            End Property

            Protected Overridable Sub OnBorderColorChanged()
                RaiseEvent BorderColorChanged(Me, EventArgs.Empty)
            End Sub

            Protected Overridable Sub OnDrawBorderChanged()
                RaiseEvent DrawBorderChanged(Me, EventArgs.Empty)
            End Sub

            Public Event BorderColorChanged(ByVal sender As Object, ByVal e As EventArgs)
            Public Event DrawBorderChanged(ByVal sender As Object, ByVal e As EventArgs)

            Private Sub Control_BorderPropertiesChanged(sender As Object, e As EventArgs) Handles Me.BorderColorChanged, Me.DrawBorderChanged
                Me.Invalidate(True)
            End Sub

            <DllImport("gdi32.dll")>
            Public Shared Function CreateRoundRectRgn(ByVal x1 As Integer, ByVal y1 As Integer, ByVal width As Integer, ByVal height As Integer, ByVal cx As Integer, ByVal cy As Integer) As IntPtr
            End Function

            Public Sub New()
                Me.Font = Bootstrap.Utilities.Typography.Font

                Me.Region = Region.FromHrgn(Bootstrap.Control.Control.CreateRoundRectRgn(0, 0, Me.Width, Me.Height, Convert.ToInt32(Bootstrap.Utilities.Typography.CalculateEM(Me.Font) * 0.25), Convert.ToInt32(Bootstrap.Utilities.Typography.CalculateEM(Me.Font) * 0.25)))

                Me.BackColor = Bootstrap.Utilities.Color.BackgroundLight
                Me.ForeColor = Bootstrap.Utilities.Color.TextBody

                Me.Padding = New Padding(Convert.ToInt32(Bootstrap.Utilities.Typography.CalculateEM(Me.Font) * 0.75 * 72 / 96), Convert.ToInt32(Bootstrap.Utilities.Typography.CalculateEM(Me.Font) * 1.25 * 72 / 96), Convert.ToInt32(Bootstrap.Utilities.Typography.CalculateEM(Me.Font) * 0.75 * 72 / 96), Convert.ToInt32(Bootstrap.Utilities.Typography.CalculateEM(Me.Font) * 1.25 * 72 / 96))

                Me.BorderColor = Me.BackColor
                Me.DrawBorder = False
            End Sub

            Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
                MyBase.OnPaint(e)

                Dim radius As Integer = Convert.ToInt32(Bootstrap.Utilities.Typography.CalculateEM(Me.Font) * 0.25)
                Dim area As Rectangle = Me.DisplayRectangle
                Dim path As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath

                area.Width -= 2
                area.Height -= 2

                path.AddArc(area.Left, area.Top, radius * 2, radius * 2, 180, 90) 'Upper-Left
                path.AddArc(area.Right - (radius * 2), area.Top, radius * 2, radius * 2, 270, 90) 'Upper-Right
                path.AddArc(area.Right - (radius * 2), area.Bottom - (radius * 2), radius * 2, radius * 2, 0, 90) 'Lower-Right
                path.AddArc(area.Left, area.Bottom - (radius * 2), radius * 2, radius * 2, 90, 90) 'Lower-Left
                path.CloseAllFigures()

                Using pen As Pen = New Pen(_borderColor, 1)
                    e.Graphics.DrawPath(pen, path)
                End Using
            End Sub

            Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
                MyBase.OnSizeChanged(e)

                Me.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Me.Width, Me.Height, Convert.ToInt32(Bootstrap.Utilities.Typography.CalculateEM(Me.Font) * 0.25), Convert.ToInt32(Bootstrap.Utilities.Typography.CalculateEM(Me.Font) * 0.25)))
            End Sub
        End Class

        <DefaultEvent("IsDismissedChanged")>
        Public Class Alert
            Inherits Bootstrap.Control.Control

            Public Enum StyleType
                Danger
                Dark
                Info
                Light
                Primary
                Secondary
                Success
                Warning
            End Enum

            Private _dismissable As Boolean
            Public Property Dismissable As Boolean
                Get
                    Return _dismissable
                End Get
                Set(ByVal value As Boolean)
                    If _dismissable <> value Then
                        _dismissable = value
                        Me.OnDismissableChanged()
                    End If
                End Set
            End Property

            Private _fadable As Boolean
            Public Property Fadable() As Boolean
                Get
                    Return _fadable
                End Get
                Set(ByVal value As Boolean)
                    _fadable = value
                End Set
            End Property

            Private _isDismissed As Boolean
            Public Property IsDismissed As Boolean
                Get
                    Return _isDismissed
                End Get
                Set(ByVal value As Boolean)
                    If Not _isDismissed.Equals(value) Then
                        _isDismissed = value
                        Me.OnIsDismissedChanged()
                    End If
                End Set
            End Property

            Private _style As StyleType
            Public Property Style As StyleType
                Get
                    Return _style
                End Get
                Set(ByVal value As StyleType)
                    If _style <> value Then
                        _style = value
                        Me.OnStyleChanged()
                    End If
                End Set
            End Property

            Protected Overridable Sub OnDismissableChanged()
                RaiseEvent DismissableChanged(Me, EventArgs.Empty)
            End Sub

            Protected Overridable Sub OnIsDismissedChanged()
                RaiseEvent IsDismissedChanged(Me, EventArgs.Empty)
            End Sub

            Protected Overridable Shadows Sub OnStyleChanged()
                RaiseEvent StyleChanged(Me, EventArgs.Empty)
            End Sub

            Public Event IsDismissedChanged(ByVal sender As Object, ByVal e As EventArgs)

            Public Event DismissableChanged(ByVal sender As Object, ByVal e As EventArgs)

            Public Shadows Event StyleChanged(ByVal sender As Object, ByVal e As EventArgs)

            'Key: Style, Value: -> Key: BackgroundColor Value: Forecolor
            Private styleConfiguration As Dictionary(Of Alert.StyleType, KeyValuePair(Of Drawing.Color, Drawing.Color))

            Public Sub New()
                MyBase.New()
                styleConfiguration = New Dictionary(Of StyleType, KeyValuePair(Of Color, Color))
                styleConfiguration.Add(Alert.StyleType.Danger, New KeyValuePair(Of Drawing.Color, Drawing.Color)(Drawing.Color.FromArgb(248, 215, 218), Drawing.Color.FromArgb(114, 28, 36)))
                styleConfiguration.Add(Alert.StyleType.Dark, New KeyValuePair(Of Drawing.Color, Drawing.Color)(Drawing.Color.FromArgb(198, 200, 202), Drawing.Color.FromArgb(27, 30, 33)))
                styleConfiguration.Add(Alert.StyleType.Info, New KeyValuePair(Of Drawing.Color, Drawing.Color)(Drawing.Color.FromArgb(209, 236, 241), Drawing.Color.FromArgb(12, 84, 96)))
                styleConfiguration.Add(Alert.StyleType.Light, New KeyValuePair(Of Drawing.Color, Drawing.Color)(Drawing.Color.FromArgb(254, 254, 254), Drawing.Color.FromArgb(129, 129, 130)))
                styleConfiguration.Add(Alert.StyleType.Primary, New KeyValuePair(Of Drawing.Color, Drawing.Color)(Drawing.Color.FromArgb(204, 229, 255), Drawing.Color.FromArgb(0, 64, 133)))
                styleConfiguration.Add(Alert.StyleType.Secondary, New KeyValuePair(Of Drawing.Color, Drawing.Color)(Drawing.Color.FromArgb(226, 227, 229), Drawing.Color.FromArgb(56, 61, 65)))
                styleConfiguration.Add(Alert.StyleType.Success, New KeyValuePair(Of Drawing.Color, Drawing.Color)(Drawing.Color.FromArgb(212, 237, 218), Drawing.Color.FromArgb(21, 87, 36)))
                styleConfiguration.Add(Alert.StyleType.Warning, New KeyValuePair(Of Drawing.Color, Drawing.Color)(Drawing.Color.FromArgb(255, 243, 205), Drawing.Color.FromArgb(133, 100, 4)))

                With Me
                    .SetStyle(ControlStyles.SupportsTransparentBackColor, True)
                    .Dismissable = False
                    .DoubleBuffered = True
                    .Fadable = False
                    .Style = StyleType.Primary
                End With
            End Sub

            Private Sub Alert_DismissableChanged(sender As Object, e As EventArgs) Handles Me.DismissableChanged
                Me.Invalidate(True)
            End Sub

            Private Sub Alert_IsDismissedChanged(sender As Object, e As EventArgs) Handles Me.IsDismissedChanged
                Me.Dispose(True)
            End Sub

            Protected Overrides Sub OnMouseClick(ByVal e As MouseEventArgs)
                MyBase.OnMouseClick(e)

                If Me.Dismissable AndAlso e.Button = MouseButtons.Left AndAlso Me.MouseOverDismiss(e.X, e.Y) Then
                    Me.Dismiss()
                End If
            End Sub

            Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
                MyBase.OnMouseMove(e)

                If Me.Dismissable AndAlso Me.MouseOverDismiss(e.X, e.Y) Then
                    Me.Cursor = Cursors.Hand
                Else
                    Me.Cursor = Cursors.Default
                End If
            End Sub

            Protected Overrides Sub OnPaddingChanged(ByVal e As EventArgs)
                MyBase.OnPaddingChanged(e)

                Me.Invalidate(True)
            End Sub

            Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
                Dim paddingTop As Integer = Me.Padding.Top
                Dim paddingRight As Integer = Me.Padding.Right
                If Me.Dismissable Then
                    Using dismissBrush As Brush = New SolidBrush(styleConfiguration(Me.Style).Value)
                        e.Graphics.DrawString(Bootstrap.Utilities.Typography.Close, Bootstrap.Utilities.Typography.Font, dismissBrush, New Point(Me.Width - Convert.ToInt32(Bootstrap.Utilities.Typography.CalculateEM(Me.Font)) - 5, 5))
                        Dim dismissSize As SizeF = e.Graphics.MeasureString(Bootstrap.Utilities.Typography.Close, Bootstrap.Utilities.Typography.Font)
                        If dismissSize.Height + 5 > paddingTop Then
                            paddingTop = Convert.ToInt32(dismissSize.Height) + 5
                        End If
                        If dismissSize.Width + 5 > paddingRight Then
                            paddingRight = Convert.ToInt32(dismissSize.Width) + 5
                        End If
                    End Using
                End If

                Dim textBounds As Rectangle = Me.DisplayRectangle
                textBounds.Y += Me.Padding.Top
                textBounds.X += Me.Padding.Left
                textBounds.Width -= (paddingRight + Me.Padding.Right + Me.Padding.Left)
                textBounds.Height -= (Me.Padding.Bottom + Me.Padding.Top)

                TextRenderer.DrawText(e.Graphics, Me.Text, Me.Font, textBounds, Me.ForeColor, TextFormatFlags.NoPadding Or TextFormatFlags.Top Or TextFormatFlags.WordBreak)

                MyBase.OnPaint(e)
            End Sub

            Private Sub Alert_StyleChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Me.StyleChanged
                With styleConfiguration(Me.Style)
                    Me.BackColor = .Key
                    Me.BorderColor = .Key
                    Me.ForeColor = .Value
                End With
                Me.Invalidate(True)
            End Sub

            Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
                MyBase.OnTextChanged(e)

                Me.Invalidate(True)
            End Sub

            Public Async Sub Dismiss()
                If Me.Fadable Then
                    Await Task.Run(Sub()
                                       Me.SuspendLayout()
                                       Do
                                           Me.BackColor = Color.FromArgb(Me.BackColor.A - 1, Me.BackColor.R, Me.BackColor.G, Me.BackColor.B)
                                           Threading.Thread.Sleep(Byte.MaxValue \ 150)
                                       Loop Until Me.BackColor.A = 0
                                       Me.ResumeLayout()
                                   End Sub)
                End If
                Me.IsDismissed = Me.Dismissable AndAlso Not Me.IsDismissed
            End Sub

            Private Function MouseOverDismiss(ByVal mouseX As Integer, ByVal mouseY As Integer) As Boolean
                Dim closeDimensions As SizeF = New SizeF(0, 0)

                Using closeGraphics As Graphics = Graphics.FromHwnd(Me.Handle)
                    closeDimensions = closeGraphics.MeasureString(Bootstrap.Utilities.Typography.Close, Me.Font)
                End Using

                Return mouseX > Me.Width - closeDimensions.Width AndAlso mouseY < closeDimensions.Height + 5
            End Function

            Public Shared Function ShowDialog(ByVal text As String) As DialogResult
                Return Bootstrap.Control.Alert.ShowDialog(text, Bootstrap.Control.Alert.StyleType.Primary, False)
            End Function

            Public Shared Function ShowDialog(ByVal text As String, ByVal style As Bootstrap.Control.Alert.StyleType) As DialogResult
                Return Bootstrap.Control.Alert.ShowDialog(text, style, False)
            End Function

            Public Shared Function ShowDialog(ByVal text As String, ByVal style As Bootstrap.Control.Alert.StyleType, ByVal fade As Boolean) As DialogResult
                Dim modalResult As DialogResult

                Using modal As Form = New Form()
                    Dim _alert As Bootstrap.Control.Alert = New Bootstrap.Control.Alert()
                    With _alert
                        .Dismissable = True
                        .Dock = DockStyle.Fill
                        .Fadable = fade
                        .Style = style
                        .Text = text

                        AddHandler .IsDismissedChanged, Sub(ByVal sender As Object, ByVal e As EventArgs)
                                                            modal.DialogResult = DialogResult.OK
                                                            modal.Close()
                                                        End Sub
                    End With

                    With modal
                        .Controls.Add(_alert)
                        .FormBorderStyle = FormBorderStyle.None
                        .Size = New Size(300, 100)
                        .StartPosition = FormStartPosition.CenterParent

                        AddHandler .Load, Sub(ByVal sender As Object, ByVal e As EventArgs)
                                              modal.Region = Region.FromHrgn(Bootstrap.Control.Control.CreateRoundRectRgn(0, 0, modal.Width, modal.Height, Convert.ToInt32(Bootstrap.Utilities.Typography.CalculateEM(_alert) * 0.25), Convert.ToInt32(Bootstrap.Utilities.Typography.CalculateEM(_alert) * 0.25)))
                                          End Sub
                    End With

                    modalResult = modal.ShowDialog()
                End Using

                Return modalResult
            End Function

        End Class

        <DefaultEvent("Click")>
        Public Class Button
            Inherits Bootstrap.Control.Control

            Public Enum StyleType
                Danger
                Dark
                Info
                Light
                Primary
                Secondary
                Success
                Warning
            End Enum

            Private _isOutline As Boolean
            Public Property IsOutline As Boolean
                Get
                    Return _isOutline
                End Get
                Set(ByVal value As Boolean)
                    If Not _isOutline.Equals(value) Then
                        _isOutline = value
                        Me.OnIsOutlineChanged()
                    End If
                End Set
            End Property

            Private _style As StyleType
            Public Property Style As StyleType
                Get
                    Return _style
                End Get
                Set(ByVal value As StyleType)
                    If _style <> value Then
                        _style = value
                        Me.OnStyleChanged()
                    End If
                End Set
            End Property

            Protected Overridable Sub OnIsOutlineChanged()
                RaiseEvent IsOutlineChanged(Me, EventArgs.Empty)
            End Sub

            Protected Overridable Shadows Sub OnStyleChanged()
                RaiseEvent StyleChanged(Me, EventArgs.Empty)
            End Sub

            Public Event IsOutlineChanged(ByVal sender As Object, ByVal e As EventArgs)

            Public Shadows Event StyleChanged(ByVal sender As Object, ByVal e As EventArgs)

            'Key: Style, Value: -> Key: BackgroundColor Value: Forecolor
            Private styleConfiguration As Dictionary(Of StyleType, KeyValuePair(Of Color, Color))

            'Key: Style, Value: -> Key: MouseEnter (hover) Value: MouseDown (active)
            Private styleConfigurationMouseEvents As Dictionary(Of StyleType, KeyValuePair(Of Color, Color))
            Sub New()
                styleConfiguration = New Dictionary(Of StyleType, KeyValuePair(Of Color, Color))
                styleConfiguration.Add(Button.StyleType.Danger, New KeyValuePair(Of Drawing.Color, Drawing.Color)(Bootstrap.Utilities.BackgroundDanger, Bootstrap.Utilities.TextWhite))
                styleConfiguration.Add(Button.StyleType.Dark, New KeyValuePair(Of Drawing.Color, Drawing.Color)(Bootstrap.Utilities.BackgroundDark, Bootstrap.Utilities.TextWhite))
                styleConfiguration.Add(Button.StyleType.Info, New KeyValuePair(Of Drawing.Color, Drawing.Color)(Bootstrap.Utilities.BackgroundInfo, Bootstrap.Utilities.TextWhite))
                styleConfiguration.Add(Button.StyleType.Light, New KeyValuePair(Of Drawing.Color, Drawing.Color)(Bootstrap.Utilities.BackgroundLight, Bootstrap.Utilities.TextBody))
                styleConfiguration.Add(Button.StyleType.Primary, New KeyValuePair(Of Drawing.Color, Drawing.Color)(Bootstrap.Utilities.BackgroundPrimary, Bootstrap.Utilities.TextWhite))
                styleConfiguration.Add(Button.StyleType.Secondary, New KeyValuePair(Of Drawing.Color, Drawing.Color)(Bootstrap.Utilities.BackgroundSecondary, Bootstrap.Utilities.TextWhite))
                styleConfiguration.Add(Button.StyleType.Success, New KeyValuePair(Of Drawing.Color, Drawing.Color)(Bootstrap.Utilities.BackgroundSuccess, Bootstrap.Utilities.TextWhite))
                styleConfiguration.Add(Button.StyleType.Warning, New KeyValuePair(Of Drawing.Color, Drawing.Color)(Bootstrap.Utilities.BackgroundWarning, Bootstrap.Utilities.TextBody))

                styleConfigurationMouseEvents = New Dictionary(Of StyleType, KeyValuePair(Of Color, Color))
                styleConfigurationMouseEvents.Add(Button.StyleType.Danger, New KeyValuePair(Of Drawing.Color, Drawing.Color)(Bootstrap.Utilities.HoverBackgroundDanger, Bootstrap.Utilities.ActiveBackgroundDanger))
                styleConfigurationMouseEvents.Add(Button.StyleType.Dark, New KeyValuePair(Of Drawing.Color, Drawing.Color)(Bootstrap.Utilities.HoverBackgroundDark, Bootstrap.Utilities.ActiveBackgroundDark))
                styleConfigurationMouseEvents.Add(Button.StyleType.Info, New KeyValuePair(Of Drawing.Color, Drawing.Color)(Bootstrap.Utilities.HoverBackgroundInfo, Bootstrap.Utilities.ActiveBackgroundInfo))
                styleConfigurationMouseEvents.Add(Button.StyleType.Light, New KeyValuePair(Of Drawing.Color, Drawing.Color)(Bootstrap.Utilities.HoverBackgroundLight, Bootstrap.Utilities.ActiveBackgroundLight))
                styleConfigurationMouseEvents.Add(Button.StyleType.Primary, New KeyValuePair(Of Drawing.Color, Drawing.Color)(Bootstrap.Utilities.HoverBackgroundPrimary, Bootstrap.Utilities.ActiveBackgroundPrimary))
                styleConfigurationMouseEvents.Add(Button.StyleType.Secondary, New KeyValuePair(Of Drawing.Color, Drawing.Color)(Bootstrap.Utilities.HoverBackgroundSecondary, Bootstrap.Utilities.ActiveBackgroundSecondary))
                styleConfigurationMouseEvents.Add(Button.StyleType.Success, New KeyValuePair(Of Drawing.Color, Drawing.Color)(Bootstrap.Utilities.HoverBackgroundSuccess, Bootstrap.Utilities.ActiveBackgroundSuccess))
                styleConfigurationMouseEvents.Add(Button.StyleType.Warning, New KeyValuePair(Of Drawing.Color, Drawing.Color)(Bootstrap.Utilities.HoverBackgroundWarning, Bootstrap.Utilities.ActiveBackgroundWarning))

                With Me
                    .SetStyle(ControlStyles.SupportsTransparentBackColor, True)
                    Me.Style = StyleType.Primary
                End With
            End Sub

            Protected Overrides Sub OnEnabledChanged(ByVal e As EventArgs)
                MyBase.OnEnabledChanged(e)

                Me.Invalidate(True)
            End Sub

            Private mouseDowned As Boolean = False
            Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
                MyBase.OnMouseDown(e)
                mouseDowned = True : Me.Invalidate(True)
            End Sub

            Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
                MyBase.OnMouseDown(e)
                mouseDowned = False : Me.Invalidate(True)
            End Sub

            Private mouseEntered As Boolean = False
            Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
                MyBase.OnMouseEnter(e)
                mouseEntered = True : Me.Invalidate(True)
            End Sub

            Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
                MyBase.OnMouseLeave(e)
                mouseEntered = False : Me.Invalidate(True)
            End Sub

            Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
                Dim textColor As Color = Me.ForeColor
                Dim backColor As Color = Me.BackColor

                If _isOutline Then
                    backColor = Color.FromArgb(Bootstrap.Utilities.Color.BackgroundWhite.R, Bootstrap.Utilities.Color.BackgroundWhite.G, Bootstrap.Utilities.Color.BackgroundWhite.B)
                ElseIf _isOutline AndAlso Not mouseDowned AndAlso Not mouseEntered Then
                    backColor = Bootstrap.Utilities.Color.BackgroundWhite
                ElseIf Not Me.Enabled Then
                    backColor = Color.FromArgb(Convert.ToInt32(Byte.MaxValue * 0.65), backColor.R, backColor.G, backColor.B)
                ElseIf mouseDowned Then
                    backColor = styleConfigurationMouseEvents(_style).Value
                ElseIf mouseEntered Then
                    backColor = styleConfigurationMouseEvents(_style).Key
                End If

                If _isOutline Then
                    textColor = styleConfiguration(_style).Key
                End If

                If _isOutline AndAlso (mouseDowned OrElse mouseEntered) Then
                    backColor = styleConfiguration(_style).Key
                    textColor = Bootstrap.Utilities.Color.TextWhite
                    If _style = StyleType.Warning OrElse _style = StyleType.Light Then
                        textColor = Bootstrap.Utilities.Color.TextBody
                    End If
                End If

                e.Graphics.Clear(backColor)

                TextRenderer.DrawText(e.Graphics, Me.Text, Me.Font, Me.DisplayRectangle, textColor, TextFormatFlags.VerticalCenter Or TextFormatFlags.HorizontalCenter)

                MyBase.OnPaint(e)
            End Sub

            Private Sub Button_StyleChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Me.StyleChanged
                With styleConfiguration(Me.Style)
                    Me.BackColor = .Key
                    Me.BorderColor = .Key
                    Me.ForeColor = .Value
                End With
                Me.Invalidate(True)
            End Sub

        End Class

        <DefaultEvent("CheckedChanged")>
        Public Class ToggleSwitch
            Inherits Bootstrap.Control.Control

            Private _checked As Boolean
            Public Property Checked() As Boolean
                Get
                    Return _checked
                End Get
                Set(ByVal value As Boolean)
                    If _checked <> value Then
                        _checked = value
                        Me.OnCheckedChanged()
                    End If
                End Set
            End Property

            Private _falseColor As Color
            Public Property FalseColor() As Color
                Get
                    Return _falseColor
                End Get
                Set(ByVal value As Color)
                    If _falseColor <> value Then
                        _falseColor = value
                        Me.OnFalseColorChanged()
                    End If
                End Set
            End Property

            Private _falseText As String
            Public Property FalseText() As String
                Get
                    Return _falseText
                End Get
                Set(ByVal value As String)
                    If _falseText <> value Then
                        _falseText = value
                        Me.OnFalseTextChanged()
                    End If
                End Set
            End Property

            Private _trueColor As Color
            Public Property TrueColor() As Color
                Get
                    Return _trueColor
                End Get
                Set(ByVal value As Color)
                    If _trueColor <> value Then
                        _trueColor = value
                        Me.OnTrueColorChanged()
                    End If
                End Set
            End Property

            Private _trueText As String
            Public Property TrueText() As String
                Get
                    Return _trueText
                End Get
                Set(ByVal value As String)
                    If _trueText <> value Then
                        _trueText = value
                        Me.OnTrueTextChanged()
                    End If
                End Set
            End Property

            Protected Overridable Sub OnCheckedChanged()
                Me.Invalidate(True)
                RaiseEvent CheckedChanged(Me, EventArgs.Empty)
            End Sub

            Protected Overridable Sub OnFalseColorChanged()
                Me.Invalidate(True)
                RaiseEvent FalseColorChanged(Me, EventArgs.Empty)
            End Sub

            Protected Overridable Sub OnFalseTextChanged()
                Me.Invalidate(True)
                RaiseEvent FalseTextChanged(Me, EventArgs.Empty)
            End Sub

            Protected Overridable Sub OnTrueColorChanged()
                Me.Invalidate(True)
                RaiseEvent TrueColorChanged(Me, EventArgs.Empty)
            End Sub

            Protected Overridable Sub OnTrueTextChanged()
                Me.Invalidate(True)
                RaiseEvent TrueTextChanged(Me, EventArgs.Empty)
            End Sub

            Public Event CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            Public Event FalseColorChanged(ByVal sender As Object, ByVal e As EventArgs)
            Public Event FalseTextChanged(ByVal sender As Object, ByVal e As EventArgs)
            Public Event TrueColorChanged(ByVal sender As Object, ByVal e As EventArgs)
            Public Event TrueTextChanged(ByVal sender As Object, ByVal e As EventArgs)

            Sub New()
                Me.BorderColor = Bootstrap.Utilities.Color.TextBody
                Me.ForeColor = Bootstrap.Utilities.Color.TextWhite
                _checked = True
                _falseColor = Bootstrap.Utilities.Color.BackgroundDanger
                _falseText = "Off"
                _trueColor = Bootstrap.Utilities.Color.BackgroundSuccess
                _trueText = "On"
            End Sub

            Protected Overrides Sub OnMouseClick(ByVal e As MouseEventArgs)
                MyBase.OnMouseClick(e)

                _checked = Not _checked
                Me.Invalidate(True)
            End Sub

            Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
                MyBase.OnMouseMove(e)

                Dim halfControlWidth As Integer = Convert.ToInt32(Me.Width / 2)
                If (_checked AndAlso e.X > halfControlWidth) OrElse (Not _checked AndAlso e.X < halfControlWidth) Then
                    Me.Cursor = Cursors.Hand
                Else
                    Me.Cursor = Cursors.Default
                End If
            End Sub

            Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
                MyBase.OnPaint(e)

                Dim halfControlWidth As Integer = Convert.ToInt32(Me.Width / 2)
                Dim sliderRectangle As Rectangle = New Rectangle(If(Not _checked, halfControlWidth, 0), 0, halfControlWidth, Me.Height)
                Using sliderBorderBrush As Brush = New SolidBrush(Bootstrap.Utilities.Color.BackgroundLight)
                    e.Graphics.FillRectangle(sliderBorderBrush, sliderRectangle)
                End Using

                sliderRectangle.Y += 1
                sliderRectangle.Height -= 4
                Using sliderBackgroundBrush As Brush = New SolidBrush(If(_checked, _trueColor, _falseColor))
                    e.Graphics.FillRectangle(sliderBackgroundBrush, sliderRectangle)
                End Using

                Using toggleBorderPen As Pen = New Pen(Me.BorderColor, 1)
                    e.Graphics.DrawLine(toggleBorderPen, New Point(halfControlWidth, 0), New Point(halfControlWidth, Me.Height))
                End Using

                TextRenderer.DrawText(e.Graphics, If(_checked, _trueText, _falseText), Me.Font, Me.DisplayRectangle, Me.ForeColor, TextFormatFlags.LeftAndRightPadding Or TextFormatFlags.VerticalCenter Or If(_checked, TextFormatFlags.Left, TextFormatFlags.Right))

            End Sub

            Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
                MyBase.OnSizeChanged(e)
                Me.Invalidate(True)
            End Sub

        End Class

    End Namespace

    Namespace Utilities

        Public Module Color

            Public Function ActiveBackgroundDanger() As Drawing.Color
                Return Drawing.Color.FromArgb(189, 33, 48)
            End Function

            Public Function ActiveBackgroundDark() As Drawing.Color
                Return Drawing.Color.FromArgb(29, 33, 36)
            End Function

            Public Function ActiveBackgroundInfo() As Drawing.Color
                Return Drawing.Color.FromArgb(17, 122, 139)
            End Function

            Public Function ActiveBackgroundLight() As Drawing.Color
                Return Drawing.Color.FromArgb(218, 224, 229)
            End Function

            Public Function ActiveBackgroundPrimary() As Drawing.Color
                Return Drawing.Color.FromArgb(0, 98, 204)
            End Function

            Public Function ActiveBackgroundSecondary() As Drawing.Color
                Return Drawing.Color.FromArgb(84, 91, 98)
            End Function

            Public Function ActiveBackgroundSuccess() As Drawing.Color
                Return Drawing.Color.FromArgb(30, 126, 52)
            End Function

            Public Function ActiveBackgroundWarning() As Drawing.Color
                Return Drawing.Color.FromArgb(211, 158, 0)
            End Function

            Public Function BackgroundDanger() As Drawing.Color
                Return Drawing.Color.FromArgb(220, 53, 69)
            End Function

            Public Function BackgroundDark() As Drawing.Color
                Return Drawing.Color.FromArgb(52, 58, 64)
            End Function

            Public Function BackgroundInfo() As Drawing.Color
                Return Drawing.Color.FromArgb(23, 162, 184)
            End Function

            Public Function BackgroundLight() As Drawing.Color
                Return Drawing.Color.FromArgb(248, 249, 250)
            End Function

            Public Function BackgroundPrimary() As Drawing.Color
                Return Drawing.Color.FromArgb(0, 123, 255)
            End Function

            Public Function BackgroundSecondary() As Drawing.Color
                Return Drawing.Color.FromArgb(108, 117, 125)
            End Function

            Public Function BackgroundSuccess() As Drawing.Color
                Return Drawing.Color.FromArgb(40, 167, 69)
            End Function

            Public Function BackgroundWarning() As Drawing.Color
                Return Drawing.Color.FromArgb(255, 193, 7)
            End Function

            Public Function BackgroundWhite() As Drawing.Color
                Return Drawing.Color.FromArgb(255, 255, 255)
            End Function

            Public Function HoverBackgroundDanger() As Drawing.Color
                Return Drawing.Color.FromArgb(200, 35, 51)
            End Function

            Public Function HoverBackgroundDark() As Drawing.Color
                Return Drawing.Color.FromArgb(35, 39, 43)
            End Function

            Public Function HoverBackgroundInfo() As Drawing.Color
                Return Drawing.Color.FromArgb(19, 132, 150)
            End Function

            Public Function HoverBackgroundLight() As Drawing.Color
                Return Drawing.Color.FromArgb(226, 230, 234)
            End Function

            Public Function HoverBackgroundPrimary() As Drawing.Color
                Return Drawing.Color.FromArgb(0, 105, 217)
            End Function

            Public Function HoverBackgroundSecondary() As Drawing.Color
                Return Drawing.Color.FromArgb(90, 98, 104)
            End Function

            Public Function HoverBackgroundSuccess() As Drawing.Color
                Return Drawing.Color.FromArgb(33, 136, 56)
            End Function

            Public Function HoverBackgroundWarning() As Drawing.Color
                Return Drawing.Color.FromArgb(224, 168, 0)
            End Function

            Public Function EnumerateBackgroundColors() As Drawing.Color()
                Return {Color.BackgroundDanger, Color.BackgroundDark, Color.BackgroundInfo, Color.BackgroundLight, Color.BackgroundPrimary, Color.BackgroundSecondary, Color.BackgroundSuccess, Color.BackgroundWarning, Color.BackgroundWhite}
            End Function

            Public Function EnumerateHoverBackgroundColors() As Drawing.Color()
                Return {Color.HoverBackgroundDanger, Color.HoverBackgroundDark, Color.HoverBackgroundInfo, Color.HoverBackgroundLight, Color.HoverBackgroundPrimary, Color.HoverBackgroundSecondary, Color.HoverBackgroundSuccess, Color.HoverBackgroundWarning}
            End Function

            Public Function EnumerateTextColors() As Drawing.Color()
                Return {Color.TextBlack50, Color.TextBody, Color.TextDanger, Color.TextDark, Color.TextInfo, Color.TextLight, Color.TextMuted, Color.TextPrimary, Color.TextSecondary, Color.TextSuccess, Color.TextWarning, Color.TextWhite, Color.TextWhite50}
            End Function

            Public Function TextBlack50() As Drawing.Color
                Return Drawing.Color.FromArgb(Byte.MaxValue \ 2, 0, 0, 0)
            End Function

            Public Function TextBody() As Drawing.Color
                Return Drawing.Color.FromArgb(33, 37, 41)
            End Function

            Public Function TextDanger() As Drawing.Color
                Return Drawing.Color.FromArgb(220, 53, 69)
            End Function

            Public Function TextDark() As Drawing.Color
                Return Drawing.Color.FromArgb(52, 58, 64)
            End Function

            Public Function TextInfo() As Drawing.Color
                Return Drawing.Color.FromArgb(23, 162, 184)
            End Function

            Public Function TextLight() As Drawing.Color
                Return Drawing.Color.FromArgb(248, 249, 250)
            End Function

            Public Function TextMuted() As Drawing.Color
                Return Drawing.Color.FromArgb(108, 117, 125)
            End Function

            Public Function TextPrimary() As Drawing.Color
                Return Drawing.Color.FromArgb(0, 123, 255)
            End Function

            Public Function TextSecondary() As Drawing.Color
                Return Drawing.Color.FromArgb(108, 117, 125)
            End Function

            Public Function TextSuccess() As Drawing.Color
                Return Drawing.Color.FromArgb(40, 167, 69)
            End Function

            Public Function TextWarning() As Drawing.Color
                Return Drawing.Color.FromArgb(255, 193, 7)
            End Function

            Public Function TextWhite() As Drawing.Color
                Return Drawing.Color.FromArgb(255, 255, 255)
            End Function

            Public Function TextWhite50() As Drawing.Color
                Return Drawing.Color.FromArgb(Byte.MaxValue \ 2, 0, 0, 0)
            End Function

        End Module

        Public Module Typography

            Public Function Close() As String
                Return Convert.ToChar(10005).ToString()
            End Function

            Public Function Font() As Font
                Return New Font(Bootstrap.Utilities.Typography.FontStack.First(), 16, GraphicsUnit.Pixel)
            End Function

            Public Function FontStack() As FontFamily()
                Dim installedFamilies As List(Of FontFamily) = New List(Of FontFamily)
                Dim fontCollection As InstalledFontCollection = New InstalledFontCollection()

                If fontCollection.Families.Any(Function(family) family.Name = "Segoe UI") Then
                    installedFamilies.Add(New FontFamily("Segoe UI"))
                End If
                If fontCollection.Families.Any(Function(family) family.Name = "Roboto") Then
                    installedFamilies.Add(New FontFamily("Roboto"))
                End If
                If fontCollection.Families.Any(Function(family) family.Name = "Helvetica Neue") Then
                    installedFamilies.Add(New FontFamily("Helvetica Neue"))
                End If

                installedFamilies.Add(FontFamily.GenericSansSerif)

                Return installedFamilies.ToArray()
            End Function

            Public Function CalculateEM(ByVal font As Font) As Double
                If font Is Nothing Then
                    Throw New ArgumentNullException("Font cannot be null.")
                End If

                Return TextRenderer.MeasureText("M", font).Width
            End Function

            Public Function CalculateEM(ByVal control As System.Windows.Forms.Control) As Double
                If control Is Nothing Then
                    Throw New ArgumentNullException("Control cannot be null.")
                End If

                Return TextRenderer.MeasureText("M", control.Font).Width
            End Function

            Public Function CalculateREM(ByVal control As System.Windows.Forms.Control) As Double
                If control Is Nothing Then
                    Throw New ArgumentNullException("Control cannot be null.")
                End If
                Dim rootElement As Form = control.FindForm()
                If rootElement Is Nothing Then
                    Throw New ArgumentNullException("The form on which the control resides on cannot be null.")
                End If

                Return TextRenderer.MeasureText("M", rootElement.Font).Width
            End Function

        End Module

    End Namespace

End Namespace
