namespace login
{
    public partial class Form1 : Form
    {
        Operaciones Operaciones = new Operaciones();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void contrasena_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbUsuario_Click(object sender, EventArgs e)
        {

        }


        private void btIngresar_Click(object sender, EventArgs e)
        {
            string usuario = Nombre_usuario.Text;
            string contrase�a = contrasena.Text;
            if (usuario == "admin" && contrase�a == "1234")
            {
                MessageBox.Show("Contrase�a correcta");
                Operaciones.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Contrase�a incorrecta");
            }

        }
    }
}