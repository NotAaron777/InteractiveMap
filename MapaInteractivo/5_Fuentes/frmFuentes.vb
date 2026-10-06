Public Class frmFuentes

    Private Sub frmFuentes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFuentes.ReadOnly = True
        txtFuentes.SelectionStart = 0
        txtFuentes.SelectionLength = 0
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

End Class