using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HW4_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.product_List);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'user_Edit.orders' 資料表。您可以視需要進行移動或移除。
            this.ordersTableAdapter.Fill(this.user_Edit.orders);
            tabControl1.Visible = true;
            tabControl2.Visible = false;
            tabControl3.Visible = false;
            tabControl4.Visible = false;
            tabControl5.Visible = false;
            tabControl6.Visible = false;
            tabControl7.Visible = false;
            tabControl8.Visible = false;
            tabControl9.Visible = false;
            tabControl10.Visible = false;
            tabControl11.Visible = false;
            // TODO: 這行程式碼會將資料載入 'user_Edit.transactions' 資料表。您可以視需要進行移動或移除。
            this.transactionsTableAdapter.Fill(this.user_Edit.transactions);
            // TODO: 這行程式碼會將資料載入 'user_Edit.ratings' 資料表。您可以視需要進行移動或移除。
            this.ratingsTableAdapter.Fill(this.user_Edit.ratings);
            // TODO: 這行程式碼會將資料載入 'driver_Edit.drivers' 資料表。您可以視需要進行移動或移除。
            this.driversTableAdapter.Fill(this.driver_Edit.drivers);
            // TODO: 這行程式碼會將資料載入 'user_Edit.users' 資料表。您可以視需要進行移動或移除。
            this.usersTableAdapter.Fill(this.user_Edit.users);
            // TODO: 這行程式碼會將資料載入 'product_Edit.products' 資料表。您可以視需要進行移動或移除。
            this.productsTableAdapter1.Fill(this.product_Edit.products);
            // TODO: 這行程式碼會將資料載入 'product_List.products' 資料表。您可以視需要進行移動或移除。
            this.productsTableAdapter.Fill(this.product_List.products);

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.productsTableAdapter.FillBy(this.product_List.products, keyworkToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        //add product
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 檢查是否有空的 TextBox 或 ComboBox
                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) ||
                    comboBox1.SelectedValue == null || comboBox2.SelectedValue == null ||
                    comboBox3.SelectedValue == null || string.IsNullOrWhiteSpace(textBox5.Text))
                {
                    MessageBox.Show("Please fill in all required fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult result = MessageBox.Show("Are you sure you want to add the product?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return; // User clicked "No", do not proceed with the insertion
                }

                productsTableAdapter1.InsertQuery(
                    int.Parse(textBox1.Text),
                    textBox2.Text,
                    int.Parse(textBox3.Text),
                    comboBox1.SelectedValue.ToString(),
                    textBox4.Text,
                    comboBox2.SelectedValue.ToString(),
                    int.Parse(comboBox3.SelectedValue.ToString()),
                    int.Parse(textBox5.Text)
                );


                productsTableAdapter.Fill(this.product_List.products);
                MessageBox.Show("Add Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //edit product
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(titleTextBox1.Text) ||
                    string.IsNullOrWhiteSpace(category_idTextBox1.Text) ||
                    string.IsNullOrWhiteSpace(paymentTextBox1.Text) ||
                    string.IsNullOrWhiteSpace(locationTextBox1.Text) ||
                    string.IsNullOrWhiteSpace(countryTextBox1.Text) ||
                    string.IsNullOrWhiteSpace(conditionTextBox1.Text) ||
                    string.IsNullOrWhiteSpace(priceTextBox1.Text) ||
                    string.IsNullOrWhiteSpace(product_idTextBox1.Text))
                {
                    MessageBox.Show("Please fill in all required fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult result = MessageBox.Show("Are you sure you want to update the product?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return;
                }

                productsTableAdapter1.UpdateQuery(
                    titleTextBox1.Text,
                    int.Parse(category_idTextBox1.Text),
                    paymentTextBox1.Text,
                    locationTextBox1.Text,
                    countryTextBox1.Text,
                    int.Parse(conditionTextBox1.Text),
                    int.Parse(priceTextBox1.Text),
                    int.Parse(product_idTextBox1.Text)
                );


                productsTableAdapter.Fill(this.product_List.products);
                MessageBox.Show("Edit Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //delete product
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete the product?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.No)
            {
                return; // User clicked "No", do not proceed with the deletion
            }
            productsTableAdapter1.DeleteQuery(
               int.Parse(product_idTextBox1.Text.ToString())
               );
            productsTableAdapter.Fill(this.product_List.products);
            MessageBox.Show("Delete success");
        }

        //add user
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(textBox6.Text) ||
                    string.IsNullOrWhiteSpace(textBox7.Text) ||
                    string.IsNullOrWhiteSpace(textBox8.Text) ||
                    string.IsNullOrWhiteSpace(textBox9.Text) ||
                    comboBox4.SelectedValue == null ||
                    string.IsNullOrWhiteSpace(textBox10.Text) ||
                    comboBox5.SelectedValue == null)
                {
                    MessageBox.Show("Please fill in all required fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 檢查是否有選擇日期
                if (monthCalendar1.SelectionStart == DateTime.MinValue)
                {
                    MessageBox.Show("Please select a date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult result = MessageBox.Show("Are you sure you want to add the user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return; // User clicked "No", do not proceed with the insertion
                }
                usersTableAdapter.InsertQuery(
                    int.Parse(textBox6.Text),
                    textBox7.Text,
                    textBox8.Text,
                    textBox9.Text,
                    comboBox4.SelectedValue.ToString(),
                    monthCalendar1.SelectionStart.ToString("yyyy-MM-dd"), // 生日
                    int.Parse(textBox10.Text),
                    comboBox5.SelectedValue.ToString()
                );

                // 更新使用者資料表
                usersTableAdapter.Fill(this.user_Edit.users);
                MessageBox.Show("Add Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //edit user
        private void button5_Click(object sender, EventArgs e)
        {
            monthCalendar1.MaxSelectionCount = 1;

            try
            {

                if (string.IsNullOrWhiteSpace(first_nameTextBox.Text) ||
                    string.IsNullOrWhiteSpace(last_nameTextBox.Text) ||
                    string.IsNullOrWhiteSpace(emailTextBox.Text) ||
                    string.IsNullOrWhiteSpace(genderTextBox.Text) ||
                    string.IsNullOrWhiteSpace(birthdayTextBox.Text) ||
                    string.IsNullOrWhiteSpace(ageTextBox.Text) ||
                    string.IsNullOrWhiteSpace(membershipTextBox.Text) ||
                    string.IsNullOrWhiteSpace(user_idTextBox.Text))
                {
                    MessageBox.Show("Please fill in all required fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DialogResult result = MessageBox.Show("Are you sure you want to update the user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return;
                }

                usersTableAdapter.UpdateQuery(
                    first_nameTextBox.Text,
                    last_nameTextBox.Text,
                    emailTextBox.Text,
                    genderTextBox.Text,
                    birthdayTextBox.Text,
                    int.Parse(ageTextBox.Text),
                    membershipTextBox.Text,
                    int.Parse(user_idTextBox.Text)
                );


                usersTableAdapter.Fill(this.user_Edit.users);
                MessageBox.Show("Edit Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //delete user
        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete the user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return; 
            }
            usersTableAdapter.DeleteQuery(
               int.Parse(user_idTextBox.Text.ToString())
               );
            usersTableAdapter.Fill(this.user_Edit.users);
            MessageBox.Show("Delete Success");
        }

        //add driver
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(textBox12.Text) ||
                    string.IsNullOrWhiteSpace(textBox13.Text) ||
                    string.IsNullOrWhiteSpace(textBox14.Text) ||
                    string.IsNullOrWhiteSpace(textBox15.Text) ||
                    string.IsNullOrWhiteSpace(textBox16.Text) ||
                    string.IsNullOrWhiteSpace(textBox17.Text))
                {
                    MessageBox.Show("Please fill in all required fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("Are you sure you want to add the driver?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return; 
                }
                driversTableAdapter.InsertQuery(
                    int.Parse(textBox12.Text),
                    int.Parse(textBox13.Text),
                    int.Parse(textBox14.Text),
                    textBox15.Text,
                    textBox16.Text,
                    textBox17.Text
                );

                // 更新司機資料表
                driversTableAdapter.Fill(this.driver_Edit.drivers);
                MessageBox.Show("Add Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //edit driver
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(ageTextBox1.Text) ||
                    string.IsNullOrWhiteSpace(rental_serviceTextBox.Text) ||
                    string.IsNullOrWhiteSpace(phone_numberTextBox.Text) ||
                    string.IsNullOrWhiteSpace(first_nameTextBox1.Text) ||
                    string.IsNullOrWhiteSpace(last_nameTextBox1.Text) ||
                    string.IsNullOrWhiteSpace(driver_idTextBox.Text))
                {
                    MessageBox.Show("Please fill in all required fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("Are you sure you want to update the driver?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return; 
                }
                driversTableAdapter.UpdateQuery(
                    int.Parse(ageTextBox1.Text),
                    int.Parse(rental_serviceTextBox.Text),
                    phone_numberTextBox.Text,
                    first_nameTextBox1.Text,
                    last_nameTextBox1.Text,
                    int.Parse(driver_idTextBox.Text)
                );

                // 更新司機資料表
                driversTableAdapter.Fill(this.driver_Edit.drivers);
                MessageBox.Show("Edit Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 

        //delete driver
        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete the driver?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return; // User clicked "No", do not proceed with the deletion
            }
            driversTableAdapter.DeleteQuery(
               int.Parse(driver_idTextBox.Text.ToString())
               );
            driversTableAdapter.Fill(this.driver_Edit.drivers);
            MessageBox.Show("Delete Success");
        }

        //search product
        private void searchProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = true;
            tabControl2.Visible = false;
            tabControl3.Visible = false;
            tabControl4.Visible = false;
            tabControl5.Visible = false;
            tabControl6.Visible = false;
            tabControl7.Visible = false;
            tabControl8.Visible = false;
            tabControl9.Visible = false;
            tabControl10.Visible = false;
            tabControl11.Visible = false;
        }

        //add product
        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            tabControl2.Visible = true;
            tabControl3.Visible = false;
            tabControl4.Visible = false;
            tabControl5.Visible = false;
            tabControl6.Visible = false;
            tabControl7.Visible = false;
            tabControl8.Visible = false;
            tabControl9.Visible = false;
            tabControl10.Visible = false;
            tabControl11.Visible = false;
        }

        //edit product
        private void productToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            tabControl2.Visible = false;
            tabControl3.Visible = true;
            tabControl4.Visible = false;
            tabControl5.Visible = false;
            tabControl6.Visible = false;
            tabControl7.Visible = false;
            tabControl8.Visible = false;
            tabControl9.Visible = false;
            tabControl10.Visible = false;
            tabControl11.Visible = false;
        }

        //delete product
        private void productToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            tabControl2.Visible = false;
            tabControl3.Visible = false;
            tabControl4.Visible = true;
            tabControl5.Visible = false;
            tabControl6.Visible = false;
            tabControl7.Visible = false;
            tabControl8.Visible = false;
            tabControl9.Visible = false;
            tabControl10.Visible = false;
            tabControl11.Visible = false;
        }


        //add user
        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            tabControl2.Visible = false;
            tabControl3.Visible = false;
            tabControl4.Visible = false;
            tabControl5.Visible = true;
            tabControl6.Visible = false;
            tabControl7.Visible = false;
            tabControl8.Visible = false;
            tabControl9.Visible = false;
            tabControl10.Visible = false;
            tabControl11.Visible = false;
        }

        //edit user
        private void userToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            tabControl2.Visible = false;
            tabControl3.Visible = false;
            tabControl4.Visible = false;
            tabControl5.Visible = false;
            tabControl6.Visible = true;
            tabControl7.Visible = false;
            tabControl8.Visible = false;
            tabControl9.Visible = false;
            tabControl10.Visible = false;
            tabControl11.Visible = false;
        }

        //delete user
        private void userToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            tabControl2.Visible = false;
            tabControl3.Visible = false;
            tabControl4.Visible = false;
            tabControl5.Visible = false;
            tabControl6.Visible = false;
            tabControl7.Visible = true;
            tabControl8.Visible = false;
            tabControl9.Visible = false;
            tabControl10.Visible = false;
            tabControl11.Visible = false;
        }

        private void driverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            tabControl2.Visible = false;
            tabControl3.Visible = false;
            tabControl4.Visible = false;
            tabControl5.Visible = false;
            tabControl6.Visible = false;
            tabControl7.Visible = false;
            tabControl8.Visible = true;
            tabControl9.Visible = false;
            tabControl10.Visible = false;
            tabControl11.Visible = false;
        }

        private void driverToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            tabControl2.Visible = false;
            tabControl3.Visible = false;
            tabControl4.Visible = false;
            tabControl5.Visible = false;
            tabControl6.Visible = false;
            tabControl7.Visible = false;
            tabControl8.Visible = false;
            tabControl9.Visible = true;
            tabControl10.Visible = false;
            tabControl11.Visible = false;
        }

        private void driverToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            tabControl2.Visible = false;
            tabControl3.Visible = false;
            tabControl4.Visible = false;
            tabControl5.Visible = false;
            tabControl6.Visible = false;
            tabControl7.Visible = false;
            tabControl8.Visible = false;
            tabControl9.Visible = false;
            tabControl10.Visible = true;
            tabControl11.Visible = false;

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            tabControl2.Visible = false;
            tabControl3.Visible = false;
            tabControl4.Visible = false;
            tabControl5.Visible = false;
            tabControl6.Visible = false;
            tabControl7.Visible = false;
            tabControl8.Visible = false;
            tabControl9.Visible = false;
            tabControl10.Visible = false;
            tabControl11.Visible = true;
        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
