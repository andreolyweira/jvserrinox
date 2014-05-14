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

        private const string script = "function setMessage(imgSrc, text, duration) {" +
                "imgSrc = String(imgSrc) || '';" +
                "text = String(text) || '';" +
                "duration = Number(duration) || 0;" +
                "var fn = (imgSrc === '') ? 'hide' : 'show';" +
                "$(\"#message\").fadeIn('fast').find(\"span\").text(text).end().find('img').attr('src', imgSrc)[fn]();" +
                "if (duration && !isNaN(duration)) {" +
                "    setTimeout(function () {" +
                "        $(\"#message\").fadeOut('fast')" +
                "    }, duration);" +
                "}" +
                "}" +
                "" +
                "setMessage('', 'Orçamento enviado com sucesso.', 3000);";

        string NovoProduto()
        {
            return "<td align='left' valign='top'>" +
                                  "   <table cellpadding='10' cellspacing='0' border='0' width='190px' style='width:190px;font-family:Arial;font-size:13px;color:#666666'>" +
                                  "       <tr>" +
                                  "           <td style='border:1px #EAECEC solid' align='center'>" +
                                  "                <img src='http://www.jvserrinox.com.br/#IMAGEM' />" +
                                  "           </td>" +
                                  "       </tr>" +
                                  "       <tr>" +
                                  "           <td style='font-weight:bold'>" +
                                  "                #DESCRICAO" +
                                  "           </td>" +
                                  "       </tr>" +
                                  "       <tr>" +
                                  "           <td>" +
                                  "                #DETALHES" +
                                  "           </td>" +
                                  "       </tr>" +
                                  "   </table>" +
                                  "</td>";
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

                string _produtos = "";

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
                                else
                                {
                                    string produto = NovoProduto();
                                    produto = produto.Replace("#IMAGEM", item.ProdutoInfo.CaminhoImagemTemp);
                                    produto = produto.Replace("#DESCRICAO", item.ProdutoInfo.Nome + " (" + item.Quantidade + ")");
                                    produto = produto.Replace("#DETALHES", item.ProdutoInfo.Descricao);
                                    _produtos += produto;
                                }
                            }
                        }
                    }
                    if (sucesso)
                    {
                        Email email = new Email();

                        string corpoEmail = @"
                        <table cellpadding='0' cellspacing='0' border='0' width='650px' style='width:650px;font-family:Arial;font-size:13px;color:#666666' align='center'>
	                        <tr>
		                        <td colspan='5' align='center' style='padding:15px'>
			                        <a href='http://www.jvserrinox.com.br'><img src='http://www.jvserrinox.com.br/images/logoPrincipal.png' style='display:block' border='0' /></a>
		                        </td>
	                        </tr>
	                        <tr>
		                        <td colspan='5' align='center'>
			                        <table cellpadding='0' cellspacing='0' style='width:560px;height:10px;border-top:1px #EAECEC solid;border-left:1px #EAECEC solid;border-right:1px #EAECEC solid;border-bottom:0px;font-size:8px'>
				                        <tr>
					                        <td height='10px'>&#160;</td>
				                        </tr>
			                        </table>
		                        </td>
	                        </tr>
		                        <tr>
		                        <td colspan='5' align='center'>
			                        <table cellpadding='0' cellspacing='0' style='width:600px;height:10px;border-top:1px #EAECEC solid;border-left:1px #EAECEC solid;border-right:1px #EAECEC solid;border-bottom:0px;;font-size:8px'>
				                        <tr>
					                        <td height='10px'>&#160;</td>
				                        </tr>
			                        </table>
		                        </td>
	                        </tr>
	                        <tr>
		                        <td colspan='5' align='center' style='border:1px #EAECEC solid;padding:10px'>
				                        <table style='width:550px;'>
				                        <tr>
					                        <td>
						                        <strong>Cliente:</strong>
					                        </td>
					                        <td>
                                                #CLIENTE
					                        </td>
				                        </tr>
				                        <tr>
					                        <td>
						                        <strong>Telefone:</strong>
					                        </td>
					                        <td>
                                                #TELEFONE
					                        </td>
				                        </tr>
				                        <tr>
					                        <td>
						                        <strong>Email:</strong>
					                        </td>
					                        <td>
                                                #EMAIL
					                        </td>
				                        </tr>
				                        <tr>
					                        <td>
						                        <strong>Cidade:</strong>
					                        </td>
					                        <td>
                                                #CIDADE
					                        </td>
				                        </tr>
				                        <tr>
					                        <td>
						                        <strong>Comentário:</strong>
					                        </td>
					                        <td>
                                                #COMENTARIO
					                        </td>
				                        </tr>
			                        </table>
		                        </td>
	                        </tr>
	                        <tr>
		                        <td colspan='5' align='center'>
			                        <table cellpadding='0' cellspacing='0' style='width:600px;height:10px;border-bottom:1px #EAECEC solid;border-left:1px #EAECEC solid;border-right:1px #EAECEC solid;border-top:0px;font-size:8px'>
				                        <tr>
					                        <td height='10px'>&#160;</td>
				                        </tr>
			                        </table>
		                        </td>
	                        </tr>
		                        <tr>
		                        <td colspan='5' align='center'>
			                        <table cellpadding='0' cellspacing='0' style='width:560px;height:10px;border-bottom:1px #EAECEC solid;border-left:1px #EAECEC solid;border-right:1px #EAECEC solid;border-top:0px;font-size:8px'>
				                        <tr>
					                        <td height='10px'>&#160;</td>
				                        </tr>
			                        </table>
		                        </td>
	                        </tr>
	                        <tr>
		                        <td colspan='5'><br/>
			                        <table cellpadding='10' cellspacing='0' width='650px' style='width:650px'>
				                        <tr>
                                            #PRODUTOS
				                        </tr>
			                        </table>
		                        </td>
	                        </tr>
	                        <tr>
		                        <td colspan='2' height='40px' style='height:40px;border:1px #EAECEC solid;border-right:0px;padding-left:10px'>
		                        </td>
		                        <td colspan='3' align='right' height='40px' style='height:40px;border:1px #EAECEC solid;border-left:0px;font-size:11px;padding-right:10px'>
			                         Copyright © 2014 | por <a href='http://www.escolajcm.com.br/' rel='nofollow' target='_blank'>JCM Informática</a>
		                        </td>
	                        </tr>
                        </table>
                        ";

                        corpoEmail = corpoEmail.Replace("#CLIENTE", txtNome.Text);
                        corpoEmail = corpoEmail.Replace("#TELEFONE", txtTelefone.Text);
                        corpoEmail = corpoEmail.Replace("#EMAIL", string.IsNullOrEmpty(txtEmail.Text) ? txtEmail.Text : "Não informado");
                        corpoEmail = corpoEmail.Replace("#CIDADE", string.IsNullOrEmpty(txtCidade.Text) ? txtCidade.Text : "Não informada");
                        corpoEmail = corpoEmail.Replace("#COMENTARIO", string.IsNullOrEmpty(txtComentario.Text) ? txtComentario.Text : "Não informado");
                        corpoEmail = corpoEmail.Replace("#PRODUTOS", _produtos);

                        sucesso = email.EnviarEmail("", string.Format("Orçamento Online do Cliente {0}", txtNome.Text), corpoEmail);
                        if (sucesso)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", script, true);
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