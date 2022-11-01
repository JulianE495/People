using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace People
{
    public partial class frPeopleMain : Form
    {
        public frPeopleMain()
        {
            InitializeComponent();
            pnHome.Visible = true;
            pnContacts.Visible = false;
            pnAddContact.Visible = false;
            activedBoton();
            limparCampos();
            mostarDatosTabla();
        }

        private void activedBoton()
        {
            if (pnContacts.Visible == true)
            {
                btnContacts.BackColor = Color.FromArgb(53, 57, 65);
            }
            else
            {
                btnContacts.BackColor = Color.FromArgb(38, 40, 43);
            }

            if (pnAddContact.Visible == true)
            {
                btnAddContact.BackColor = Color.FromArgb(53, 57, 65);
            }
            else
            {
                btnAddContact.BackColor = Color.FromArgb(38, 40, 43);
            }

            if (pnHome.Visible == true)
            {
                btnHome.BackColor = Color.FromArgb(53, 57, 65);
            }
            else
            {
                btnHome.BackColor = Color.FromArgb(38, 40, 43);
            }
        }
        
        private void checkFoM()
        {
            // cbFemale
            if (cbFemale.Checked == true)
            {
                cbMale.Enabled = false;
            }
            else
            {
                cbMale.Enabled = true;
            }
            // cbMale
            if (cbMale.Checked == true)
            {
                cbFemale.Enabled = false;
            }
            else
            {
                cbFemale.Enabled = true;
            }
            // cbFemaleEdit
            if (cbFemaleEdit.Checked == true)
            {
                cbMaleEdit.Enabled = false;
            }
            else
            {
                cbMaleEdit.Enabled = true;
            }
            // cbMaleEdit
            if (cbMaleEdit.Checked == true)
            {
                cbFemaleEdit.Enabled = false;
            }
            else
            {
                cbFemaleEdit.Enabled = true;
            }
        }

        private void checkMaritalStatus()
        {
            // cbSingle
            if (cbSingle.Checked == true)
            {
                cbMarried.Enabled = false;
                cbDivorced.Enabled = false;
                cbWidower.Enabled = false;
            }
            else if(cbSingle.Checked == false)
            {
                cbMarried.Enabled = true;
                cbDivorced.Enabled = true;
                cbWidower.Enabled = true;

                // cbMarried
                if (cbMarried.Checked == true)
                {
                    cbSingle.Enabled = false;
                    cbDivorced.Enabled = false;
                    cbWidower.Enabled = false;
                }
                else if (cbMarried.Checked == false)
                {
                    cbSingle.Enabled = true;
                    cbDivorced.Enabled = true;
                    cbWidower.Enabled = true;

                    // cbDivorced
                    if (cbDivorced.Checked == true)
                    {
                        cbSingle.Enabled = false;
                        cbMarried.Enabled = false;
                        cbWidower.Enabled = false;
                    }
                    else if (cbDivorced.Checked == false)
                    {
                        cbSingle.Enabled = true;
                        cbMarried.Enabled = true;
                        cbWidower.Enabled = true;

                        // cbWidower
                        if (cbWidower.Checked == true)
                        {
                            cbSingle.Enabled = false;
                            cbMarried.Enabled = false;
                            cbDivorced.Enabled = false;
                        }
                        else if (cbWidower.Checked == false)
                        {
                            cbSingle.Enabled = true;
                            cbMarried.Enabled = true;
                            cbDivorced.Enabled = true;
                        }
                    }
                }
            }

            // cbSolteroEdit
            if (cbSolteroEdit.Checked == true)
            {
                cbCasadoEdit.Enabled = false;
                cbDivorciadoEdit.Enabled = false;
                cbViudoEdit.Enabled = false;
            }
            else if (cbSolteroEdit.Checked == false)
            {
                cbCasadoEdit.Enabled = true;
                cbDivorciadoEdit.Enabled = true;
                cbViudoEdit.Enabled = true;

                // cbCasadoEdit
                if (cbCasadoEdit.Checked == true)
                {
                    cbSolteroEdit.Enabled = false;
                    cbDivorciadoEdit.Enabled = false;
                    cbViudoEdit.Enabled = false;
                }
                else if (cbCasadoEdit.Checked == false)
                {
                    cbSolteroEdit.Enabled = true;
                    cbDivorciadoEdit.Enabled = true;
                    cbViudoEdit.Enabled = true;

                    // cbDivorciadoEdit
                    if (cbDivorciadoEdit.Checked == true)
                    {
                        cbSolteroEdit.Enabled = false;
                        cbCasadoEdit.Enabled = false;
                        cbViudoEdit.Enabled = false;
                    }
                    else if (cbDivorciadoEdit.Checked == false)
                    {
                        cbSolteroEdit.Enabled = true;
                        cbCasadoEdit.Enabled = true;
                        cbViudoEdit.Enabled = true;

                        // cbViudoEdit
                        if (cbViudoEdit.Checked == true)
                        {
                            cbSolteroEdit.Enabled = false;
                            cbCasadoEdit.Enabled = false;
                            cbDivorciadoEdit.Enabled = false;
                        }
                        else if (cbViudoEdit.Checked == false)
                        {
                            cbSolteroEdit.Enabled = true;
                            cbCasadoEdit.Enabled = true;
                            cbDivorciadoEdit.Enabled = true;
                        }
                    }
                }
            }

            

        }

        private void limparCampos()
        {
            txtName.Text = "";
            txtLastName.Text = "";
            dateOfBirth.Text = "";
            txtDirection.Text = "";
            cbFemale.Checked = false;
            cbMale.Checked = false;
            cbSingle.Checked = false;
            cbMarried.Checked = false;
            cbDivorced.Checked = false;
            cbWidower.Checked = false;
            txtCel.Text = "";
            txtTel.Text = "";
            txtMail.Text = "";

        }

        private void mostarDatosTabla()
        {

            SqlConnection conexion = new SqlConnection("server = DESKTOP-00KJCV2 ; database = dbPeopleApp ; integrated security = true");
            
            string selectQuery = "SELECT nombre, apellido FROM tblContactos";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, conexion);
            DataSet ds = new DataSet();
            conexion.Open();

            dataAdapter.Fill(ds, "tblContacto");
            conexion.Close();
            tblContactos.DataSource = ds;
            tblContactos.DataMember = "tblContacto";
            tblContactos.DataMember = "tblContacto";
            tblContactos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(38, 40, 43);
        }

        private void buscarContacto()
        {
            string nombre = txtBuscar.Text;
            SqlConnection conexion = new SqlConnection("server = DESKTOP-00KJCV2 ; database = dbPeopleApp ; integrated security = true");

            string selectQuery = "SELECT nombre, apellido FROM tblContactos WHERE nombre LIKE '%" + nombre + "%'";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, conexion);
            DataSet ds = new DataSet();
            conexion.Open();

            dataAdapter.Fill(ds, "tblContacto");
            conexion.Close();
            tblContactos.DataSource = ds;
            tblContactos.DataMember = "tblContacto";
            tblContactos.DataMember = "tblContacto";
            tblContactos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(38, 40, 43);
        }
        private void btnContacts_Click(object sender, EventArgs e)
        {
            if (pnContacts.Visible == false)
            {
                pnContacts.Visible = true;
                pnAddContact.Visible = false;
                pnHome.Visible = false;
                mostarDatosTabla();
                activedBoton();
            }
            else
            {
                pnContacts.Visible = false;
            }
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            if (pnAddContact.Visible == false)
            {
                pnAddContact.Visible = true;
                pnContacts.Visible = false;
                pnHome.Visible = false;
                activedBoton();
                
            }
            else
            {
                pnAddContact.Visible = false;
            }
        }

        private void btnSaveContact_Click(object sender, EventArgs e)
        {
            

            SqlConnection conexion = new SqlConnection("server = DESKTOP-00KJCV2 ; database = dbPeopleApp ; integrated security = true");
            conexion.Open();

            string nombre = txtName.Text;
            string apellido = txtLastName.Text;
            string dob = dateOfBirth.Text;
            string direccion = txtDirection.Text;
            string correo = txtMail.Text;

            string genero = "";
            string estadoCivil = "";
            string celular = txtCel.Text;
            string telefono = txtTel.Text;

            if (cbFemale.Checked == true)
            {
                cbMale.Checked = false;
                genero = "1";
            }
            else if (cbMale.Checked == true)
            {
                cbFemale.Checked = false;
                genero = "2";
            }

            if (cbSingle.Checked == true)
            {
                checkMaritalStatus();
                estadoCivil = "1";
            }
            else if (cbMarried.Checked == true)
            {
                checkMaritalStatus();
                estadoCivil = "2";
            }
            else if (cbDivorced.Checked == true)
            {
                checkMaritalStatus();
                estadoCivil = "3";
            }
            else if (cbWidower.Checked == true)
            {
                checkMaritalStatus();
                estadoCivil = "4";
            }

            string insertQuery = "insert into tblContactos (nombre, apellido, dob, direccion, genero, estadoCivil, celular, telefono, correo, image) values ('" + nombre + "',  '" + apellido + "',  '" + dob + "', '" + direccion + "', " + genero + ",  " + estadoCivil + ", '" + celular + "', '" + telefono + "', '" + correo + "', @image)";
            SqlCommand query = new SqlCommand(insertQuery, conexion);

            byte[] image = File.ReadAllBytes(pbAddPhoto.ImageLocation);

            query.Parameters.AddWithValue("@image", image);
            query.ExecuteNonQuery();

            MessageBox.Show("Contacto agregado correctamente.");
            //pbAddPhoto.ImageLocation = none;
            limparCampos();


        }

        private void cbFemale_CheckedChanged(object sender, EventArgs e)
        {
            checkFoM();
        }

        private void cbMale_CheckedChanged(object sender, EventArgs e)
        {
            checkFoM();
        }

        private void cbSingle_CheckedChanged(object sender, EventArgs e)
        {
            checkMaritalStatus();
        }

        private void cbMarried_CheckedChanged(object sender, EventArgs e)
        {
            checkMaritalStatus();
        }

        private void cbDivorced_CheckedChanged(object sender, EventArgs e)
        {
            checkMaritalStatus();
        }

        private void cbWidower_CheckedChanged(object sender, EventArgs e)
        {
            checkMaritalStatus();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                mostarDatosTabla();
            }
            else
            {
                buscarContacto();
            }
            
            
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            mostarDatosTabla();
        }

        private void tblContactos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server = DESKTOP-00KJCV2 ; database = dbPeopleApp ; integrated security = true");
            conexion.Open();


            string nombre = tblContactos.CurrentRow.Cells[0].Value.ToString();
            string displayQuery = "select nombre, apellido, dob, direccion, genero, estadoCivil, celular, telefono, correo, image FROM tblContactos WHERE nombre = @nombre";

            SqlCommand query = new SqlCommand(displayQuery, conexion);
            query.Parameters.AddWithValue("@nombre", nombre);
            SqlDataReader reader = query.ExecuteReader();
            if (reader.Read())
            {
                Byte[] data = new Byte[0];
                txtDisplayName.Text = reader.GetString(0);
                txtNombreDis.Text = reader.GetString(0);
                txtDisplayLastName.Text = reader.GetString(1);
                txtApellidoDis.Text = reader.GetString(1);
                txtDisplayDOB.Text = reader.GetString(2);
                txtDOBDIS.Text = reader.GetString(2);
                txtDisplayDireccion.Text = reader.GetString(3);
                txtDireccionDis.Text = reader.GetString(3);
                //txtDisplayGenero.Text = reader.GetString(4);


                if (reader.GetString(4) == "0")
                {
                    txtGeneroDis.Text = "NULL";
                }
                else if (reader.GetString(4) == "1")
                {
                    txtGeneroDis.Text = "Femenino";
                }
                else if (reader.GetString(4) == "2")
                {
                    txtGeneroDis.Text = "Masculino";
                }
                else
                {
                    txtGeneroDis.Text = "NULL";
                }

                //txtDisplayEstado.Text = Convert.ToString(reader.GetInt32(5));
                string estado = reader.GetString(5);

                if (estado == "0")
                {
                    txtEstadoDis.Text = "NULL";
                }
                else if (estado == "1")
                {
                    txtEstadoDis.Text = "Soltero/a";
                }
                else if (estado == "2")
                {
                    txtEstadoDis.Text = "Casado/a";
                }
                else if (estado == "3")
                {
                    txtEstadoDis.Text = "Divorciado/a";
                }
                else if (estado == "4")
                {
                    txtEstadoDis.Text = "Viudo/a";
                }
                else
                {
                    txtEstadoDis.Text = "NULL";
                }

                txtDisplayCelular.Text = reader.GetString(6);
                txtCelularDis.Text = reader.GetString(6);
                txtDisplayTelefono.Text = reader.GetString(7);
                txtTelefonoDis.Text = reader.GetString(7);
                txtDisplayCorreo.Text = reader.GetString(8);
                txtCorreoDis.Text = reader.GetString(8);

                
                byte[] imgData = (byte[])reader.GetValue(9);
                Image newImage = null;
                using (MemoryStream ms = new MemoryStream(imgData, 0, imgData.Length))
                {
                    ms.Write(imgData, 0, imgData.Length);
                    newImage = Image.FromStream(ms, true);
                }

                pbProfileDis.Image = newImage;
                pbEditProfilePhoto.Image = newImage;
                pbProfileDis.SizeMode = PictureBoxSizeMode.StretchImage;
                pbEditProfilePhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                newImage = null;
                conexion.Close();
           }
        }

        private void btnUpdateContact_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server = DESKTOP-00KJCV2 ; database = dbPeopleApp ; integrated security = true");
            conexion.Open();
            string deleteQuery = "DELETE FROM tblContactos WHERE nombre = '" + txtNombreDis.Text + "' and apellido = '" + txtApellidoDis.Text + "'";

            SqlCommand queryDelete = new SqlCommand(deleteQuery, conexion);
            queryDelete.ExecuteNonQuery();

            string nombre = txtDisplayName.Text;
            string apellido = txtDisplayLastName.Text;
            string dob = txtDisplayDOB.Text;
            string direccion = txtDisplayDireccion.Text;
            string correo = txtDisplayCorreo.Text;

            string genero = "";
            string estadoCivil = "";
            string celular = txtDisplayCelular.Text;
            string telefono = txtDisplayTelefono.Text;

            if (cbFemaleEdit.Checked == true)
            {
                cbMaleEdit.Checked = false;
                genero = "1";
            }
            else if (cbMaleEdit.Checked == true)
            {
                cbFemaleEdit.Checked = false;
                genero = "2";
            }

            if (cbSolteroEdit.Checked == true)
            {

                estadoCivil = "1";
            }
            else if (cbCasadoEdit.Checked == true)
            {

                estadoCivil = "2";
            }
            else if (cbDivorciadoEdit.Checked == true)
            {

                estadoCivil = "3";
            }
            else if (cbViudoEdit.Checked == true)
            {
                
                estadoCivil = "4";
            }

            string insertQuery = "insert into tblContactos (nombre, apellido, dob, direccion, genero, estadoCivil, celular, telefono, correo, image) values ('" + nombre + "',  '" + apellido + "',  '" + dob + "', '" + direccion + "', " + genero + ",  " + estadoCivil + ", '" + celular + "', '" + telefono + "', '" + correo + "', @image)";
            SqlCommand query = new SqlCommand(insertQuery, conexion);

            byte[] image = File.ReadAllBytes(pbEditProfilePhoto.ImageLocation);

            query.Parameters.AddWithValue("@image", image);
            query.ExecuteNonQuery();

            MessageBox.Show("Contacto editado correctamente.");

            pnEdit.Visible = true;
            pnContact.Visible = false;
            mostarDatosTabla();
        }

        private void btnCancelarEdit_Click(object sender, EventArgs e)
        {
            pnEdit.Visible = true;
            pnContact.Visible = false;
            mostarDatosTabla();
        }

        private void btnEditShow_Click(object sender, EventArgs e)
        {
            pnEdit.Visible = false;
            pnContact.Visible = true;
            mostarDatosTabla();
        }

        private void cbFemaleEdit_CheckedChanged(object sender, EventArgs e)
        {
            checkFoM();
        }

        private void cbMaleEdit_CheckedChanged(object sender, EventArgs e)
        {
            checkFoM();
        }

        private void cbSolteroEdit_CheckedChanged(object sender, EventArgs e)
        {
            checkMaritalStatus();
        }

        private void cbDivorciadoEdit_CheckedChanged(object sender, EventArgs e)
        {
            checkMaritalStatus();
        }

        private void cbCasadoEdit_CheckedChanged(object sender, EventArgs e)
        {
            checkMaritalStatus();
        }

        private void cbViudoEdit_CheckedChanged(object sender, EventArgs e)
        {
            checkMaritalStatus();
        }

        private void btnEliminarCon_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server = DESKTOP-00KJCV2 ; database = dbPeopleApp ; integrated security = true");
            conexion.Open();
            string deleteQuery = "DELETE FROM tblContactos WHERE nombre = '" + txtNombreDis.Text + "' and apellido = '" + txtApellidoDis.Text + "'";

            SqlCommand queryDelete = new SqlCommand(deleteQuery, conexion);
            queryDelete.ExecuteNonQuery();

            MessageBox.Show("Contacto eliminado correctamente.");

            pnEdit.Visible = true;
            pnContact.Visible = false;


            txtDisplayName.Text = "";
            txtDisplayLastName.Text = "";
            txtDisplayDOB.Text = "";
            txtDisplayDireccion.Text = "";
            txtDisplayCorreo.Text = "";

            cbFemaleEdit.Checked = false;
            cbMaleEdit.Checked = false;
            cbSolteroEdit.Checked = false;
            cbCasadoEdit.Checked = false;
            cbDivorciadoEdit.Checked = false;
            cbViudoEdit.Checked = false;

            txtDisplayCelular.Text = "";
            txtDisplayTelefono.Text = "";

            mostarDatosTabla();
        }

        private void btnBuscarIMG_Click(object sender, EventArgs e)
        {
            OpenFileDialog searchIMG = new OpenFileDialog();
            searchIMG.Filter = "Images(.jpg,.png)|*.png;*.jpg";

            if (searchIMG.ShowDialog() == DialogResult.OK)
            {
                pbAddPhoto.ImageLocation = searchIMG.FileName;
                pbAddPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (pnHome.Visible == false)
            {
                pnAddContact.Visible = false;
                pnContacts.Visible = false;
                pnHome.Visible = true;
                activedBoton();

            }
        }

        private void btnEditPhotoChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog searchIMG = new OpenFileDialog();
            searchIMG.Filter = "Images(.jpg,.png)|*.png;*.jpg";

            if (searchIMG.ShowDialog() == DialogResult.OK)
            {
                pbEditProfilePhoto.ImageLocation = searchIMG.FileName;
                pbEditProfilePhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
