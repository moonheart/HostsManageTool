using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostsManageTool.Winform.UserControl
{
    public class TextBoxEx : TextBox
    {
        public override string Text
        {
            get { return base.Text.Trim(); }
            set { base.Text = value?.Trim(); }
        }
    }
}
