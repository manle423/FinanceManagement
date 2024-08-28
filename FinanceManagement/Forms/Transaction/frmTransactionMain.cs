using FinanceManagement.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceManagement.Forms.Transaction
{
    
    public partial class frmTransactionMain : Form
    {
        int userId = UserSession.Instance.UserId;
        string username = UserSession.Instance.Username;
        public frmTransactionMain()
        {
            InitializeComponent();
        }

        private void btnToAddCate_Click(object sender, EventArgs e)
        {

        }

        private void cboCateType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmTransactionMain_Load(object sender, EventArgs e)
        {

        }
    }
}
