using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Calculadora_V._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //incializamos a null porque las variables deben estar vacias
        double? numero1 = null;
        double? numero2 = null;
        string? operador = null;
        bool esNuevoNumero = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnNumero_Click(object sender, RoutedEventArgs e)
        {
            //captuarmos el boton que lanzo el evento
            Button boton = (Button)sender;
            string digito = boton.Content.ToString();


            if (txtDisplay.Text == "0" || esNuevoNumero)
            {
                txtDisplay.Text = digito;
                esNuevoNumero = false;
            }
            else {
                txtDisplay.Text += digito;
            }
                                
        }

        public void BtnOperador_Click(object sender, RoutedEventArgs e)
        {

            Double valorActual = double.Parse(txtDisplay.Text);
            Button boton = (Button)sender;
            String opSeleccionado = boton.Content.ToString();

            if (opSeleccionado == "%")
            {

                txtDisplay.Text = (valorActual / 100).ToString();
                return;

            }

            numero1 = valorActual;
            operador = opSeleccionado;
            esNuevoNumero = true;
        }

        private void BtnIgual_Click(object sender, RoutedEventArgs e)
        {
            if (operador == null) return;
            numero2 = double.Parse(txtDisplay.Text);

            Double resultado = 0;
            switch (operador)
            {
                case "+": resultado = numero1.Value + numero2.Value; break;
                case "-": resultado = numero1.Value - numero2.Value; break;
                case "*": resultado = numero1.Value * numero2.Value; break;

                case "/":

                    if (numero2.Value == 0)
                    {

                        txtDisplay.Text = "Error";
                        ResetEstado();
                        return;
                    }
                resultado = numero1.Value / numero2.Value; break;
                
            }

            //permitir operaciones nuevas basadas en resulado subyacente
            txtDisplay.Text = resultado.ToString();
            numero1 = resultado;
            operador = null;
            esNuevoNumero = true;
        }
                        
       private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = "0";
            ResetEstado();
        }

        private void ResetEstado() {
            numero1 = null;
            numero2 = null;
            operador = null;
            esNuevoNumero = true;
        }

    }
    
    
}