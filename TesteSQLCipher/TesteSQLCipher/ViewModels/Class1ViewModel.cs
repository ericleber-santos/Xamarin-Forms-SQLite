using System.Linq;
using System.Windows.Input;
using TesteSQLCipher.Data;
using TesteSQLCipher.Models;
using TesteSQLCipher.Services;
using Xamarin.Forms;

namespace TesteSQLCipher.ViewModels
{
    public class Class1ViewModel : BaseViewModel
    {
        public ICommand ExibirUltimoCommand => new Command(() => ExibirUltimo(), () => IsNotBusy);

        private string _descricao;
        public string Descricao
        {
            get { return _descricao; }

            set
            {
                SetProperty(ref _descricao, value);               
            }
        }

        Class1DAO _class1DAO;

        public Class1ViewModel()
        {
            Title = "MainPage - TesteSQLCipher";
            _class1DAO = new Class1DAO(DependencyService.Get<ISQLiteDatabasePathProvider>().GetDBPath());
            Descricao = "Clique no Botão \"Exibir Último Registro\"!";
        }

        public bool Atualizar()
        {          
            int codigo = (_class1DAO.ListarTodos().Count() == 0 ? 100 : (int)(_class1DAO.ListarTodos().Max(x => x.CLASS_CODIGO) + 1));

            if (_class1DAO.Atualizar(new Class1() { CLASS_CODIGO = codigo, CLASS_DESCRICAO = $"{codigo} - Testando sqlcipher" }))
            {
                return true;
            }

            return false;
        }

        public void ExibirUltimo()
        {
            if(!IsBusy)
            {
                IsBusy = true;

                Descricao = "Oops deu ruim!";

                if (Atualizar())
                {
                    Descricao = _class1DAO.GetObjetoClass1(_class1DAO.ListarTodos().Max(x => x.ID)).CLASS_DESCRICAO;
                }

                IsBusy = false;
            }            
        }
    }
}
