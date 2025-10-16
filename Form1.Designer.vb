<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlWelcome = New Panel()
        Button2 = New Button()
        Button1 = New Button()
        lblTitle = New Label()
        pnlWelcome.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlWelcome
        ' 
        pnlWelcome.BackColor = SystemColors.ActiveCaptionText
        pnlWelcome.Controls.Add(Button2)
        pnlWelcome.Controls.Add(Button1)
        pnlWelcome.Controls.Add(lblTitle)
        pnlWelcome.Dock = DockStyle.Fill
        pnlWelcome.Location = New Point(0, 0)
        pnlWelcome.Name = "pnlWelcome"
        pnlWelcome.Size = New Size(955, 639)
        pnlWelcome.TabIndex = 1
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.DarkRed
        Button2.Font = New Font("Poppins", 30F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button2.ForeColor = SystemColors.Control
        Button2.Location = New Point(418, 417)
        Button2.Name = "Button2"
        Button2.Size = New Size(169, 62)
        Button2.TabIndex = 2
        Button2.Text = "EXIT"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Black
        Button1.Font = New Font("Poppins", 30F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = SystemColors.Control
        Button1.Location = New Point(418, 339)
        Button1.Name = "Button1"
        Button1.Size = New Size(169, 62)
        Button1.TabIndex = 1
        Button1.Text = "START"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.BackColor = SystemColors.ControlDarkDark
        lblTitle.Font = New Font("Impact", 95.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = SystemColors.ButtonHighlight
        lblTitle.Location = New Point(127, 121)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(728, 155)
        lblTitle.TabIndex = 0
        lblTitle.Text = "BCCI SYSTEM"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(955, 639)
        Controls.Add(pnlWelcome)
        Name = "Form1"
        Text = "BCCI_PAGALAN"
        pnlWelcome.ResumeLayout(False)
        pnlWelcome.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlWelcome As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button

End Class
