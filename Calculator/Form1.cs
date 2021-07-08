using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        decimal[] nums = new decimal[10];
        string[] ops = new string[9];
        int control = 0;
        decimal total = 0;
        bool equal = false;
        bool flipflop = true;
        int keydown;
        bool canwrite = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
            panel1.Visible = flipflop;
            int i;
            for (i = 0; i < 10; i++)
            {
                nums[i] = 0;
            }
            for (i = 0; i < 9; i++)
            {
                ops[i] = "e";
            }
        }

        private void btn_num_click(object sender, EventArgs e)
        {
            try
            {
                if (equal == false)
                {
                    if (control > 9)
                    {

                    }
                    else
                    {
                        if (Convert.ToString(nums[control]).Length == 9)
                        {

                        }
                        else
                        {
                            Button bt = (Button)sender;
                            if (bt.Text == ".") nums[control] = Convert.ToDecimal(Convert.ToString(nums[control]) + ",0");
                            else
                            {
                                if (Convert.ToString(nums[control]).Contains(",0"))
                                {
                                    nums[control] = Convert.ToDecimal(Convert.ToString(Convert.ToInt32(nums[control]) + "," + bt.Text));
                                }
                                else
                                {
                                    nums[control] = Convert.ToDecimal(Convert.ToString(nums[control]) + bt.Text);
                                }

                            }
                            label1.Text = label1.Text + bt.Text;
                        }
                    }
                }
            }
            catch
            {

            }
            
        }

        private void btn_plus_Click(object sender, EventArgs e)
        {
            if (control > 9)
            {

            }
            else
            {
                if (nums[control] == 0)
                {

                }
                else
                {
                    if (ops[8] == "e")
                    {
                        ops[control] = "+";
                        label1.Text = label1.Text + " + ";
                    }
                    control++;
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (control > 9)
            {

            }
            else
            {
                if (nums[control] == 0)
                {

                }
                else
                {
                    if (ops[8] == "e")
                    {
                        ops[control] = "-";
                        label1.Text = label1.Text + " - ";
                    }
                    control++;
                }
            }
        }
        private void equal_func()
        {
            try
            {
                if (equal == false)
                {
                    equal = true;
                    int i;
                    bool plus = false;
                    for (i = 0; i < 9; i++)
                    {
                        bool istimes = false;
                        if (ops[i] == "*")
                        {
                            istimes = true;
                            decimal times = 0;
                            times = nums[i] * nums[i + 1];
                            nums[i] = times;
                            if (ops[i + 1] == "e" && i == 0)
                            {
                                label2.Text = "= " + Convert.ToString(times);
                            }
                            else if (ops[i] != "e")
                            {
                                int i2;
                                for (i2 = i; i2 < 7; i2++)
                                {
                                    ops[i2] = ops[i2 + 1];
                                    nums[i2 + 1] = nums[i2 + 2];
                                }
                                i--;
                            }

                        }
                        if (istimes == false)
                        {


                            if (ops[i] == "/")
                            {
                                decimal divide = 0;
                                divide = nums[i] / nums[i + 1];
                                nums[i] = divide;
                                if (ops[i + 1] == "e" && i == 0)
                                {
                                    label2.Text = "= " + Convert.ToString(divide);
                                }
                                else if (ops[i] != "e")
                                {
                                    int i2;
                                    for (i2 = i; i2 < 7; i2++)
                                    {
                                        ops[i2] = ops[i2 + 1];
                                        nums[i2 + 1] = nums[i2 + 2];
                                    }
                                    i--;
                                }
                            }
                        }
                        if (i == 8)
                            plus = true;
                    }
                    if (plus == true)
                    {


                        for (i = 0; i < 9; i++)
                        {
                            if (i == 0)
                            {
                                if (ops[i] == "+")
                                {
                                    int i2 = i + 1;
                                    total = total + nums[i] + nums[i2];
                                    if (ops[i2] == "e")
                                    {
                                        label2.Text = "= " + Convert.ToString(total);
                                    }
                                }
                                else if (ops[i] == "-")
                                {
                                    int i2 = i + 1;
                                    total = total + nums[i] - nums[i2];
                                    if (ops[i2] == "e")
                                    {
                                        label2.Text = "= " + Convert.ToString(total);
                                    }
                                }
                            }
                            else
                            {
                                if (ops[i] == "+")
                                {
                                    int i2 = i + 1;
                                    total = total + nums[i2];
                                    if (ops[i + 1] == "e")
                                    {
                                        label2.Text = "= " + Convert.ToString(total);
                                    }
                                }
                                else if (ops[i] == "-")
                                {
                                    int i2 = i + 1;
                                    total = total - nums[i2];
                                    if (ops[i + 1] == "e")
                                    {
                                        label2.Text = "= " + Convert.ToString(total);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            equal_func();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            int i;
            control = 0;
            label1.Text = "";
            label2.Text = "";
            total = 0;
            
            for (i = 0; i < 10; i++)
            {
                nums[i] = 0;
            }
            for (i = 0; i < 9; i++)
            {
                ops[i] = "e";
            }
            equal = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = Convert.ToString(nums[0]);
            label4.Text = Convert.ToString(nums[1]);
            label5.Text = Convert.ToString(nums[2]);
            label6.Text = Convert.ToString(nums[3]);
            label7.Text = Convert.ToString(nums[4]);
            label8.Text = Convert.ToString(nums[5]);
            label9.Text = Convert.ToString(nums[6]);
            label10.Text = Convert.ToString(nums[7]);
            label11.Text = Convert.ToString(nums[8]);
            label12.Text = Convert.ToString(nums[9]);


            label13.Text = ops[0];
            label14.Text = ops[1];
            label15.Text = ops[2];
            label16.Text = ops[3];
            label17.Text = ops[4];
            label18.Text = ops[5];
            label19.Text = ops[6];
            label20.Text = ops[7];
            label21.Text = ops[8];
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (control > 9)
            {

            }
            else
            {
                if (nums[control] == 0)
                {

                }
                else
                {
                    if (ops[8] == "e")
                    {
                        ops[control] = "*";
                        label1.Text = label1.Text + " X ";
                    }
                    control++;
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (control > 9)
            {

            }
            else
            {
                if (nums[control] == 0)
                {

                }
                else
                {
                    if (ops[8] == "e")
                    {
                        ops[control] = "/";
                        label1.Text = label1.Text + " / ";
                    }
                    control++;
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if(flipflop == false)
            {
                panel1.Visible = true;
                flipflop = true;
                return;
            }
            if(flipflop == true)
            {
                panel1.Visible = false;
                flipflop = false;
                return;
            }
        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad1:
                    keydown = 1;
                    canwrite = true;
                    break;
                case Keys.NumPad2:
                    keydown = 2;
                    canwrite = true;
                    break;
                case Keys.NumPad3:
                    keydown = 3;
                    canwrite = true;
                    break;
                case Keys.NumPad4:
                    keydown = 4;
                    canwrite = true;
                    break;
                case Keys.NumPad5:
                    keydown = 5;
                    canwrite = true;
                    break;
                case Keys.NumPad6:
                    keydown = 6;
                    canwrite = true;
                    break;
                case Keys.NumPad7:
                    keydown = 7;
                    canwrite = true;
                    break;
                case Keys.NumPad8:
                    keydown = 8;
                    canwrite = true;
                    break;
                case Keys.NumPad9:
                    keydown = 9;
                    canwrite = true;
                    break;
                case Keys.NumPad0:
                    keydown = 0;
                    canwrite = true;
                    break;
                case Keys.Multiply:
                    button14.PerformClick();
                    canwrite = false;
                    return;
                case Keys.Divide:
                    button15.PerformClick();
                    canwrite = false;
                    return;
                case Keys.Subtract:
                    button13.PerformClick();
                    canwrite = false;
                    return;
                case Keys.Add:
                    btn_plus.PerformClick();
                    canwrite = false;
                    return;
                case Keys.Enter:
                    equal_func();
                    canwrite = false;
                    return;
            }

            if (canwrite == true)
            {


                if (equal == false)
                {
                    if (control > 9)
                    {

                    }
                    else
                    {
                        if (Convert.ToString(nums[control]).Length == 9)
                        {

                        }
                        else
                        {
                            nums[control] = Convert.ToInt32(Convert.ToString(nums[control]) + Convert.ToString(keydown));

                            label1.Text = label1.Text + Convert.ToString(keydown);
                        }
                    }
                }
                canwrite = false;
            }
        }

        private void btn_num_keydown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad1:
                    keydown = 1;
                    canwrite = true;
                    break;
                case Keys.NumPad2:
                    keydown = 2;
                    canwrite = true;
                    break;
                case Keys.NumPad3:
                    keydown = 3;
                    canwrite = true;
                    break;
                case Keys.NumPad4:
                    keydown = 4;
                    canwrite = true;
                    break;
                case Keys.NumPad5:
                    keydown = 5;
                    canwrite = true;
                    break;
                case Keys.NumPad6:
                    keydown = 6;
                    canwrite = true;
                    break;
                case Keys.NumPad7:
                    keydown = 7;
                    canwrite = true;
                    break;
                case Keys.NumPad8:
                    keydown = 8;
                    canwrite = true;
                    break;
                case Keys.NumPad9:
                    keydown = 9;
                    canwrite = true;
                    break;
                case Keys.NumPad0:
                    keydown = 0;
                    canwrite = true;
                    break;
                case Keys.Multiply:
                    button14.PerformClick();
                    canwrite = false;
                    return;
                case Keys.Divide:
                    button15.PerformClick();
                    canwrite = false;
                    return;
                case Keys.Subtract:
                    button13.PerformClick();
                    canwrite = false;
                    return;
                case Keys.Add:
                    btn_plus.PerformClick();
                    canwrite = false;
                    return;
                case Keys.Enter:
                    equal_func();
                    canwrite = false;
                    return;
            }

            if (canwrite == true)
            {


                if (equal == false)
                {
                    if (control > 9)
                    {

                    }
                    else
                    {
                        if (Convert.ToString(nums[control]).Length == 9)
                        {

                        }
                        else
                        {
                            nums[control] = Convert.ToInt32(Convert.ToString(nums[control]) + Convert.ToString(keydown));

                            label1.Text = label1.Text + Convert.ToString(keydown);
                        }
                    }
                }
                canwrite = false;
            }
        }

        
    }
}
