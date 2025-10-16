Imports System.Windows.Forms
Imports System.Drawing

Partial Public Class Form1
    Inherits Form

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox1_DataContextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click_1(sender As Object, e As EventArgs) Handles lblTitle.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Start(sender As Object, e As EventArgs) Handles Button1.Click
        ' Open the salary calculator and hide the welcome form
        Dim frm As New frmSalaryCalculator()
        frm.Owner = Me
        frm.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Exit(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result As DialogResult = MessageBox.Show(Me,
                                                    "Are you sure you want to exit?",
                                                    "Confirm Exit",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

End Class