<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAlerts
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.AlertLightModePrimary = New WinFormsBootstrap.Components.Alert.Alert()
        Me.GroupBoxAlertsLightMode = New System.Windows.Forms.GroupBox()
        Me.AlertLightModeDark = New WinFormsBootstrap.Components.Alert.Alert()
        Me.AlertLightModeLight = New WinFormsBootstrap.Components.Alert.Alert()
        Me.AlertLightModeInfo = New WinFormsBootstrap.Components.Alert.Alert()
        Me.AlertLightModeWarning = New WinFormsBootstrap.Components.Alert.Alert()
        Me.AlertLightModeDanger = New WinFormsBootstrap.Components.Alert.Alert()
        Me.AlertLightModeSuccess = New WinFormsBootstrap.Components.Alert.Alert()
        Me.AlertLightModeSecondary = New WinFormsBootstrap.Components.Alert.Alert()
        Me.GroupBoxAlertsDarkMode = New System.Windows.Forms.GroupBox()
        Me.AlertDarkModeDark = New WinFormsBootstrap.Components.Alert.Alert()
        Me.AlertDarkModeLight = New WinFormsBootstrap.Components.Alert.Alert()
        Me.AlertDarkModeInfo = New WinFormsBootstrap.Components.Alert.Alert()
        Me.AlertDarkModeWarning = New WinFormsBootstrap.Components.Alert.Alert()
        Me.AlertDarkModeDanger = New WinFormsBootstrap.Components.Alert.Alert()
        Me.AlertDarkModeSuccess = New WinFormsBootstrap.Components.Alert.Alert()
        Me.AlertDarkModeSecondary = New WinFormsBootstrap.Components.Alert.Alert()
        Me.AlertDarkModePrimary = New WinFormsBootstrap.Components.Alert.Alert()
        Me.GlobalNavigation1 = New WinFormsBootstrap.Demo.Controls.GlobalNavigation()
        Me.GroupBoxProperties = New System.Windows.Forms.GroupBox()
        Me.CheckBoxShowDismiss = New System.Windows.Forms.CheckBox()
        Me.CheckBoxIsFadable = New System.Windows.Forms.CheckBox()
        Me.ButtonReset = New WinFormsBootstrap.Components.Button.Button()
        Me.GroupBoxAlertsLightMode.SuspendLayout()
        Me.GroupBoxAlertsDarkMode.SuspendLayout()
        Me.GroupBoxProperties.SuspendLayout()
        Me.SuspendLayout()
        '
        'AlertLightModePrimary
        '
        Me.AlertLightModePrimary.AlertVariant = WinFormsBootstrap.Components.Alert.AlertVariants.Primary
        Me.AlertLightModePrimary.CornerRadius = 3
        Me.AlertLightModePrimary.Cursor = System.Windows.Forms.Cursors.Default
        Me.AlertLightModePrimary.Dock = System.Windows.Forms.DockStyle.Top
        Me.AlertLightModePrimary.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.AlertLightModePrimary.ForeColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(101, Byte), Integer))
        Me.AlertLightModePrimary.IsDismissed = False
        Me.AlertLightModePrimary.IsFadable = True
        Me.AlertLightModePrimary.Location = New System.Drawing.Point(4, 27)
        Me.AlertLightModePrimary.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.AlertLightModePrimary.MinimumSize = New System.Drawing.Size(0, 81)
        Me.AlertLightModePrimary.Name = "AlertLightModePrimary"
        Me.AlertLightModePrimary.Padding = New System.Windows.Forms.Padding(8)
        Me.AlertLightModePrimary.ShowDismiss = True
        Me.AlertLightModePrimary.Size = New System.Drawing.Size(1302, 81)
        Me.AlertLightModePrimary.TabIndex = 0
        Me.AlertLightModePrimary.Text = "Primary"
        Me.AlertLightModePrimary.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.AlertLightModePrimary.ThemeMode = WinFormsBootstrap.Utilities.Colors.ThemeModes.LightTheme
        '
        'GroupBoxAlertsLightMode
        '
        Me.GroupBoxAlertsLightMode.AutoSize = True
        Me.GroupBoxAlertsLightMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBoxAlertsLightMode.Controls.Add(Me.AlertLightModeDark)
        Me.GroupBoxAlertsLightMode.Controls.Add(Me.AlertLightModeLight)
        Me.GroupBoxAlertsLightMode.Controls.Add(Me.AlertLightModeInfo)
        Me.GroupBoxAlertsLightMode.Controls.Add(Me.AlertLightModeWarning)
        Me.GroupBoxAlertsLightMode.Controls.Add(Me.AlertLightModeDanger)
        Me.GroupBoxAlertsLightMode.Controls.Add(Me.AlertLightModeSuccess)
        Me.GroupBoxAlertsLightMode.Controls.Add(Me.AlertLightModeSecondary)
        Me.GroupBoxAlertsLightMode.Controls.Add(Me.AlertLightModePrimary)
        Me.GroupBoxAlertsLightMode.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBoxAlertsLightMode.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.GroupBoxAlertsLightMode.Location = New System.Drawing.Point(0, 117)
        Me.GroupBoxAlertsLightMode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBoxAlertsLightMode.Name = "GroupBoxAlertsLightMode"
        Me.GroupBoxAlertsLightMode.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBoxAlertsLightMode.Size = New System.Drawing.Size(1310, 680)
        Me.GroupBoxAlertsLightMode.TabIndex = 1
        Me.GroupBoxAlertsLightMode.TabStop = False
        Me.GroupBoxAlertsLightMode.Text = "Light Mode"
        '
        'AlertLightModeDark
        '
        Me.AlertLightModeDark.AlertVariant = WinFormsBootstrap.Components.Alert.AlertVariants.Dark
        Me.AlertLightModeDark.CornerRadius = 3
        Me.AlertLightModeDark.Cursor = System.Windows.Forms.Cursors.Default
        Me.AlertLightModeDark.Dock = System.Windows.Forms.DockStyle.Top
        Me.AlertLightModeDark.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.AlertLightModeDark.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.AlertLightModeDark.IsDismissed = False
        Me.AlertLightModeDark.IsFadable = True
        Me.AlertLightModeDark.Location = New System.Drawing.Point(4, 594)
        Me.AlertLightModeDark.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.AlertLightModeDark.MinimumSize = New System.Drawing.Size(0, 81)
        Me.AlertLightModeDark.Name = "AlertLightModeDark"
        Me.AlertLightModeDark.Padding = New System.Windows.Forms.Padding(8)
        Me.AlertLightModeDark.ShowDismiss = True
        Me.AlertLightModeDark.Size = New System.Drawing.Size(1302, 81)
        Me.AlertLightModeDark.TabIndex = 7
        Me.AlertLightModeDark.Text = "Dark"
        Me.AlertLightModeDark.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.AlertLightModeDark.ThemeMode = WinFormsBootstrap.Utilities.Colors.ThemeModes.LightTheme
        '
        'AlertLightModeLight
        '
        Me.AlertLightModeLight.AlertVariant = WinFormsBootstrap.Components.Alert.AlertVariants.Light
        Me.AlertLightModeLight.CornerRadius = 3
        Me.AlertLightModeLight.Cursor = System.Windows.Forms.Cursors.Default
        Me.AlertLightModeLight.Dock = System.Windows.Forms.DockStyle.Top
        Me.AlertLightModeLight.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.AlertLightModeLight.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.AlertLightModeLight.IsDismissed = False
        Me.AlertLightModeLight.IsFadable = True
        Me.AlertLightModeLight.Location = New System.Drawing.Point(4, 513)
        Me.AlertLightModeLight.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.AlertLightModeLight.MinimumSize = New System.Drawing.Size(0, 81)
        Me.AlertLightModeLight.Name = "AlertLightModeLight"
        Me.AlertLightModeLight.Padding = New System.Windows.Forms.Padding(8)
        Me.AlertLightModeLight.ShowDismiss = True
        Me.AlertLightModeLight.Size = New System.Drawing.Size(1302, 81)
        Me.AlertLightModeLight.TabIndex = 6
        Me.AlertLightModeLight.Text = "Light"
        Me.AlertLightModeLight.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.AlertLightModeLight.ThemeMode = WinFormsBootstrap.Utilities.Colors.ThemeModes.LightTheme
        '
        'AlertLightModeInfo
        '
        Me.AlertLightModeInfo.AlertVariant = WinFormsBootstrap.Components.Alert.AlertVariants.Info
        Me.AlertLightModeInfo.CornerRadius = 3
        Me.AlertLightModeInfo.Cursor = System.Windows.Forms.Cursors.Default
        Me.AlertLightModeInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.AlertLightModeInfo.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.AlertLightModeInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.AlertLightModeInfo.IsDismissed = False
        Me.AlertLightModeInfo.IsFadable = True
        Me.AlertLightModeInfo.Location = New System.Drawing.Point(4, 432)
        Me.AlertLightModeInfo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.AlertLightModeInfo.MinimumSize = New System.Drawing.Size(0, 81)
        Me.AlertLightModeInfo.Name = "AlertLightModeInfo"
        Me.AlertLightModeInfo.Padding = New System.Windows.Forms.Padding(8)
        Me.AlertLightModeInfo.ShowDismiss = True
        Me.AlertLightModeInfo.Size = New System.Drawing.Size(1302, 81)
        Me.AlertLightModeInfo.TabIndex = 5
        Me.AlertLightModeInfo.Text = "Info"
        Me.AlertLightModeInfo.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.AlertLightModeInfo.ThemeMode = WinFormsBootstrap.Utilities.Colors.ThemeModes.LightTheme
        '
        'AlertLightModeWarning
        '
        Me.AlertLightModeWarning.AlertVariant = WinFormsBootstrap.Components.Alert.AlertVariants.Warning
        Me.AlertLightModeWarning.CornerRadius = 3
        Me.AlertLightModeWarning.Cursor = System.Windows.Forms.Cursors.Default
        Me.AlertLightModeWarning.Dock = System.Windows.Forms.DockStyle.Top
        Me.AlertLightModeWarning.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.AlertLightModeWarning.ForeColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(3, Byte), Integer))
        Me.AlertLightModeWarning.IsDismissed = False
        Me.AlertLightModeWarning.IsFadable = True
        Me.AlertLightModeWarning.Location = New System.Drawing.Point(4, 351)
        Me.AlertLightModeWarning.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.AlertLightModeWarning.MinimumSize = New System.Drawing.Size(0, 81)
        Me.AlertLightModeWarning.Name = "AlertLightModeWarning"
        Me.AlertLightModeWarning.Padding = New System.Windows.Forms.Padding(8)
        Me.AlertLightModeWarning.ShowDismiss = True
        Me.AlertLightModeWarning.Size = New System.Drawing.Size(1302, 81)
        Me.AlertLightModeWarning.TabIndex = 4
        Me.AlertLightModeWarning.Text = "Warning"
        Me.AlertLightModeWarning.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.AlertLightModeWarning.ThemeMode = WinFormsBootstrap.Utilities.Colors.ThemeModes.LightTheme
        '
        'AlertLightModeDanger
        '
        Me.AlertLightModeDanger.AlertVariant = WinFormsBootstrap.Components.Alert.AlertVariants.Danger
        Me.AlertLightModeDanger.CornerRadius = 3
        Me.AlertLightModeDanger.Cursor = System.Windows.Forms.Cursors.Default
        Me.AlertLightModeDanger.Dock = System.Windows.Forms.DockStyle.Top
        Me.AlertLightModeDanger.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.AlertLightModeDanger.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.AlertLightModeDanger.IsDismissed = False
        Me.AlertLightModeDanger.IsFadable = True
        Me.AlertLightModeDanger.Location = New System.Drawing.Point(4, 270)
        Me.AlertLightModeDanger.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.AlertLightModeDanger.MinimumSize = New System.Drawing.Size(0, 81)
        Me.AlertLightModeDanger.Name = "AlertLightModeDanger"
        Me.AlertLightModeDanger.Padding = New System.Windows.Forms.Padding(8)
        Me.AlertLightModeDanger.ShowDismiss = True
        Me.AlertLightModeDanger.Size = New System.Drawing.Size(1302, 81)
        Me.AlertLightModeDanger.TabIndex = 3
        Me.AlertLightModeDanger.Text = "Danger"
        Me.AlertLightModeDanger.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.AlertLightModeDanger.ThemeMode = WinFormsBootstrap.Utilities.Colors.ThemeModes.LightTheme
        '
        'AlertLightModeSuccess
        '
        Me.AlertLightModeSuccess.AlertVariant = WinFormsBootstrap.Components.Alert.AlertVariants.Success
        Me.AlertLightModeSuccess.CornerRadius = 3
        Me.AlertLightModeSuccess.Cursor = System.Windows.Forms.Cursors.Default
        Me.AlertLightModeSuccess.Dock = System.Windows.Forms.DockStyle.Top
        Me.AlertLightModeSuccess.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.AlertLightModeSuccess.ForeColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.AlertLightModeSuccess.IsDismissed = False
        Me.AlertLightModeSuccess.IsFadable = True
        Me.AlertLightModeSuccess.Location = New System.Drawing.Point(4, 189)
        Me.AlertLightModeSuccess.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.AlertLightModeSuccess.MinimumSize = New System.Drawing.Size(0, 81)
        Me.AlertLightModeSuccess.Name = "AlertLightModeSuccess"
        Me.AlertLightModeSuccess.Padding = New System.Windows.Forms.Padding(8)
        Me.AlertLightModeSuccess.ShowDismiss = True
        Me.AlertLightModeSuccess.Size = New System.Drawing.Size(1302, 81)
        Me.AlertLightModeSuccess.TabIndex = 2
        Me.AlertLightModeSuccess.Text = "Success"
        Me.AlertLightModeSuccess.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.AlertLightModeSuccess.ThemeMode = WinFormsBootstrap.Utilities.Colors.ThemeModes.LightTheme
        '
        'AlertLightModeSecondary
        '
        Me.AlertLightModeSecondary.AlertVariant = WinFormsBootstrap.Components.Alert.AlertVariants.Secondary
        Me.AlertLightModeSecondary.CornerRadius = 3
        Me.AlertLightModeSecondary.Cursor = System.Windows.Forms.Cursors.Default
        Me.AlertLightModeSecondary.Dock = System.Windows.Forms.DockStyle.Top
        Me.AlertLightModeSecondary.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.AlertLightModeSecondary.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.AlertLightModeSecondary.IsDismissed = False
        Me.AlertLightModeSecondary.IsFadable = True
        Me.AlertLightModeSecondary.Location = New System.Drawing.Point(4, 108)
        Me.AlertLightModeSecondary.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.AlertLightModeSecondary.MinimumSize = New System.Drawing.Size(0, 81)
        Me.AlertLightModeSecondary.Name = "AlertLightModeSecondary"
        Me.AlertLightModeSecondary.Padding = New System.Windows.Forms.Padding(8)
        Me.AlertLightModeSecondary.ShowDismiss = True
        Me.AlertLightModeSecondary.Size = New System.Drawing.Size(1302, 81)
        Me.AlertLightModeSecondary.TabIndex = 1
        Me.AlertLightModeSecondary.Text = "Secondary"
        Me.AlertLightModeSecondary.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.AlertLightModeSecondary.ThemeMode = WinFormsBootstrap.Utilities.Colors.ThemeModes.LightTheme
        '
        'GroupBoxAlertDarkMode
        '
        Me.GroupBoxAlertsDarkMode.AutoSize = True
        Me.GroupBoxAlertsDarkMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBoxAlertsDarkMode.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.GroupBoxAlertsDarkMode.Controls.Add(Me.AlertDarkModeDark)
        Me.GroupBoxAlertsDarkMode.Controls.Add(Me.AlertDarkModeLight)
        Me.GroupBoxAlertsDarkMode.Controls.Add(Me.AlertDarkModeInfo)
        Me.GroupBoxAlertsDarkMode.Controls.Add(Me.AlertDarkModeWarning)
        Me.GroupBoxAlertsDarkMode.Controls.Add(Me.AlertDarkModeDanger)
        Me.GroupBoxAlertsDarkMode.Controls.Add(Me.AlertDarkModeSuccess)
        Me.GroupBoxAlertsDarkMode.Controls.Add(Me.AlertDarkModeSecondary)
        Me.GroupBoxAlertsDarkMode.Controls.Add(Me.AlertDarkModePrimary)
        Me.GroupBoxAlertsDarkMode.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBoxAlertsDarkMode.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.GroupBoxAlertsDarkMode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.GroupBoxAlertsDarkMode.Location = New System.Drawing.Point(0, 797)
        Me.GroupBoxAlertsDarkMode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBoxAlertsDarkMode.Name = "GroupBoxAlertDarkMode"
        Me.GroupBoxAlertsDarkMode.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBoxAlertsDarkMode.Size = New System.Drawing.Size(1310, 680)
        Me.GroupBoxAlertsDarkMode.TabIndex = 2
        Me.GroupBoxAlertsDarkMode.TabStop = False
        Me.GroupBoxAlertsDarkMode.Text = "Dark Mode"
        '
        'AlertDarkModeDark
        '
        Me.AlertDarkModeDark.AlertVariant = WinFormsBootstrap.Components.Alert.AlertVariants.Dark
        Me.AlertDarkModeDark.CornerRadius = 3
        Me.AlertDarkModeDark.Cursor = System.Windows.Forms.Cursors.Default
        Me.AlertDarkModeDark.Dock = System.Windows.Forms.DockStyle.Top
        Me.AlertDarkModeDark.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.AlertDarkModeDark.ForeColor = System.Drawing.Color.FromArgb(CType(CType(173, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.AlertDarkModeDark.IsDismissed = False
        Me.AlertDarkModeDark.IsFadable = True
        Me.AlertDarkModeDark.Location = New System.Drawing.Point(4, 594)
        Me.AlertDarkModeDark.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.AlertDarkModeDark.MinimumSize = New System.Drawing.Size(0, 81)
        Me.AlertDarkModeDark.Name = "AlertDarkModeDark"
        Me.AlertDarkModeDark.Padding = New System.Windows.Forms.Padding(8)
        Me.AlertDarkModeDark.ShowDismiss = True
        Me.AlertDarkModeDark.Size = New System.Drawing.Size(1302, 81)
        Me.AlertDarkModeDark.TabIndex = 7
        Me.AlertDarkModeDark.Text = "Dark"
        Me.AlertDarkModeDark.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.AlertDarkModeDark.ThemeMode = WinFormsBootstrap.Utilities.Colors.ThemeModes.DarkTheme
        '
        'AlertDarkModeLight
        '
        Me.AlertDarkModeLight.AlertVariant = WinFormsBootstrap.Components.Alert.AlertVariants.Light
        Me.AlertDarkModeLight.CornerRadius = 3
        Me.AlertDarkModeLight.Cursor = System.Windows.Forms.Cursors.Default
        Me.AlertDarkModeLight.Dock = System.Windows.Forms.DockStyle.Top
        Me.AlertDarkModeLight.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.AlertDarkModeLight.ForeColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.AlertDarkModeLight.IsDismissed = False
        Me.AlertDarkModeLight.IsFadable = True
        Me.AlertDarkModeLight.Location = New System.Drawing.Point(4, 513)
        Me.AlertDarkModeLight.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.AlertDarkModeLight.MinimumSize = New System.Drawing.Size(0, 81)
        Me.AlertDarkModeLight.Name = "AlertDarkModeLight"
        Me.AlertDarkModeLight.Padding = New System.Windows.Forms.Padding(8)
        Me.AlertDarkModeLight.ShowDismiss = True
        Me.AlertDarkModeLight.Size = New System.Drawing.Size(1302, 81)
        Me.AlertDarkModeLight.TabIndex = 6
        Me.AlertDarkModeLight.Text = "Light"
        Me.AlertDarkModeLight.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.AlertDarkModeLight.ThemeMode = WinFormsBootstrap.Utilities.Colors.ThemeModes.DarkTheme
        '
        'AlertDarkModeInfo
        '
        Me.AlertDarkModeInfo.AlertVariant = WinFormsBootstrap.Components.Alert.AlertVariants.Info
        Me.AlertDarkModeInfo.CornerRadius = 3
        Me.AlertDarkModeInfo.Cursor = System.Windows.Forms.Cursors.Default
        Me.AlertDarkModeInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.AlertDarkModeInfo.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.AlertDarkModeInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.AlertDarkModeInfo.IsDismissed = False
        Me.AlertDarkModeInfo.IsFadable = True
        Me.AlertDarkModeInfo.Location = New System.Drawing.Point(4, 432)
        Me.AlertDarkModeInfo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.AlertDarkModeInfo.MinimumSize = New System.Drawing.Size(0, 81)
        Me.AlertDarkModeInfo.Name = "AlertDarkModeInfo"
        Me.AlertDarkModeInfo.Padding = New System.Windows.Forms.Padding(8)
        Me.AlertDarkModeInfo.ShowDismiss = True
        Me.AlertDarkModeInfo.Size = New System.Drawing.Size(1302, 81)
        Me.AlertDarkModeInfo.TabIndex = 5
        Me.AlertDarkModeInfo.Text = "Info"
        Me.AlertDarkModeInfo.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.AlertDarkModeInfo.ThemeMode = WinFormsBootstrap.Utilities.Colors.ThemeModes.DarkTheme
        '
        'AlertDarkModeWarning
        '
        Me.AlertDarkModeWarning.AlertVariant = WinFormsBootstrap.Components.Alert.AlertVariants.Warning
        Me.AlertDarkModeWarning.CornerRadius = 3
        Me.AlertDarkModeWarning.Cursor = System.Windows.Forms.Cursors.Default
        Me.AlertDarkModeWarning.Dock = System.Windows.Forms.DockStyle.Top
        Me.AlertDarkModeWarning.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.AlertDarkModeWarning.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.AlertDarkModeWarning.IsDismissed = False
        Me.AlertDarkModeWarning.IsFadable = True
        Me.AlertDarkModeWarning.Location = New System.Drawing.Point(4, 351)
        Me.AlertDarkModeWarning.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.AlertDarkModeWarning.MinimumSize = New System.Drawing.Size(0, 81)
        Me.AlertDarkModeWarning.Name = "AlertDarkModeWarning"
        Me.AlertDarkModeWarning.Padding = New System.Windows.Forms.Padding(8)
        Me.AlertDarkModeWarning.ShowDismiss = True
        Me.AlertDarkModeWarning.Size = New System.Drawing.Size(1302, 81)
        Me.AlertDarkModeWarning.TabIndex = 4
        Me.AlertDarkModeWarning.Text = "Warning"
        Me.AlertDarkModeWarning.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.AlertDarkModeWarning.ThemeMode = WinFormsBootstrap.Utilities.Colors.ThemeModes.DarkTheme
        '
        'AlertDarkModeDanger
        '
        Me.AlertDarkModeDanger.AlertVariant = WinFormsBootstrap.Components.Alert.AlertVariants.Danger
        Me.AlertDarkModeDanger.CornerRadius = 3
        Me.AlertDarkModeDanger.Cursor = System.Windows.Forms.Cursors.Default
        Me.AlertDarkModeDanger.Dock = System.Windows.Forms.DockStyle.Top
        Me.AlertDarkModeDanger.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.AlertDarkModeDanger.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(134, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.AlertDarkModeDanger.IsDismissed = False
        Me.AlertDarkModeDanger.IsFadable = True
        Me.AlertDarkModeDanger.Location = New System.Drawing.Point(4, 270)
        Me.AlertDarkModeDanger.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.AlertDarkModeDanger.MinimumSize = New System.Drawing.Size(0, 81)
        Me.AlertDarkModeDanger.Name = "AlertDarkModeDanger"
        Me.AlertDarkModeDanger.Padding = New System.Windows.Forms.Padding(8)
        Me.AlertDarkModeDanger.ShowDismiss = True
        Me.AlertDarkModeDanger.Size = New System.Drawing.Size(1302, 81)
        Me.AlertDarkModeDanger.TabIndex = 3
        Me.AlertDarkModeDanger.Text = "Danger"
        Me.AlertDarkModeDanger.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.AlertDarkModeDanger.ThemeMode = WinFormsBootstrap.Utilities.Colors.ThemeModes.DarkTheme
        '
        'AlertDarkModeSuccess
        '
        Me.AlertDarkModeSuccess.AlertVariant = WinFormsBootstrap.Components.Alert.AlertVariants.Success
        Me.AlertDarkModeSuccess.CornerRadius = 3
        Me.AlertDarkModeSuccess.Cursor = System.Windows.Forms.Cursors.Default
        Me.AlertDarkModeSuccess.Dock = System.Windows.Forms.DockStyle.Top
        Me.AlertDarkModeSuccess.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.AlertDarkModeSuccess.ForeColor = System.Drawing.Color.FromArgb(CType(CType(117, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(152, Byte), Integer))
        Me.AlertDarkModeSuccess.IsDismissed = False
        Me.AlertDarkModeSuccess.IsFadable = True
        Me.AlertDarkModeSuccess.Location = New System.Drawing.Point(4, 189)
        Me.AlertDarkModeSuccess.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.AlertDarkModeSuccess.MinimumSize = New System.Drawing.Size(0, 81)
        Me.AlertDarkModeSuccess.Name = "AlertDarkModeSuccess"
        Me.AlertDarkModeSuccess.Padding = New System.Windows.Forms.Padding(8)
        Me.AlertDarkModeSuccess.ShowDismiss = True
        Me.AlertDarkModeSuccess.Size = New System.Drawing.Size(1302, 81)
        Me.AlertDarkModeSuccess.TabIndex = 2
        Me.AlertDarkModeSuccess.Text = "Success"
        Me.AlertDarkModeSuccess.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.AlertDarkModeSuccess.ThemeMode = WinFormsBootstrap.Utilities.Colors.ThemeModes.DarkTheme
        '
        'AlertDarkModeSecondary
        '
        Me.AlertDarkModeSecondary.AlertVariant = WinFormsBootstrap.Components.Alert.AlertVariants.Secondary
        Me.AlertDarkModeSecondary.CornerRadius = 3
        Me.AlertDarkModeSecondary.Cursor = System.Windows.Forms.Cursors.Default
        Me.AlertDarkModeSecondary.Dock = System.Windows.Forms.DockStyle.Top
        Me.AlertDarkModeSecondary.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.AlertDarkModeSecondary.ForeColor = System.Drawing.Color.FromArgb(CType(CType(173, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.AlertDarkModeSecondary.IsDismissed = False
        Me.AlertDarkModeSecondary.IsFadable = True
        Me.AlertDarkModeSecondary.Location = New System.Drawing.Point(4, 108)
        Me.AlertDarkModeSecondary.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.AlertDarkModeSecondary.MinimumSize = New System.Drawing.Size(0, 81)
        Me.AlertDarkModeSecondary.Name = "AlertDarkModeSecondary"
        Me.AlertDarkModeSecondary.Padding = New System.Windows.Forms.Padding(8)
        Me.AlertDarkModeSecondary.ShowDismiss = True
        Me.AlertDarkModeSecondary.Size = New System.Drawing.Size(1302, 81)
        Me.AlertDarkModeSecondary.TabIndex = 1
        Me.AlertDarkModeSecondary.Text = "Secondary"
        Me.AlertDarkModeSecondary.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.AlertDarkModeSecondary.ThemeMode = WinFormsBootstrap.Utilities.Colors.ThemeModes.DarkTheme
        '
        'AlertDarkModePrimary
        '
        Me.AlertDarkModePrimary.AlertVariant = WinFormsBootstrap.Components.Alert.AlertVariants.Primary
        Me.AlertDarkModePrimary.CornerRadius = 3
        Me.AlertDarkModePrimary.Cursor = System.Windows.Forms.Cursors.Default
        Me.AlertDarkModePrimary.Dock = System.Windows.Forms.DockStyle.Top
        Me.AlertDarkModePrimary.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.AlertDarkModePrimary.ForeColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.AlertDarkModePrimary.IsDismissed = False
        Me.AlertDarkModePrimary.IsFadable = True
        Me.AlertDarkModePrimary.Location = New System.Drawing.Point(4, 27)
        Me.AlertDarkModePrimary.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.AlertDarkModePrimary.MinimumSize = New System.Drawing.Size(0, 81)
        Me.AlertDarkModePrimary.Name = "AlertDarkModePrimary"
        Me.AlertDarkModePrimary.Padding = New System.Windows.Forms.Padding(8)
        Me.AlertDarkModePrimary.ShowDismiss = True
        Me.AlertDarkModePrimary.Size = New System.Drawing.Size(1302, 81)
        Me.AlertDarkModePrimary.TabIndex = 0
        Me.AlertDarkModePrimary.Text = "Primary"
        Me.AlertDarkModePrimary.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.AlertDarkModePrimary.ThemeMode = WinFormsBootstrap.Utilities.Colors.ThemeModes.DarkTheme
        '
        'GlobalNavigation1
        '
        Me.GlobalNavigation1.Location = New System.Drawing.Point(0, 0)
        Me.GlobalNavigation1.Name = "GlobalNavigation1"
        Me.GlobalNavigation1.Padding = New System.Windows.Forms.Padding(9, 3, 0, 3)
        Me.GlobalNavigation1.Size = New System.Drawing.Size(1310, 25)
        Me.GlobalNavigation1.TabIndex = 8
        Me.GlobalNavigation1.Text = "GlobalNavigation1"
        '
        'GroupBoxProperties
        '
        Me.GroupBoxProperties.Controls.Add(Me.ButtonReset)
        Me.GroupBoxProperties.Controls.Add(Me.CheckBoxIsFadable)
        Me.GroupBoxProperties.Controls.Add(Me.CheckBoxShowDismiss)
        Me.GroupBoxProperties.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBoxProperties.Location = New System.Drawing.Point(0, 25)
        Me.GroupBoxProperties.Name = "GroupBoxProperties"
        Me.GroupBoxProperties.Padding = New System.Windows.Forms.Padding(8, 16, 8, 16)
        Me.GroupBoxProperties.Size = New System.Drawing.Size(1310, 92)
        Me.GroupBoxProperties.TabIndex = 8
        Me.GroupBoxProperties.TabStop = False
        Me.GroupBoxProperties.Text = "Properties"
        '
        'CheckBoxShowDismiss
        '
        Me.CheckBoxShowDismiss.AutoSize = True
        Me.CheckBoxShowDismiss.Checked = True
        Me.CheckBoxShowDismiss.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxShowDismiss.Dock = System.Windows.Forms.DockStyle.Left
        Me.CheckBoxShowDismiss.Location = New System.Drawing.Point(8, 38)
        Me.CheckBoxShowDismiss.Name = "CheckBoxShowDismiss"
        Me.CheckBoxShowDismiss.Size = New System.Drawing.Size(133, 38)
        Me.CheckBoxShowDismiss.TabIndex = 0
        Me.CheckBoxShowDismiss.Text = "Show Dismiss?"
        Me.CheckBoxShowDismiss.UseVisualStyleBackColor = True
        '
        'CheckBoxIsFadable
        '
        Me.CheckBoxIsFadable.AutoSize = True
        Me.CheckBoxIsFadable.Checked = True
        Me.CheckBoxIsFadable.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxIsFadable.Dock = System.Windows.Forms.DockStyle.Left
        Me.CheckBoxIsFadable.Location = New System.Drawing.Point(141, 38)
        Me.CheckBoxIsFadable.Name = "CheckBoxIsFadable"
        Me.CheckBoxIsFadable.Size = New System.Drawing.Size(104, 38)
        Me.CheckBoxIsFadable.TabIndex = 1
        Me.CheckBoxIsFadable.Text = "Is Fadable?"
        Me.CheckBoxIsFadable.UseVisualStyleBackColor = True
        '
        'ButtonReset
        '
        Me.ButtonReset.ButtonSize = WinFormsBootstrap.Components.Button.ButtonSizes.[Default]
        Me.ButtonReset.ButtonStyle = WinFormsBootstrap.Components.Button.ButtonStyles.Solid
        Me.ButtonReset.ButtonVariant = WinFormsBootstrap.Components.Button.ButtonVariants.Primary
        Me.ButtonReset.CornerRadius = 6
        Me.ButtonReset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonReset.Dock = System.Windows.Forms.DockStyle.Left
        Me.ButtonReset.FlatAppearance.BorderSize = 0
        Me.ButtonReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.ButtonReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.ButtonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonReset.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.ButtonReset.Location = New System.Drawing.Point(245, 38)
        Me.ButtonReset.Name = "ButtonReset"
        Me.ButtonReset.Padding = New System.Windows.Forms.Padding(12, 6, 12, 6)
        Me.ButtonReset.Size = New System.Drawing.Size(75, 38)
        Me.ButtonReset.TabIndex = 2
        Me.ButtonReset.Text = "Reset"
        Me.ButtonReset.ThemeMode = WinFormsBootstrap.Utilities.Colors.ThemeModes.LightTheme
        Me.ButtonReset.UseVisualStyleBackColor = False
        '
        'FormAlerts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1327, 903)
        Me.Controls.Add(Me.GroupBoxAlertsDarkMode)
        Me.Controls.Add(Me.GroupBoxAlertsLightMode)
        Me.Controls.Add(Me.GroupBoxProperties)
        Me.Controls.Add(Me.GlobalNavigation1)
        Me.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.MainMenuStrip = Me.GlobalNavigation1
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FormAlerts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bootstrap Alerts"
        Me.GroupBoxAlertsLightMode.ResumeLayout(False)
        Me.GroupBoxAlertsDarkMode.ResumeLayout(False)
        Me.GroupBoxProperties.ResumeLayout(False)
        Me.GroupBoxProperties.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents AlertLightModePrimary As Components.Alert.Alert
    Friend WithEvents GroupBoxAlertsLightMode As GroupBox
    Friend WithEvents AlertLightModeSecondary As Components.Alert.Alert
    Friend WithEvents AlertLightModeWarning As Components.Alert.Alert
    Friend WithEvents AlertLightModeDanger As Components.Alert.Alert
    Friend WithEvents AlertLightModeSuccess As Components.Alert.Alert
    Friend WithEvents AlertLightModeDark As Components.Alert.Alert
    Friend WithEvents AlertLightModeLight As Components.Alert.Alert
    Friend WithEvents AlertLightModeInfo As Components.Alert.Alert
    Friend WithEvents GroupBoxAlertsDarkMode As GroupBox
    Friend WithEvents AlertDarkModeDark As Components.Alert.Alert
    Friend WithEvents AlertDarkModeLight As Components.Alert.Alert
    Friend WithEvents AlertDarkModeInfo As Components.Alert.Alert
    Friend WithEvents AlertDarkModeWarning As Components.Alert.Alert
    Friend WithEvents AlertDarkModeDanger As Components.Alert.Alert
    Friend WithEvents AlertDarkModeSuccess As Components.Alert.Alert
    Friend WithEvents AlertDarkModeSecondary As Components.Alert.Alert
    Friend WithEvents AlertDarkModePrimary As Components.Alert.Alert
    Friend WithEvents GlobalNavigation1 As Controls.GlobalNavigation
    Friend WithEvents GroupBoxProperties As GroupBox
    Friend WithEvents ButtonReset As Components.Button.Button
    Friend WithEvents CheckBoxIsFadable As CheckBox
    Friend WithEvents CheckBoxShowDismiss As CheckBox
End Class
