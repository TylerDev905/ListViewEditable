using System;
using System.Windows.Forms;

/// <summary>
/// # Will create a listview component that has editiable sub items
///  Ronny Frister gave an example of how to do this, i just added a few lines and added it to a class structure to make it more useable.
/// </summary>
class ListViewEditable : ListView
{
    public TextBox editbox = new TextBox();
    public ListViewHitTestInfo hitInfo;

    public ListViewEditable()
    {
        this.GridLines = true;
        this.FullRowSelect = true;
        this.DoubleBuffered = true;
        editbox.Parent = this;
        editbox.Hide();
        editbox.LostFocus += new EventHandler(Editbox_LostFocus);
        this.MouseDoubleClick += new MouseEventHandler(This_DoubleClick);
    }

    private void Editbox_LostFocus(object sender, EventArgs e)
    {
        hitInfo.SubItem.Text = editbox.Text;
        editbox.Hide();
    }

    private void This_DoubleClick(object sender, MouseEventArgs e)
    {
        hitInfo = this.HitTest(e.X, e.Y);
        editbox.Bounds = hitInfo.SubItem.Bounds;
        editbox.Text = hitInfo.SubItem.Text;
        editbox.Focus();
        editbox.Show();
    }
}

