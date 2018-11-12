using System;
using System.Windows.Forms;

namespace HostsManageTool.Nirvana.UserControl
{
    public class ButtonEx : Button
    {
        /// <summary>
        /// 点击后禁用按钮，防止重复操作
        /// </summary>
        /// <param name="e"></param>

        protected override void OnClick(EventArgs e)
        {
            this.Enabled = false;
            base.OnClick(e);
        }

    }
}
