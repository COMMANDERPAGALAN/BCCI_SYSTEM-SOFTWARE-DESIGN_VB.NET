Imports System.Windows.Forms
Imports System.Drawing

Public Class frmInquiryDetails
    Inherits Form

    Private outerPanel As Panel
    Private flow As FlowLayoutPanel

    Private btnClose As Button
    Private btnContainer As Panel

    Public Sub New(employee As String, company As String, monthlySalary As Integer, annualSalary As Integer, tax As Double, sss As Double, pagIbig As Double, philHealth As Double)
        Me.Text = "INQUIRY DETAILS | BCCI"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.ClientSize = New Size(800, 640)

        InitializeComponents()

        ' populate values (preserve formatting/values)
        SetFieldValue("NAME", employee)
        SetFieldValue("COMPANY", company)
        SetFieldValue("MONTHLY SALARY", monthlySalary.ToString("N0"))
        SetFieldValue("ANNUAL SALARY", annualSalary.ToString("N0"))
        SetFieldValue("TAX (MONTHLY)", tax.ToString("F2"))
        SetFieldValue("SSS (MONTHLY)", sss.ToString("F2"))
        SetFieldValue("PAG-IBIG (MONTHLY)", pagIbig.ToString("F2"))
        SetFieldValue("PHILHEALTH (MONTHLY)", philHealth.ToString("F2"))
    End Sub

    Private Sub InitializeComponents()
        outerPanel = New Panel() With {
            .Dock = DockStyle.Fill,
            .BackColor = Color.Black,
            .Padding = New Padding(20)
        }

        flow = New FlowLayoutPanel() With {
            .Dock = DockStyle.Fill,
            .FlowDirection = FlowDirection.TopDown,
            .WrapContents = False,
            .AutoScroll = True,
            .Padding = New Padding(12, 12, 12, 24),
            .BackColor = Color.Transparent
        }

        Dim lblHeader As New Label() With {
            .AutoSize = False,
            .Height = 72,
            .Dock = DockStyle.Top,
            .TextAlign = ContentAlignment.MiddleCenter,
            .ForeColor = Color.White,
            .Font = New Font("Consolas", 14.0F, FontStyle.Bold),
            .Text = "------------------------------------------------------------" & Environment.NewLine &
                    "INQUIRY DETAILS" & Environment.NewLine &
                    "------------------------------------------------------------"
        }

        Dim headerContainer As New Panel() With {
            .AutoSize = False,
            .Height = lblHeader.Height,
            .BackColor = Color.Transparent
        }
        headerContainer.Controls.Add(lblHeader)
        flow.Controls.Add(headerContainer)

        AddFieldRow("NAME")
        AddFieldRow("COMPANY")
        AddFieldRow("MONTHLY SALARY")
        AddFieldRow("ANNUAL SALARY")
        AddFieldRow("TAX (MONTHLY)")
        AddFieldRow("SSS (MONTHLY)")
        AddFieldRow("PAG-IBIG (MONTHLY)")
        AddFieldRow("PHILHEALTH (MONTHLY)")

        btnClose = New Button() With {
            .Text = "CLOSE",
            .Width = 180,
            .Height = 52,
            .BackColor = Color.Black,
            .ForeColor = Color.White,
            .Font = New Font("Impact", 14.0F),
            .FlatStyle = FlatStyle.Flat,
            .TabStop = False,
            .Cursor = Cursors.Hand
        }
        btnClose.FlatAppearance.BorderColor = Color.White
        btnClose.FlatAppearance.BorderSize = 2

        btnContainer = New Panel() With {
            .Height = btnClose.Height + 16,
            .BackColor = Color.Transparent
        }
        btnContainer.Controls.Add(btnClose)
        flow.Controls.Add(btnContainer)

        AddHandler btnClose.Click, Sub(s, e) Me.Close()
        AddHandler flow.Resize, AddressOf Flow_Resize
        AddHandler Me.Shown, AddressOf frmInquiryDetails_Shown
        AddHandler Me.FormClosed, AddressOf Frm_FormClosed

        outerPanel.Controls.Add(flow)
        Me.Controls.Add(outerPanel)
    End Sub

    Private Sub AddFieldRow(fieldName As String)
        Dim container As New Panel() With {
            .AutoSize = False,
            .Height = 72,
            .BackColor = Color.Transparent
        }

        Dim lbl As New Label() With {
            .Text = fieldName & ":",
            .AutoSize = False,
            .Height = 18,
            .Dock = DockStyle.Top,
            .ForeColor = Color.White,
            .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold),
            .TextAlign = ContentAlignment.MiddleLeft
        }

        Dim box As New Panel() With {
            .BackColor = Color.Black,
            .Padding = New Padding(6),
            .Height = 48,
            .Dock = DockStyle.Bottom
        }
        Dim txt As New TextBox() With {
            .BorderStyle = BorderStyle.None,
            .Dock = DockStyle.Fill,
            .Font = New Font("Segoe UI", 12.0F),
            .ReadOnly = True,
            .TabStop = False,
            .ShortcutsEnabled = False,
            .BackColor = Color.White,
            .Cursor = Cursors.Default
        }
        AddHandler txt.Enter, Sub(s, e) Me.ActiveControl = btnClose

        box.Controls.Add(txt)

        container.Tag = New With {.Field = fieldName, .TextBox = txt}
        container.Controls.Add(lbl)
        container.Controls.Add(box)

        flow.Controls.Add(container)
    End Sub

    Private Sub SetFieldValue(fieldName As String, value As String)
        For Each ctrl As Control In flow.Controls
            Dim tagObj = ctrl.Tag
            If tagObj IsNot Nothing Then
                Dim fld = DirectCast(tagObj, Object).Field
                If String.Equals(fld, fieldName, StringComparison.OrdinalIgnoreCase) Then
                    Dim tb = DirectCast(DirectCast(tagObj, Object).TextBox, TextBox)
                    tb.Text = value
                    Exit For
                End If
            End If
        Next
    End Sub

    Private Sub Flow_Resize(sender As Object, e As EventArgs)
        Dim targetWidth As Integer = Math.Max(200, flow.ClientSize.Width - flow.Padding.Horizontal - SystemInformation.VerticalScrollBarWidth)
        For Each c As Control In flow.Controls
            c.Width = targetWidth
            For Each inner As Control In c.Controls
                If TypeOf inner Is Button Then
                    inner.Left = Math.Max(0, (c.ClientSize.Width - inner.Width) \ 2)
                ElseIf TypeOf inner Is Label Then
                    inner.Width = c.ClientSize.Width
                End If
            Next
        Next

        If btnContainer IsNot Nothing Then
            btnContainer.Width = targetWidth
            btnClose.Left = Math.Max(0, (btnContainer.ClientSize.Width - btnClose.Width) \ 2)
            btnClose.Top = Math.Max(0, (btnContainer.ClientSize.Height - btnClose.Height) \ 2)
            flow.ScrollControlIntoView(btnContainer)
        End If
    End Sub

    Private Sub frmInquiryDetails_Shown(sender As Object, e As EventArgs)
        Flow_Resize(Nothing, Nothing)
    End Sub

    Private Sub Frm_FormClosed(sender As Object, e As FormClosedEventArgs)
        If Me.Owner IsNot Nothing Then
            Me.Owner.Show()
        End If
    End Sub
End Class