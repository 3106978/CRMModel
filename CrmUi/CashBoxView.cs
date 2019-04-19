using CrmBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUi
{
   class CashBoxView
    {
        CashDesk cashDesk;
        public System.Windows.Forms.Label CashDeskName { get; set; }
        public NumericUpDown Sum { get; set; }
        public ProgressBar QueueLength { get; set; }
        public System.Windows.Forms.Label LeaveCustomersCount { get; set; }

        public CashBoxView(CashDesk cashDesk, int number, int x, int y)
        {
            this.cashDesk = cashDesk;
            CashDeskName = new System.Windows.Forms.Label();
            Sum = new NumericUpDown();
            QueueLength = new ProgressBar();
            LeaveCustomersCount = new System.Windows.Forms.Label();

            CashDeskName.AutoSize = true;
            CashDeskName.Location = new System.Drawing.Point(x, y);
            CashDeskName.Name = "label" + number;
            CashDeskName.Size = new System.Drawing.Size(35, 13);
            CashDeskName.TabIndex = number;
            CashDeskName.Text =  cashDesk.ToString();

            Sum.Location = new System.Drawing.Point(x + 100, y);
            Sum.Name = "numericUpDown"+ number;
            Sum.Size = new System.Drawing.Size(120, 20);
            Sum.TabIndex = number;
            Sum.Maximum = 10000000000000000000;
            

            QueueLength.Location = new System.Drawing.Point(x+250, y);
            QueueLength.Maximum = cashDesk.MaxQueueLength;
            QueueLength.Name = "progressBar" + number;
            QueueLength.Size = new System.Drawing.Size(100, 23);
            QueueLength.TabIndex = number;
            QueueLength.Value = 0;

            LeaveCustomersCount.AutoSize = true;
            LeaveCustomersCount.Location = new System.Drawing.Point(x + 400, y);
            LeaveCustomersCount.Name = "label2" + number;
            LeaveCustomersCount.Size = new System.Drawing.Size(35, 13);
            LeaveCustomersCount.TabIndex = number;
            LeaveCustomersCount.Text = "";

            cashDesk.CheckClosed += CashDesk_CheckClosed;
        }

        private void CashDesk_CheckClosed(object sender, Check e)
        {
            Sum.Invoke((Action)delegate {

                Sum.Value = +e.Sum;
                QueueLength.Value = cashDesk.Count;
                LeaveCustomersCount.Text = cashDesk.ExitCustomer.ToString();
            });
        }
    }
}
