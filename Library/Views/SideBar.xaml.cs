// Esse arquivo inicializa a UserControl usada como SideBar, que possui dois botões de redirecionamento (Linkedln e GitHub) e uma logo genérica

using System.Windows.Controls;
using System.Diagnostics;

namespace Library.Views
{
    public partial class SideBar : UserControl
    {
        // CONSTRUTOR

        public SideBar()
        {
            InitializeComponent();
        }

        // MÉTODOS

        private void Btn_GitHub_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // abrindo o navegador padrão com o link 
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/fernandoGonzaga0",
                UseShellExecute = true // abrindo com navegador padrão
            });
        }

        private void Btn_Linkedln_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // abrindo o navegador padrão com o link 
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.linkedin.com/in/fernando-gonzaga21/",
                UseShellExecute = true // abrindo com navegador padrão
            });
        }
    }
}
