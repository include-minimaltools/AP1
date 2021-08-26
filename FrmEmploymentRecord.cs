using AP1.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AP1
{
    public partial class FrmEmploymentRecord : Form
    {
        private Employee[] database;
        private int employees = 0;
        public FrmEmploymentRecord()
        {
            InitializeComponent();
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateData())
                    return;

                Array.Resize(ref database, employees + 1);
                
                SaveEmployee(employees);
                employees++;
                CalculateBonus();
                dgvEmployee.DataSource = database.ToList();
                MessageBox.Show("Se ha ingresado correctamente el trabajador", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error inesperado, contactarse con el desarrollador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateData())
                    return;

                SaveEmployee(GetIndexByIdCard());
                CalculateBonus();
                dgvEmployee.DataSource = database.ToList();
                MessageBox.Show("Se ha actualizado correctamente el trabajador", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error inesperado, contactarse con el desarrollador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = GetIndexByIdCard(); i < employees - 1; i++)
                    database[i] = database[i + 1];

                employees--;
                database[employees] = new Employee();
                CalculateBonus();
                
                dgvEmployee.DataSource = database.ToList();
                MessageBox.Show("Se ha eliminado correctamente el trabajador", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error inesperado, contactarse con el desarrollador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtIdentificationCard_KeyUp(object sender, KeyEventArgs e)
        {
            int index = GetIndexByIdCard();
            if (index >= 0)
            {
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnInsert.Enabled = false;
                txtName.Text = database[index].Names;
                txtLastName.Text = database[index].LastNames;
                txtSalary.Text = database[index].Salary.ToString();
                txtSons.Text = database[index].Sons.ToString();
            }
            else
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnInsert.Enabled = true;
            }
        }

        private void SaveEmployee(int index)
        {
            database[index] = new Employee()
            {
                IdentificationCard = txtIdentificationCard.Text,
                Names = txtName.Text,
                LastNames = txtLastName.Text,
                Salary = double.Parse(txtSalary.Text),
                Sons = int.Parse(txtSons.Text),
                Bonus = 0,
                NetSalary = double.Parse(txtSalary.Text)
            };
            Clean();
        }

        private void Clean()
        {
            txtIdentificationCard.Clear();
            txtLastName.Clear();
            txtName.Clear();
            txtSalary.Clear();
            txtSons.Clear();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnInsert.Enabled = true;
        }

        private int GetIndexByIdCard()
        {
            string idCard = txtIdentificationCard.Text;

            for (int i = 0; i < employees; i++)
                if (database[i].IdentificationCard == idCard)
                    return i;
            return -1;
        }

        private bool ValidateData()
        {
            try
            {
                // Validar campos
                if (string.IsNullOrEmpty(txtIdentificationCard.Text) ||
                    string.IsNullOrEmpty(txtName.Text) ||
                    string.IsNullOrEmpty(txtLastName.Text) ||
                    string.IsNullOrEmpty(txtSalary.Text) ||
                    string.IsNullOrEmpty(txtSons.Text))
                    throw new Exception("Debe llenar todos los valores para ingresar un nuevo trabajador");

                // Validar enteros en las calificaciones
                if (!txtSalary.Text.All(char.IsNumber) ||
                    !txtSons.Text.All(char.IsNumber))
                    throw new Exception("Debe ingresar un número en los campos de salario e hijos del trabajador");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void CalculateBonus()
        {
            double average = 0;
            for (int i = 0; i < employees; i++)
                average += database[i].Salary / employees;


            for (int i = 0; i < employees; i++)
            {
                database[i].Bonus = database[i].Salary < average ? database[i].Salary * .1 : 0;
                database[i].NetSalary = database[i].Salary + database[i].Bonus;
            }
                
        }
    }
}
