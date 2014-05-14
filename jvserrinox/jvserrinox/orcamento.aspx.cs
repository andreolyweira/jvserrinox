using jvserrinox.Bll;
using jvserrinox.Model;
using Nucleo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace jvserrinox
{
    public partial class orcamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregaCategoria();
                ddlCategoria_SelectedIndexChanged(ddlCategoria, new EventArgs());
            }
        }

        private void CarregaCategoria()
        {
            CategoriaBll categoriaBll = new CategoriaBll();
            List<CategoriaInfo> lstCategoriaInfo = new List<CategoriaInfo>();

            try
            {
                lstCategoriaInfo = categoriaBll.ListarTodas();
                if (lstCategoriaInfo.Count > 0)
                {
                    lstCategoriaInfo.Insert(0, new CategoriaInfo() { Nome = "Selecione uma Categoria" });

                }
                else
                {
                    lstCategoriaInfo.Insert(0, new CategoriaInfo() { Nome = "Nenhuma Categoria encontrada" });
                }

                ddlCategoria.DataSource = lstCategoriaInfo;
                ddlCategoria.DataTextField = "Nome";
                ddlCategoria.DataValueField = "CodCategoria";
                ddlCategoria.DataBind();
            }
            catch (Exception exc)
            {

            }

            finally
            {
                categoriaBll = null;
                lstCategoriaInfo = null;
            }
        }
        private void CarregaProduto()
        {
            ProdutoBll produtoBll = new ProdutoBll();
            List<ProdutoInfo> lstProdutoInfo = new List<ProdutoInfo>();

            try
            {
                if (!string.IsNullOrEmpty(ddlCategoria.SelectedValue) && !ddlCategoria.SelectedValue.Equals("0"))
                {
                    lstProdutoInfo = produtoBll.ListarPorCategoria(int.Parse(ddlCategoria.SelectedValue));
                    if (lstProdutoInfo.Count > 0)
                        lstProdutoInfo.Insert(0, new ProdutoInfo() { Nome = "Selecione um Produto" });
                    else
                        lstProdutoInfo.Insert(0, new ProdutoInfo() { Nome = "Nenhum Produto encontrado" });
                }
                else
                {
                    lstProdutoInfo.Insert(0, new ProdutoInfo() { Nome = "Primeiro selecione a Categoria" });
                }

                ddlProduto.DataSource = lstProdutoInfo;
                ddlProduto.DataTextField = "Nome";
                ddlProduto.DataValueField = "CodProduto";
                ddlProduto.DataBind();
            }
            catch (Exception exc)
            {

            }

            finally
            {
                produtoBll = null;
                lstProdutoInfo = null;
            }
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaProduto();
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (Session["lstOrcamentoItem"] == null)
                Session["lstOrcamentoItem"] = new List<OrcamentoItemInfo>();

            List<OrcamentoItemInfo> lstOrcamentoItemInfo = Session["lstOrcamentoItem"] as List<OrcamentoItemInfo>;
            if (lstOrcamentoItemInfo != null)
            {
                ProdutoBll produtoBll = new ProdutoBll();

                try
                {
                    ProdutoInfo produtoInfo = produtoBll.ListarPorCodigoImgSmall(int.Parse(ddlProduto.SelectedValue));
                    if (produtoInfo == null)
                        return;
                    OrcamentoItemInfo orcamentoItemInfo = new OrcamentoItemInfo();
                    orcamentoItemInfo.OrcamentoItem_CodProduto = produtoInfo.CodProduto;
                    if (!string.IsNullOrEmpty(txtQuantidade.Text))
                        orcamentoItemInfo.Quantidade = int.Parse(txtQuantidade.Text);
                    orcamentoItemInfo.ProdutoInfo = produtoInfo;
                    orcamentoItemInfo.Guid = Guid.NewGuid().ToString();
                    lstOrcamentoItemInfo.Add(orcamentoItemInfo);

                    grdProdutos.DataSource = lstOrcamentoItemInfo;
                    grdProdutos.DataBind();
                    pnlProdutos.Visible = divEnviarOrcamento.Visible = lstOrcamentoItemInfo.Count > 0;

                    Session["lstOrcamentoItem"] = lstOrcamentoItemInfo;

                    txtQuantidade.Text = string.Empty;
                    ddlCategoria.SelectedIndex = 0;
                    ddlProduto.SelectedIndex = 0;
                }
                finally
                {
                    //produtoBll = null;
                    //lstProdutos = null;
                }
            }
        }

        protected void grdProdutos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (Session["lstOrcamentoItem"] != null)
            {
                List<OrcamentoItemInfo> lstOrcamentoItemInfo = Session["lstOrcamentoItem"] as List<OrcamentoItemInfo>;
                if (lstOrcamentoItemInfo != null && lstOrcamentoItemInfo.Count > 0)
                {
                    lstOrcamentoItemInfo.Remove(lstOrcamentoItemInfo.Find(p => p.Guid.Equals(e.CommandArgument)));
                    grdProdutos.DataSource = lstOrcamentoItemInfo;
                    grdProdutos.DataBind();

                    Session["lstOrcamentoItem"] = lstOrcamentoItemInfo;
                    pnlProdutos.Visible = divEnviarOrcamento.Visible = lstOrcamentoItemInfo.Count > 0;
                }
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            OrcamentoInfo orcamentoInfo = new OrcamentoInfo();
            OrcamentoBll orcamentoBll = new OrcamentoBll();
            OrcamentoItemBll orcamentoItemBll = new OrcamentoItemBll();
            bool sucesso = false;

            try
            {
                orcamentoInfo.Nome = txtNome.Text;
                orcamentoInfo.Telefone = txtTelefone.Text;
                orcamentoInfo.UF = ddlEstado.SelectedValue;
                orcamentoInfo.Email = txtEmail.Text;
                orcamentoInfo.Data = DateTime.Now;
                orcamentoInfo.Comentario = txtComentario.Text;
                orcamentoInfo.Cidade = txtCidade.Text;

                sucesso = orcamentoBll.Inserir(orcamentoInfo);
                if (sucesso)
                {
                    if (Session["lstOrcamentoItem"] != null)
                    {
                        List<OrcamentoItemInfo> lstOrcamentoItemInfo = Session["lstOrcamentoItem"] as List<OrcamentoItemInfo>;
                        if (lstOrcamentoItemInfo != null && lstOrcamentoItemInfo.Count > 0)
                        {
                            foreach (OrcamentoItemInfo item in lstOrcamentoItemInfo)
                            {
                                item.OrcamentoItem_CodOrcamento = orcamentoInfo.CodOrcamento;
                                sucesso = orcamentoItemBll.Inserir(item);
                                if (!sucesso)
                                    break;
                            }
                        }
                    }
                    if (sucesso)
                    {
                        Email email = new Email();
                        string a = @"
<html>
	<head>
		<meta charset='UTF-8'>
	</head>
	<body>
		<center>
			<table style='width:550px;'>
				<tr>
					<td>
						<img src='logoPrincipal.png'>
					</td>
				</tr>
			</table>
			<table style='width:550px;'>
				<tr>
					<td>
						Cliente:
					</td>
					<td>
						André Luis de Oliveira
					</td>
				</tr>
				<tr>
					<td>
						Telefone:
					</td>
					<td>
						(16) 99230-9090
					</td>
				</tr>
				<tr>
					<td>
						Email:
					</td>
					<td>
						andreolyweira@gmail.com
					</td>
				</tr>
				<tr>
					<td>
						Cidade:
					</td>
					<td>
						Batatais - SP
					</td>
				</tr>
				<tr>
					<td>
						Comentário:
					</td>
					<td>
						Blablablablablablablabla Blablablablablablablabla
					</td>
				</tr>
			</table>
			<table cellspacing='0' cellpadding='4' rules='rows' id='ContentPlaceHolder1_grdProdutos'
        style='color: Black; background-color: White; border-color: #CCCCCC; border-width: 1px; border-style: None; border-collapse: collapse;'>
        <tbody>
            <tr style='color: White; background-color: #333333; font-weight: bold;'>
                <th scope='col'>Produto</th>
                <th scope='col'>Quantidade</th>
                <th scope='col'>&nbsp;</th>
            </tr>
            <tr>
                <td>Cascata L.B.</td>
                <td>1</td>
                <td>
                    <img id='ContentPlaceHolder1_grdProdutos_image_0' src='images/galeriaProdutos/CascataLB_Small.jpg'>
                </td>
            </tr>
            <tr>
                <td>Cascata L.B.</td>
                <td>2</td>
                <td>
                    <img id='ContentPlaceHolder1_grdProdutos_image_1' src='images/galeriaProdutos/CascataLB_Small.jpg'>
                </td>
            </tr>
        </tbody>
    </table>
		</center>
	</body>
</html>
                        ";
                        
                        sucesso = email.EnviarEmail("", "Teste", a);
                        if (sucesso)
                        {
                            Session["lstOrcamentoItem"] = null;
                            Session.Abandon();
                            grdProdutos.DataSource = null;
                            grdProdutos.DataBind();
                            pnlProdutos.Visible = divEnviarOrcamento.Visible = false;

                            txtNome.Text = string.Empty;
                            txtTelefone.Text = string.Empty;
                            txtEmail.Text = string.Empty;
                            txtComentario.Text = string.Empty;
                            txtCidade.Text = string.Empty;
                            CarregaCategoria();
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                throw;
            }
        }
    }
}