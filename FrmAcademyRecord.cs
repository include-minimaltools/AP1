using AP1.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AP1
{
    public partial class FrmAcademyRecord : Form
    {
        private Student[] database;
        private int students = 0;
        public FrmAcademyRecord()
        {
            InitializeComponent();
            TopLevel = false;
            Dock = DockStyle.Fill;
        }

        #region Events
        private void CbOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbOrder.SelectedIndex == 0)
                    MajorBubble(false);
                else
                    MajorBubble();
                
                dgvStudents.DataSource = database.ToList();
            }   
            catch
            {
                MessageBox.Show("Ha ocurrido un error inesperado, contactarse con el desarrollador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MajorBubble(bool upward = true)
        {
            for (int i = students - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if ((database[j].FinalNote > database[j + 1].FinalNote && upward) || (database[j].FinalNote < database[j + 1].FinalNote && !upward))
                    {
                        Student aux = database[j];
                        database[j] = database[j + 1];
                        database[j + 1] = aux;
                    }
                }
            }
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateData())
                    return;

                Array.Resize(ref database, students + 1);

                SaveStudent(students);

                Clean();
                dgvStudents.DataSource = database.ToList();
                students++;
                CalculateStats();
                MessageBox.Show("Se ha ingresado correctamente el estudiante", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                SaveStudent(GetIndexByIdCard());
                Clean();
                dgvStudents.DataSource = database.ToList();
                CalculateStats();
                MessageBox.Show("Se ha actualizado correctamente el estudiante", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                for (int i = GetIndexByIdCard(); i < students - 1; i++)
                    database[i] = database[i + 1];

                students--;
                database[students] = new Student();


                Clean();
                dgvStudents.DataSource = database.ToList();
                CalculateStats();
                MessageBox.Show("Se ha eliminado correctamente el estudiante", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error inesperado, contactarse con el desarrollador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtIdCard_KeyUp(object sender, KeyEventArgs e)
        {
            int index = GetIndexByIdCard();
            if (index >= 0)
            {
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnInsert.Enabled = false;
                txtName.Text = database[index].Name;
                txtLastName.Text = database[index].LastName;
                txtFirstPartial.Text = database[index].FirstPartial.ToString();
                txtSecondPartial.Text = database[index].SecondPartial.ToString();
                txtSystematic.Text = database[index].Systematic.ToString();
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
        private void SaveStudent(int index)
        {
            database[index] = new Student()
            {
                IdCard = txtIdCard.Text,
                Name = txtName.Text,
                LastName = txtLastName.Text,
                FirstPartial = int.Parse(txtFirstPartial.Text),
                SecondPartial = int.Parse(txtSecondPartial.Text),
                Systematic = int.Parse(txtSystematic.Text),
                FinalNote = Math.Round(
                    (double)(int.Parse(txtFirstPartial.Text) + int.Parse(txtSecondPartial.Text) + int.Parse(txtSystematic.Text)) / 3
                    , 2)
            };
        }

        private bool ValidateData()
        {
            try
            {
                // Validar campos
                if (string.IsNullOrEmpty(txtIdCard.Text) ||
                    string.IsNullOrEmpty(txtName.Text) ||
                    string.IsNullOrEmpty(txtLastName.Text) ||
                    string.IsNullOrEmpty(txtFirstPartial.Text) ||
                    string.IsNullOrEmpty(txtSecondPartial.Text) ||
                    string.IsNullOrEmpty(txtSystematic.Text))
                    throw new Exception("Debe llenar todos los valores para ingresar un nuevo estudiante");

                // Validar enteros en las calificaciones
                if (!txtSecondPartial.Text.All(char.IsNumber) ||
                    !txtFirstPartial.Text.All(char.IsNumber) ||
                    !txtSystematic.Text.All(char.IsNumber)
                    )
                    throw new Exception("Debe ingresar un número para las calificaciones");                

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void Clean()
        {
            txtIdCard.Clear();
            txtName.Clear();
            txtLastName.Clear();
            txtFirstPartial.Clear();
            txtSecondPartial.Clear();
            txtSystematic.Clear();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnInsert.Enabled = true;
        }

        private void CalculateStats()
        {
            Student bestStudent = database[0] == null ? new Student() : database[0];
            double average = 0;
            for (int i = 0; i < students; i++)
            {
                if (i < students - 1)
                    if (database[i].FinalNote > database[i + 1].FinalNote)
                        bestStudent = database[i];
                    else
                        bestStudent = database[i + 1];

                average += database[i].FinalNote / students;
            }

            lblAverage.Text = "Promedio del salón: " + average;
            lblBestStudent.Text = $"Mejor estudiante: {bestStudent.Name} {bestStudent.LastName}";
        }

        private int GetIndexByIdCard()
        {
            string idCard = txtIdCard.Text;

            for(int i = 0; i < students; i++)
                if (database[i].IdCard == idCard)
                    return i;
            return -1;
        }
        #endregion

        
    }
}