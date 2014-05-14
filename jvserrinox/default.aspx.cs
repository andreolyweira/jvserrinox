using jvserrinox.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace jvserrinox
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                //CarregaImgSmall();
                //CarregaImgLarge();
            }
        }

        private void CarregaImgSmall()
        {
            ImagemProdutoBll imagemProdutoBll = new ImagemProdutoBll();
            ProdutoBll produtoBll = new ProdutoBll();

            try
            {
                var lstProdutos = produtoBll.ListarTodos(2);
                if (lstProdutos.Count > 0)
                {
                    rptImgSmall.DataSource = lstProdutos;
                    rptImgSmall.DataBind();
                }
            }
            finally
            {
            }
        }

        private void CarregaImgLarge()
        {
            ImagemProdutoBll imagemProdutoBll = new ImagemProdutoBll();
            ProdutoBll produtoBll = new ProdutoBll();

            try
            {
                var lstProdutos = produtoBll.ListarTodos(1);
                if (lstProdutos.Count > 0)
                {
                    rptImgLarge.DataSource = lstProdutos;
                    rptImgLarge.DataBind();
                }
            }
            finally
            {
            }
        }
    }
}