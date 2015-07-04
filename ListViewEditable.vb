''' <summary>
''' ListViewEditable will allow a user to edit subitem labels of a listview.
''' </summary>
Public Class ListViewEditable
    Inherits ListView

    Public WithEvents Editbox As New TextBox
    Public HitInfo As ListViewHitTestInfo

    Sub New()
        Me.View = Windows.Forms.View.Details
        Me.GridLines = True
        Me.FullRowSelect = True
        Me.DoubleBuffered = True
        Editbox.Parent = Me
        Editbox.Hide()
    End Sub

    Private Sub ListViewEditable_DoubleClick(sender As Object, e As MouseEventArgs) Handles Me.MouseDoubleClick
        HitInfo = Me.HitTest(e.X, e.Y)
        Editbox.Bounds = HitInfo.SubItem.Bounds
        Editbox.Text = HitInfo.SubItem.Text
        Editbox.Focus()
        Editbox.Show()
    End Sub

    Private Sub Editbox_LostFocus(sender As Object, e As EventArgs) Handles Editbox.LostFocus
        HitInfo.SubItem.Text = Editbox.Text
        Editbox.Hide()
    End Sub
End Class
