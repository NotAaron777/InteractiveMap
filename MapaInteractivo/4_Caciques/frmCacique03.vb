Public Class frmCacique03

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each t As TextBox In pnlScroll.Controls.OfType(Of TextBox)() : t.ReadOnly = True : Next
    End Sub
End Class
