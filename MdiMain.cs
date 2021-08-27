using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AP1
{
    public partial class MdiMain : Form
    {
        FrmAbout frmAbout = new FrmAbout();
        FrmAcademyRecord frmAcademyRecord = new FrmAcademyRecord();
        FrmEmploymentRecord frmEmploymentRecord = new FrmEmploymentRecord();
        public MdiMain()
        {
            InitializeComponent();
        }
        private void MdiMain_Load(object sender, EventArgs e)
        {
            ContainerPanel.Controls.Add(frmAbout);
            ContainerPanel.Controls.Add(frmEmploymentRecord);
            ContainerPanel.Controls.Add(frmAcademyRecord);
            frmAbout.Show();
        }

        private void BtnFrmAcademyRecord_Click(object sender, EventArgs e)
        {
            pbUni.Visible = true;
            frmAbout.Hide();
            frmEmploymentRecord.Hide();
            frmAcademyRecord.Show();
        }

        private void BtnEmploymentRecord_Click(object sender, EventArgs e)
        {
            pbUni.Visible = true;
            frmAbout.Hide();
            frmEmploymentRecord.Show();
            frmAcademyRecord.Hide();
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            pbUni.Visible = false;
            frmAbout.Show();
            frmEmploymentRecord.Hide();
            frmAcademyRecord.Hide();
        }
    }
}
