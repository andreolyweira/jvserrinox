using jvserrinox.Dal;
using jvserrinox.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jvserrinox.Bll
{
    public class CategoriaBll
    {
        public List<CategoriaInfo> ListarTodas()
        {
            CategoriaDal categoriaDal = new CategoriaDal();

            try
            {
                return categoriaDal.ListarTodas();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            finally
            {
                categoriaDal = null;
            }
        }
    }
}
