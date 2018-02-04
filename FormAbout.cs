using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectStatFinder {
	public partial class FormAbout : Form {
		public FormAbout() {
			InitializeComponent();
		}

		private void FormAbout_Load(object sender, EventArgs e) {
			button1.Focus();
			lblVersion.Text = string.Format("Version: {0}", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
		}
	}
}
