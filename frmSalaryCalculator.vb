Imports System.Windows.Forms
Imports System.Drawing

Public Class frmSalaryCalculator
    Inherits Form

    Private lblEmployee As Label
    Private txtEmployee As TextBox
    Private pnlEmployeeBox As Panel

    Private lblCompany As Label
    Private txtCompany As TextBox
    Private pnlCompanyBox As Panel

    Private lblSalary As Label
    Private txtSalary As TextBox
    Private pnlSalaryBox As Panel

    Private btnCalculate As Button
    Private btnClear As Button
    Private btnExit As Button
    Private Panel1 As Panel
    Private contentPanel As Panel

    Public Sub New()
        Me.Text = "INQUIRE: BCCI | Inquiry System for Employees | Benefits, Coverage, & Contribution"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.ClientSize = New Size(900, 600)

        InitializeComponents()
    End Sub

    Private Sub InitializeComponents()
        Panel1 = New Panel() With {
            .Dock = DockStyle.Fill,
            .BackColor = Color.Black,
            .Padding = New Padding(24)
        }

        contentPanel = New Panel() With {
            .Size = New Size(760, 420),
            .BackColor = Color.Transparent
        }

        lblEmployee = New Label() With {
            .Text = "NAME OF EMPLOYEE:",
            .AutoSize = True,
            .ForeColor = Color.White,
            .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        }

        pnlEmployeeBox = New Panel() With {
            .BackColor = Color.Black,
            .Padding = New Padding(6),
            .Size = New Size(contentPanel.Width - 32, 52)
        }
        txtEmployee = New TextBox() With {
            .BorderStyle = BorderStyle.None,
            .Dock = DockStyle.Fill,
            .Font = New Font("Segoe UI", 14.0F),
            .BackColor = Color.White
        }
        pnlEmployeeBox.Controls.Add(txtEmployee)

        lblCompany = New Label() With {
            .Text = "NAME OF COMPANY:",
            .AutoSize = True,
            .ForeColor = Color.White,
            .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        }

        pnlCompanyBox = New Panel() With {
            .BackColor = Color.Black,
            .Padding = New Padding(6),
            .Size = New Size(contentPanel.Width - 32, 52)
        }
        txtCompany = New TextBox() With {
            .BorderStyle = BorderStyle.None,
            .Dock = DockStyle.Fill,
            .Font = New Font("Segoe UI", 14.0F),
            .BackColor = Color.White
        }
        pnlCompanyBox.Controls.Add(txtCompany)

        lblSalary = New Label() With {
            .Text = "MONTHLY SALARY:",
            .AutoSize = True,
            .ForeColor = Color.White,
            .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        }

        pnlSalaryBox = New Panel() With {
            .BackColor = Color.Black,
            .Padding = New Padding(6),
            .Size = New Size(contentPanel.Width - 32, 52)
        }
        txtSalary = New TextBox() With {
            .BorderStyle = BorderStyle.None,
            .Dock = DockStyle.Fill,
            .Font = New Font("Segoe UI", 14.0F),
            .BackColor = Color.White
        }
        pnlSalaryBox.Controls.Add(txtSalary)

        btnCalculate = New Button() With {
            .Text = "ENTER",
            .Width = 180,
            .Height = 56,
            .BackColor = Color.Black,
            .ForeColor = Color.White,
            .Font = New Font("Impact", 16.0F),
            .FlatStyle = FlatStyle.Flat
        }
        btnCalculate.FlatAppearance.BorderColor = Color.White
        btnCalculate.FlatAppearance.BorderSize = 2

        btnClear = New Button() With {
            .Text = "CLEAR",
            .Width = 180,
            .Height = 56,
            .BackColor = Color.Black,
            .ForeColor = Color.White,
            .Font = New Font("Impact", 16.0F),
            .FlatStyle = FlatStyle.Flat
        }
        btnClear.FlatAppearance.BorderColor = Color.White
        btnClear.FlatAppearance.BorderSize = 2

        btnExit = New Button() With {
            .Text = "EXIT",
            .Width = 180,
            .Height = 56,
            .BackColor = Color.DarkRed,
            .ForeColor = Color.White,
            .Font = New Font("Impact", 16.0F),
            .FlatStyle = FlatStyle.Flat
        }
        btnExit.FlatAppearance.BorderColor = Color.FromArgb(200, 0, 0)
        btnExit.FlatAppearance.BorderSize = 2

        contentPanel.Controls.AddRange(New Control() {
            lblEmployee, pnlEmployeeBox,
            lblCompany, pnlCompanyBox,
            lblSalary, pnlSalaryBox,
            btnCalculate, btnClear, btnExit
        })

        Panel1.Controls.Add(contentPanel)
        Me.Controls.Add(Panel1)

        LayoutContent()

        AddHandler btnCalculate.Click, AddressOf btnCalculate_Click
        AddHandler btnClear.Click, AddressOf btnClear_Click
        AddHandler btnExit.Click, AddressOf btnExit_Click
        AddHandler Me.FormClosed, AddressOf Frm_FormClosed
        AddHandler Panel1.Resize, AddressOf Panel1_Resize
        AddHandler Me.Shown, AddressOf frmSalaryCalculator_Shown
    End Sub

    Private Sub LayoutContent()
        Dim xMargin As Integer = 16
        Dim y As Integer = 8

        lblEmployee.Location = New Point(xMargin, y)
        pnlEmployeeBox.Location = New Point(xMargin, lblEmployee.Bottom + 6)
        y = pnlEmployeeBox.Bottom + 18

        lblCompany.Location = New Point(xMargin, y)
        pnlCompanyBox.Location = New Point(xMargin, lblCompany.Bottom + 6)
        y = pnlCompanyBox.Bottom + 18

        lblSalary.Location = New Point(xMargin, y)
        pnlSalaryBox.Location = New Point(xMargin, lblSalary.Bottom + 6)
        y = pnlSalaryBox.Bottom + 28

        Dim gap As Integer = 24
        Dim totalButtonsWidth As Integer = btnCalculate.Width + btnClear.Width + btnExit.Width + gap * 2
        Dim startX As Integer = (contentPanel.Width - totalButtonsWidth) \ 2

        btnCalculate.Location = New Point(startX, y)
        btnClear.Location = New Point(btnCalculate.Right + gap, y)
        btnExit.Location = New Point(btnClear.Right + gap, y)
    End Sub

    Private Sub Panel1_Resize(sender As Object, e As EventArgs)
        contentPanel.Location = New Point((Panel1.ClientSize.Width - contentPanel.Width) \ 2, (Panel1.ClientSize.Height - contentPanel.Height) \ 2)
    End Sub

    Private Sub frmSalaryCalculator_Shown(sender As Object, e As EventArgs)
        Panel1_Resize(Nothing, Nothing)
    End Sub

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(txtEmployee.Text) Then
            MessageBox.Show("Please enter NAME OF EMPLOYEE.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If String.IsNullOrWhiteSpace(txtCompany.Text) Then
            MessageBox.Show("Please enter NAME OF COMPANY.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim monthlySalary As Integer
        If Not Integer.TryParse(txtSalary.Text, monthlySalary) Then
            MessageBox.Show("Please enter a valid MONTHLY SALARY (numeric).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim annualSalary As Integer = monthlySalary * 12
        Dim tax As Double = CalculateIncomeTax(annualSalary)
        Dim sss As Double = CalculateSSSContribution(monthlySalary)
        Dim pagIbig As Double = CalculatePagIbigContribution(monthlySalary)
        Dim philHealth As Double = CalculatePhilHealthContribution(monthlySalary)

        Dim detailsForm As New frmInquiryDetails(txtEmployee.Text, txtCompany.Text, monthlySalary, annualSalary, tax, sss, pagIbig, philHealth)
        detailsForm.Owner = Me

        txtEmployee.Clear()
        txtCompany.Clear()
        txtSalary.Clear()

        detailsForm.Show()
        Me.Hide()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs)
        txtEmployee.Clear()
        txtCompany.Clear()
        txtSalary.Clear()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Function CalculateIncomeTax(annualSalary As Integer) As Double
        Dim taxAnnual As Double
        Dim tax As Double

        If annualSalary < 250000 Then
            tax = 0
        ElseIf annualSalary <= 400000 Then
            taxAnnual = 0.2 * (annualSalary - 250000)
            tax = taxAnnual / 12
        ElseIf annualSalary <= 800000 Then
            taxAnnual = 30000 + 0.25 * (annualSalary - 400000)
            tax = taxAnnual / 12
        ElseIf annualSalary <= 2000000 Then
            taxAnnual = 130000 + 0.3 * (annualSalary - 800000)
            tax = taxAnnual / 12
        ElseIf annualSalary <= 8000000 Then
            taxAnnual = 490000 + 0.32 * (annualSalary - 2000000)
            tax = taxAnnual / 12
        Else
            taxAnnual = 2410000 + 0.35 * (annualSalary - 8000000)
            tax = taxAnnual / 12
        End If

        Return tax
    End Function

    Private Function CalculateSSSContribution(monthlySalary As Integer) As Double
        Dim sss As Double = 80.0
        Dim sssRanges() As Integer = {2250, 2750, 3250, 3750, 4250, 4750, 5250, 5750, 6250, 6750,
                                      7250, 7750, 8250, 8750, 9250, 9750, 10250, 10750, 11250, 11750,
                                      12250, 12750, 13250, 13750, 14250, 14750, 15250, 15750, 16250,
                                      16750, 17250, 17750, 18250, 18750, 19250, 19750}

        For Each range As Integer In sssRanges
            If monthlySalary <= range Then
                Exit For
            End If
            sss += 20.0
        Next

        Return sss
    End Function

    Private Function CalculatePagIbigContribution(monthlySalary As Integer) As Double
        Dim pagIbig As Double
        If monthlySalary < 1500 Then
            pagIbig = 0.01 * monthlySalary
        Else
            pagIbig = 0.02 * monthlySalary
        End If
        Return pagIbig
    End Function

    Private Function CalculatePhilHealthContribution(monthlySalary As Integer) As Double
        Dim philHealth As Double = 100.0

        If monthlySalary < 100 Then
            Return philHealth
        End If

        For salary As Single = 9000 To 35000 Step 1000
            If monthlySalary <= salary Then
                Return philHealth
            End If
            philHealth += 12.5
        Next

        If monthlySalary > 437.5 Then
            Return philHealth
        End If

        Return philHealth
    End Function

    Private Sub Frm_FormClosed(sender As Object, e As FormClosedEventArgs)
        For Each f As Form In Application.OpenForms
            If TypeOf f Is Form1 Then
                CType(f, Form).Show()
                Exit For
            End If
        Next
    End Sub
End Class