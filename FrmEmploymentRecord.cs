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
            TopLevel = false;
            Dock = DockStyle.Fill;
            cbOrder.SelectedIndex = 0;
        }

        #region Events
        private void CbOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (employees == 0)
                    return;

                LoadDataTable();
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error inesperado, contactarse con el desarrollador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        #endregion

        #region Methods
        private void LoadDataTable()
        {
            switch (cbOrder.SelectedIndex)
            {
                case 0:
                    MajorBubble();
                    break;
                case 1:
                    MinorBubble();
                    break;
                case 2:
                    SignBubble();
                    break;
                case 3:
                    ShakerSort();
                    break;
                case 4:
                    DirectInsert();
                    break;
                case 5:
                    Shell();
                    break;
                default:
                    break;
            }

            dgvEmployee.DataSource = database.ToList();
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
        #endregion

        #region Sorting Methods
        private void InvertPosition(int pos1, int pos2)
        {
            var temp = database[pos1];
            database[pos1] = database[pos2];
            database[pos2] = temp;
        }

        private void MajorBubble(bool upward = true)
        {
            for (int i = employees - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if ((database[j].Salary > database[j + 1].Salary && upward) || (database[j].Salary < database[j + 1].Salary && !upward))
                    {
                        InvertPosition(j, j + 1);
                    }
                }
            }
        }

        private void DirectInsert()
        {
            for (int i = 1; i < employees; i++)
            {
                var temp = database[i];
                int k = i - 1;

                while ((k >= 0) && (temp.Salary < database[k].Salary))
                {
                    database[k + 1] = database[k];
                    k--;
                }
                database[k + 1] = temp;
            }
        }

        private void Shell()
        {
            bool hasChange;
            int inta = employees;

            while (inta > 0)
            {
                inta = (int)(inta / 2);
                hasChange = true;
                while (hasChange)
                {
                    hasChange = false;
                    for (int i = 0; (i + inta) <= (employees - 1); i++)
                    {
                        if (database[i].Salary > database[i + inta].Salary)
                        {
                            InvertPosition(i, i + inta);
                            hasChange = true;
                        }
                    }
                }
            }
        }

        private void ShakerSort()
        {
            int left = 1, right = employees - 1, k = right;

            while (right >= left)
            {
                for (int i = right; i >= left; i--)
                {
                    if (database[i - 1].Salary > database[i].Salary)
                    {
                        InvertPosition(i - 1, i);
                        k = i;
                    }
                }
                left = k + 1;
                for (int i = left; i <= right; i++)
                {
                    if (database[i - 1].Salary > database[i].Salary)
                    {
                        InvertPosition(i - 1, i);
                        k = i;
                    }
                }
                right = k - 1;
            }
        }

        private void SignBubble()
        {
            bool isFinish = false;
            for (int i = 0; i < employees - 1 && isFinish == false; i++)
            {
                isFinish = true;
                for (int j = 0; j < employees - 1; j++)
                {
                    if (database[j].Salary > database[j + 1].Salary)
                    {
                        InvertPosition(j, j + 1);
                        isFinish = false;
                    }
                }
            }
        }

        private void MinorBubble()
        {
            for (int i = 1; i < employees; i++)
            {
                for (int j = employees - 1; j > 0; j--)
                {
                    if (database[j - 1].Salary > database[j].Salary)
                    {
                        InvertPosition(j, j - 1);
                    }
                }
            }
        }
        #endregion
    }
}
