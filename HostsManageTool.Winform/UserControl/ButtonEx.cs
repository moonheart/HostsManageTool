using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostsManageTool.Winform.UserControl
{
    public class ButtonEx : Button
    {

        //public delegate void OperationFinishedDelegate();

        //public OperationFinishedDelegate OperationFinishedEvent;

        protected override void OnClick(EventArgs e)
        {
            this.Enabled = false;
            base.OnClick(e);
        }

    }
}
