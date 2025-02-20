<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Dashboard.aspx.cs" Inherits="Web.TechsysLog.Dashboard1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main id="main">

        <!-- Content-->
        <section class="container-fluid">
            <div class="row g-12 mb-12">
                <div class="mb-12">
                    <div class="card-header justify-content-between align-items-center d-flex">
                        <h6 class="card-title m-0">Rastrear pedido</h6>
                    </div>
                    <div class="card-body">
                        <asp:Literal runat="server" ID="ErrorList" />
                        <div class="mb-3">
                            <asp:TextBox runat="server" ID="ordernumber" type="text" class="form-control" placeholder="Número do pedido"></asp:TextBox>
                        </div>
                        <asp:Button runat="server" type="submit" Text="Cadastrar" OnClick="RegisterOrder" class="btn btn-primary" />
                    </div>
                </div>
            </div>
            <div class="row g-12 mb-12">

                <!-- Projects Widget-->
                <div class="col-6">
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
                                            <th></th>
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
                <div class="col-6">
                    <div class="card mb-4 h-100">
                        <div class="card-header justify-content-between align-items-center d-flex">
                            <h6 class="card-title m-0">Pedidos entregues</h6>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <table class="table m-0 table-striped">
                                    <thead>
                                        <tr>
                                            <th>Pedido</th>
                                            <th>Status</th>
                                            <th>Data da entrega</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Literal ID="OrdersDelivered" runat="server" />
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

            <div class="offcanvas offcanvas-end" tabindex="-1" id="offcanvasNotifications"
                aria-labelledby="offcanvasNotificationsLabel">
                <div class="offcanvas-header">
                    <h5 class="offcanvas-title" id="offcanvasNotificationsLabel">Notifications</h5>
                    <button type="button" class="btn-close text-reset" data-bs-dismiss="offcanvas" aria-label="Close"></button>
                </div>
                <div class="offcanvas-body">

                    <!-- Notification-->
                    <asp:Literal ID="NotificationsUser" runat="server" />
                    <!-- / Notification-->


                    <!-- View all Btn-->
                    <asp:Button runat="server" class="btn btn-outline-secondary w-100 mt-4" role="button" OnClick="RegisterViewNotification" Text="Marcar como lido" />
                    <!-- / View all btn-->

                </div>
            </div>
            <!-- / Footer-->

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


</asp:Content>
