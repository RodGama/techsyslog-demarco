<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="DashboardAdmin.aspx.cs" Inherits="Web.TechsysLog.DashboardAdmin" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main id="main">

        <!-- Content-->
        <section class="container-fluid">

            <div class="row g-12">
                <div class="col-12 col-md-12">

                    <div class="card mb-12">
                        <div class="card-body">
                            <p>
                                <button class="btn btn-primary mb-2" type="button" data-bs-toggle="collapse"
                                    data-bs-target="#register-user" aria-expanded="false" aria-controls="register-user">
                                    Novo usuário
                                </button>

                                <button class="btn btn-primary mb-2" type="button" data-bs-toggle="collapse"
                                    data-bs-target="#register-order" aria-expanded="false" aria-controls="register-order">
                                    Novo pedido
                                </button>
                            </p>
                            <div class="collapse multi-collapse" id="register-user">
                                <div class="card card-body">
                                    <asp:Literal runat="server" ID="ErrorListUser" />
                                    <div class="form-group">
                                        <label class="form-label form-label-light" for="fname">Nome completo</label>
                                        <asp:TextBox ID="fname" runat="server" type="text" class="form-control form-control-light" placeholder="Entre com seu nome"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label class="form-label form-label-light" for="email">Email</label>
                                        <asp:TextBox ID="email" runat="server" type="email" class="form-control form-control-light" placeholder="name@email.com"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label class="form-label form-label-light" for="password">Senha</label>
                                        <asp:TextBox ID="password" runat="server" type="password" class="form-control form-control-light" placeholder="Digite sua senha"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label class="form-label form-label-light" for="passwordc">Confirmação de senha</label>
                                        <asp:TextBox ID="passwordc" runat="server" type="password" class="form-control form-control-light" placeholder="Confirme sua senha"></asp:TextBox>
                                    </div>
                                    <asp:Button ID="Button2" Text="Registrar usuário" runat="server" OnClick="RegisterNewUser" class="btn btn-primary d-block w-100 my-4" />
                                </div>
                            </div>

                            <div class="collapse multi-collapse" id="register-order">
                                <div class="card card-body">
                                    <asp:Literal runat="server" ID="ErrorListOrder" />
                                    <div class="form-group">
                                        <label class="form-label form-label-light" for="description">Descrição do pedido</label>
                                        <asp:TextBox ID="description" runat="server" type="text" class="form-control form-control-light" placeholder="Descrição"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label class="form-label form-label-light" for="cep">Número do pedido</label>
                                        <asp:TextBox ID="ordernumber" runat="server" type="number" step="0.01" class="form-control form-control-light" placeholder="Número do pedido"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label class="form-label form-label-light" for="cep">Preço</label>
                                        <asp:TextBox ID="price" runat="server" type="number" class="form-control form-control-light" placeholder="Preço"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label class="form-label form-label-light" for="cep">CEP</label>
                                        <asp:TextBox ID="cep" runat="server" type="text" class="form-control form-control-light" placeholder="CEP"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label class="form-label form-label-light" for="street">Rua</label>
                                        <asp:TextBox ID="street" runat="server" type="text" class="form-control form-control-light" SkinID="teste" placeholder="Endereço"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label class="form-label form-label-light" for="addressnumber">Número</label>
                                        <asp:TextBox ID="addressnumber" runat="server" type="text" class="form-control form-control-light" SkinID="teste" placeholder="Número"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label class="form-label form-label-light" for="addressnumber">Bairro</label>
                                        <asp:TextBox ID="neighborhood" runat="server" type="text" class="form-control form-control-light" SkinID="teste" placeholder="Bairro"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label class="form-label form-label-light" for="addressnumber">Cidade</label>
                                        <asp:TextBox ID="city" runat="server" type="text" class="form-control form-control-light" SkinID="teste" placeholder="Cidade"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label class="form-label form-label-light" for="addressnumber">Estado</label>
                                        <asp:TextBox ID="state" runat="server" type="text" class="form-control form-control-light" SkinID="teste" placeholder="Estado"></asp:TextBox>
                                    </div>

                                    <asp:Button ID="Button3" Text="Registrar pedido" OnClick="RegisterOrder" runat="server" class="btn btn-primary d-block w-100 my-4" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- /Example-->

                </div>
            </div>

            <div class="row g-12 mb-12">
                <!-- Projects Widget-->
                <div class="col-12">
                    <div class="card mb-4 h-100">
                        <div class="card-header justify-content-between align-items-center d-flex">
                            <h6 class="card-title m-0">Pedidos pendentes</h6>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <table class="table m-0 table-striped">
                                    <thead>
                                        <tr>
                                            <th>Pedido</th>
                                            <th>Status</th>
                                            <th>Data</th>
                                            <th>Enviar</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Literal ID="OrdersPending" runat="server" />
                                    </tbody>
                                </table>
                            </div>
                            <nav>
                                <ul class="pagination justify-content-end mt-3 mb-0">
                                    <li class="page-item"><a class="page-link" href="#">Anterior</a></li>
                                    <li class="page-item active"><a class="page-link" href="#">1</a></li>
                                    <li class="page-item"><a class="page-link" href="#">2</a></li>
                                    <li class="page-item"><a class="page-link" href="#">3</a></li>
                                    <li class="page-item"><a class="page-link" href="#">Próxima</a></li>
                                </ul>
                            </nav>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Bottom Row Widgets-->

            <!-- Sidebar Menu Overlay-->
            <div class="menu-overlay-bg"></div>
            <!-- / Sidebar Menu Overlay-->

        </section>
        <!-- / Content-->

    </main>
    <!-- /Page Content -->

    <!-- Page Aside-->
    <aside class="aside bg-dark-700">

        <div class="simplebar-wrapper">
            <div data-pixr-simplebar>
                <div class="pb-6 pb-sm-0 position-relative">

                    <!-- Mobile close btn-->
                    <div class="cursor-pointer close-menu me-4 text-primary-hover transition-color disable-child-pointer position-absolute end-0 top-0 mt-3 pt-1 d-xl-none">
                        <i class="ri-close-circle-line ri-lg align-middle me-n2"></i>
                    </div>
                    <!-- / Mobile close btn-->

                    <!-- Mobile Logo-->
                    <div class="d-flex justify-content-center align-items-center py-3">
                        <a class="m-0" href="/">
                            <div class="d-flex align-items-center justify-content-center">
                                <span class="fw-bold fs-3 text-white">TechsysLog</span>
                            </div>
                        </a>
                    </div>
                    <!-- / Mobile Logo-->

                    <!-- User Details-->

                    <ul class="list-unstyled mb-6 aside-menu">

                        <!-- Dashboard Menu Section-->
                        <li class="menu-section">Menu</li>
                        <li class="menu-item"><a class="d-flex align-items-center menu-link" href="/dashboardadmin"><i
                            class="ri-home-4-line me-3"></i><span>Dashboard</span></a></li>
                        <li>
                            <hr class="dropdown-divider">
                        </li>
                        <a class="d-flex align-items-center menu-link collapsed" href="#" data-bs-toggle="collapse" data-bs-target="#perfil" aria-expanded="false" aria-controls="collapseMenuItemUI"><i class="ri-user-line me-3"></i>
                            <span>Perfil</span></a>
                        <div class="collapse" id="perfil">
                            <ul class="submenu">
                                <li><a class="dropdown-item d-flex align-items-center" href="/EditProfile"><i class="ri-settings-2-line  me-2"></i>Editar
perfil</a></li>
                            </ul>
                        </div>

                        <li>
                            <hr class="dropdown-divider">
                        </li>

                        <li class="menu-item"><a class="d-flex align-items-center menu-link text-danger" href="/logout"><i
                            class="ri-lock-line me-2"></i>Logout</a></li>


                    </ul>
                </div>
            </div>
        </div>

    </aside>
    <!-- / Page Aside-->

    <!-- Theme JS -->
    <!-- Vendor JS -->
    <script src="/content/assets/js/vendor.bundle.js"></script>

    <!-- Theme JS -->
    <script src="/content/assets/js/theme.bundle.js"></script>
    <script src="https://img.selecoesbrasil.com.br/pag/jquery.inputmask.min.js"></script>

    <script>
        AdicionarMascaraCep("#MainContent_cep");
        ImpedirEscrita("#MainContent_street");
        ImpedirEscrita("#MainContent_neighborhood");
        ImpedirEscrita("#MainContent_city");
        ImpedirEscrita("#MainContent_state");


        function AdicionarMascaraCep(campo) {
            $cep = $(campo);
            if ($cep.length > 0) {
                $cep.inputmask({
                    'mask': '99999-999',
                    'oncomplete': function () {
                        var valuecep = $('#MainContent_cep').val().replace('-', '');
                        const options = { method: 'GET' };

                        fetch('https://brasilapi.com.br/api/cep/v2/' + valuecep, options)
                            .then((response) => {
                                return response.json().then((data) => {
                                    populateAddress(data);
                                }).catch((err) => {
                                    err => cepNotExists(err)
                                })
                            });
                    }
                })
            }
        }

        function ImpedirEscrita(campo) {
            $(campo).prop('readonly', true)
        }


        function onSuccess(result) {
            alert(result);  // The result from the server-side method
        }

        function onError(error) {
            alert("Error: " + error);
        }

        function populateAddress(json) {
            $("#MainContent_street").val(json.street);
            $("#MainContent_neighborhood").val(json.neighborhood);
            $("#MainContent_city").val(json.city);
            $("#MainContent_state").val(json.state);
            console.log(json);
        }

        function cepNotExists(err) {

            console.log(err);
            window.alert("não existe");
        }




    </script>

</asp:Content>

