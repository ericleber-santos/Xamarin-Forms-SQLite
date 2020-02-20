using SQLite;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using TesteSQLCipher.Models;

namespace TesteSQLCipher.Data
{
    public class Class1DAO
    {
        readonly SQLiteConnection _encryptedDB;
        public Class1DAO(string dbPath)
        {   
            _encryptedDB = new SQLiteConnection(
                new SQLiteConnectionString(
                    dbPath, 
                    SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create, 
                    true, 
                    key: "suasenha")
                );

            _encryptedDB.CreateTable<Class1>();
        }      

        public bool Atualizar(Class1 novoItem)
        {
            try
            { 
                var itemCadastrado = ListarTodos().FirstOrDefault(i => i.ID == novoItem.ID);

                if (itemCadastrado != null)
                {
                    novoItem.CLASS_CODIGO = (novoItem.CLASS_CODIGO > 0 ? novoItem.CLASS_CODIGO : itemCadastrado.CLASS_CODIGO);
                    novoItem.CLASS_DESCRICAO = (!string.IsNullOrEmpty(novoItem.CLASS_DESCRICAO) ? novoItem.CLASS_DESCRICAO : itemCadastrado.CLASS_DESCRICAO);

                    return _encryptedDB.Update(novoItem) > 0;
                }
                else
                {                    
                    return _encryptedDB.Insert(novoItem) > 0;
                } 
            }
            catch (SQLiteException e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        public List<Class1> ListarTodos()
        {
            StringBuilder query = new StringBuilder();

            query.Append("select ");
            query.Append("     j.* ");
            query.Append("from ");
            query.Append("     [Class1] j ");

            return _encryptedDB.Query<Class1>(query.ToString());
        }

        public Class1 GetObjetoClass1(int id)
        {
            try
            {
                return ListarTodos().FirstOrDefault(i => i.ID == id);
            }
            catch (SQLiteException e)
            {
                Debug.WriteLine(e);
                return null;
            }            
        }
    }
}