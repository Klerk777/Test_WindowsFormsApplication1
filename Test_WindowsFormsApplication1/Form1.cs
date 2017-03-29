using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Test_WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private Excel.Application excelapp;
        private Excel.Workbooks excelappworkbooks;
        private Excel.Workbook excelappworkbook;
        private Excel.Window excelWindow;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter email")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
                textBox1.Font = new Font(textBox1.Font, FontStyle.Regular);
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Enter email";
                textBox1.ForeColor = Color.DarkGray;
                textBox1.Font = new Font(textBox1.Font, FontStyle.Italic);

            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Enter group or department")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
                textBox2.Font = new Font(textBox2.Font, FontStyle.Regular);
            }
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Enter group or department";
                textBox2.ForeColor = Color.DarkGray;
                textBox2.Font = new Font(textBox2.Font, FontStyle.Italic);
            }
        }


        // Description to Event submit_button clik
        private void submit_button_Click(object sender, EventArgs e)
        {
            string mail = textBox1.Text, group = textBox2.Text;
            string radiobut1 = "", radiobut2 = "";
            //var buttons1 = groupBox1.Controls.OfType<RadioButton>().Where(n => n.Checked);
            //foreach (RadioButton rb in buttons1)
            //{
            //    textBox3.Text = (rb.Text);
            //}

            //var buttons2 = groupBox2.Controls.OfType<RadioButton>().Where(n => n.Checked);
            //foreach (RadioButton rb in buttons2)
            //{
            //    textBox4.Text = (rb.Text);
            //}

            //groupBox1.Count
            //foreach (RadioButton rb in groupBox1)
            //   for (int i = 0; i < groupBox1.Count; i++)
            //{
            //    if (radioButton[i].Checked)
            //    {
            //        MessegeBox.Show("Нашлась красавица");
            //    }
            //textBox3.Text = (problem + "     " + group);



            //List<RadioButton> buttons = new List<RadioButton>();
            //foreach (GroupBox gb in Controls.OfType<GroupBox>())
            //{
            //    foreach (RadioButton rb in gb.Controls.OfType<RadioButton>())
            //    {
            //        if (rb.Checked)
            //        {
            //            buttons.Add(rb);
            //            break;
            //        }
            //    }
            //}
            //foreach (RadioButton rb in buttons)
            //{
            //    MessageBox.Show(rb.Text);
            //}

            //MessageBox.Show(dateTimePicker1.Text);

            // List<RadioButton> buttons = new List<RadioButton>();
            foreach (RadioButton rb in groupBox1.Controls.OfType<RadioButton>())
            {
                if (rb.Checked)
                {
                    radiobut1 = rb.Text;
                    break;
                }
            }

            foreach (RadioButton rb in groupBox2.Controls.OfType<RadioButton>())
            {
                if (rb.Checked)
                {
                    radiobut2 = rb.Text;
                    break;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                MessageBox.Show((new string[5] { dateTimePicker1.Text, textBox1.Text, textBox2.Text, radiobut1, radiobut2 })[i]);
            }

            //excelapp = new Excel.Application();
            //excelapp.Visible = true;
            //excelapp.SheetsInNewWorkbook = 1;
            //excelapp.Workbooks.Add(Type.Missing);
            excelapp.Cells[1, 1] = dateTimePicker1.Text;
            excelapp.Cells[1, 2] = textBox1.Text;
            excelapp.Cells[1, 3] = textBox2.Text;
            excelapp.Cells[1, 4] = radiobut2;
            excelapp.Cells[1, 5] = radiobut1;
            excelapp.DisplayAlerts = true;
            //excelappworkbooks = excelapp.Workbooks;
            //excelappworkbook = excelappworkbooks[1];
            //excelappworkbook.Saved = true;            
            //excelapp.Quit();
        }


        // Opening links on Event click buttons
        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://neik.nlu.edu.ua");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://oldlib.nlu.edu.ua");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("It's dont work yet, Motherfucka", "Attention!");
        }

        // Refresh form on click "Clear" button
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Enter email";
            textBox1.ForeColor = Color.DarkGray;
            textBox1.Font = new Font(textBox1.Font, FontStyle.Italic);

            textBox2.Text = "Enter group or department";
            textBox2.ForeColor = Color.DarkGray;
            textBox2.Font = new Font(textBox2.Font, FontStyle.Italic);

            foreach (RadioButton rb in groupBox1.Controls.OfType<RadioButton>())
            {
                if (rb.Checked == true)
                { rb.Checked = false; }
            }
            foreach (RadioButton rb in groupBox2.Controls.OfType<RadioButton>())
            {
                if (rb.Checked == true)
                { rb.Checked = false; }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //excelapp.DefaultSaveFormat = Excel.XlFileFormat.xlSYLK;
            //excelapp.Quit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string mySheet = @"‪E:\Book1.xlsx";
            var excelApp = new Excel.Application();
            excelApp.Visible = true;
            Excel.Workbooks books = excelApp.Workbooks;
            try
            {
                Excel.Workbook sheet = books.Open(mySheet);
            }
            catch (COMException ex)
            {
                int error = (ex.ErrorCode);                
                MessageBox.Show(error.ToString());
            }



                //         excelapp.Workbooks.Open(@"C:\Book1.xlsx",
                //Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                //Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                //Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                //Type.Missing, Type.Missing);
            }
        }
}
