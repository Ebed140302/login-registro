using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace login
{
    public partial class Operaciones : Form
    {
        double precio = 0;
        public Operaciones()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        //Funcion para que muestre el precio y la fecha en el formulario donde se registra las ventas
        private void Operaciones_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Today.Date.ToString("d");
            lblPrecio.Text = (0).ToString("C");
        }

        private void cBoperaciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvHistorial_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //Cerrar Formulario
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        //Funcion para asignar el producto y el precio
        private void cboproducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            string producto = cboproducto.Text;
            if (producto.Equals("Taco")) precio = 15;
            if (producto.Equals("burrito")) precio = 65;
            if (producto.Equals("Hamburguesa")) precio = 60;
            if (producto.Equals("Pirata")) precio = 45;
            if (producto.Equals("Quesadilla")) precio = 35;
            if (producto.Equals("Empalme")) precio = 30;
            if (producto.Equals("Sincronizada")) precio = 100;
            if (producto.Equals("Agua")) precio = 13;
            if (producto.Equals("Jugo")) precio = 15;
            if (producto.Equals("Refresco")) precio = 20;
            lblPrecio.Text = precio.ToString("C");
        }
        //Registar venta
        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            if (cboproducto.SelectedIndex == -1)
                MessageBox.Show("¡Debes seleccionar un producto!");
            else if (tbCantidad.Text == "")
                MessageBox.Show("¡Debes ingresar una cantidad!");
            else if (cboTipo.SelectedIndex == -1)
                MessageBox.Show("¡Debes seleccionar un tipo de pago!");
            else
            {
                string producto = cboproducto.Text;
                int cantidad;
                if (!int.TryParse(tbCantidad.Text, out cantidad))
                {
                    MessageBox.Show("La cantidad debe ser un número entero.");
                    return;
                }
                string tipo = cboTipo.Text;

                double subtotal = cantidad * precio;
                double descuento = 0, recargo = 0;
                if (tipo.Equals("Efectivo"))
                    descuento = 0.1 * subtotal;
                else if (tipo.Equals("Visa/MasterCard"))
                    recargo = 0.1 * subtotal;
                double precioFinal = subtotal - descuento + recargo;

                // Imprimir resultado
                ListViewItem fila = new ListViewItem(producto);
                fila.SubItems.Add(cantidad.ToString());
                fila.SubItems.Add(precio.ToString());
                fila.SubItems.Add(tipo);
                fila.SubItems.Add(descuento.ToString());
                fila.SubItems.Add(recargo.ToString());
                fila.SubItems.Add(precioFinal.ToString());

                listView1.Items.Add(fila);
                btnCancelar_Click(sender, e);
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cboproducto.Text = "(Seleccione un producto)";
            cboTipo.Text = "(Seleccione un metodo de pago)";
            tbCantidad.Clear();
            lblPrecio.Text = (0).ToString("C");
            cboproducto.Focus();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Crear una nueva instancia de libro de Excel
            var workbook = new XSSFWorkbook();

            // Crear una hoja de Excel
            var sheet = workbook.CreateSheet("Ventas");

            // Crear la primera fila de encabezado
            var headerRow = sheet.CreateRow(0);
            headerRow.CreateCell(0).SetCellValue("Producto");
            headerRow.CreateCell(1).SetCellValue("Cantidad");
            headerRow.CreateCell(2).SetCellValue("Precio");
            headerRow.CreateCell(3).SetCellValue("Tipo de Pago");
            headerRow.CreateCell(4).SetCellValue("Descuento");
            headerRow.CreateCell(5).SetCellValue("Recargo");
            headerRow.CreateCell(6).SetCellValue("Precio Final");

            // Agregar los datos de la lista a la hoja de Excel
            int rowNum = 1;
            foreach (ListViewItem fila in listView1.Items)
            {
                var row = sheet.CreateRow(rowNum++);

                row.CreateCell(0).SetCellValue(fila.SubItems[0].Text);
                row.CreateCell(1).SetCellValue(int.Parse(fila.SubItems[1].Text));
                row.CreateCell(2).SetCellValue(double.Parse(fila.SubItems[2].Text));
                row.CreateCell(3).SetCellValue(fila.SubItems[3].Text);
                row.CreateCell(4).SetCellValue(double.Parse(fila.SubItems[4].Text));
                row.CreateCell(5).SetCellValue(double.Parse(fila.SubItems[5].Text));
                row.CreateCell(6).SetCellValue(double.Parse(fila.SubItems[6].Text));
            }

            // Mostrar un cuadro de diálogo para que el usuario seleccione la ubicación y el nombre del archivo
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Guardar ventas en archivo de Excel";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Escribir los datos en el archivo
                using (var fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(fs);
                }

                MessageBox.Show("Las ventas se han guardado en el archivo " + saveFileDialog.FileName);
            }
        }

        private void tbCantidad_TextChanged(object sender, EventArgs e)
        {

        }
    }
}