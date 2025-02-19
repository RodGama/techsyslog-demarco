<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EditProfile.aspx.cs" Inherits="Web.TechsysLog.EditProfile" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main id="main">

        <!-- Content-->
        <section class="container-fluid">

            <div class="row g-12">
                <div class="col-12 col-md-12">

                    <div class="card mb-12">
                        <div class="card card-body">
                            <asp:Literal runat="server" ID="ErrorListUser" />
                            <div class="form-group">
                                <label class="form-label form-label-light" for="password">Senha</label>
                                <asp:TextBox ID="oldpassword" runat="server" type="password" class="form-control form-control-light" placeholder="Digite sua senha"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="form-label form-label-light" for="password">Nova Senha</label>
                                <asp:TextBox ID="password" runat="server" type="password" class="form-control form-control-light" placeholder="Digite sua nova senha"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="form-label form-label-light" for="passwordc">Confirmação de senha</label>
                                <asp:TextBox ID="passwordc" runat="server" type="password" class="form-control form-control-light" placeholder="Confirme sua nova senha"></asp:TextBox>
                            </div>
                            <asp:Button ID="Button2" Text="Atualizar" runat="server" class="btn btn-primary d-block w-100 my-4" />
                        </div>
                    </div>

                </div>
            </div>

            <!-- Sidebar Menu Overlay-->
            <div class="menu-overlay-bg"></div>
            <!-- / Sidebar Menu Overlay-->

            <!-- Default Example Offcanvas Import-->
            <div class="offcanvas offcanvas-end" tabindex="-1" id="offcanvasExample" aria-labelledby="offcanvasExampleLabel">
                <div class="offcanvas-header">
                    <h5 class="offcanvas-title" id="offcanvasExampleLabel">Offcanvas</h5>
                    <button type="button" class="btn-close text-reset" data-bs-dismiss="offcanvas" aria-label="Close"></button>
                </div>
                <div class="offcanvas-body">
                    <div>
                        Some text as placeholder. In real life you can have the elements you have chosen. Like, text, images, lists, etc.
                    </div>
                    <div class="dropdown mt-3">
                        <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-bs-toggle="dropdown">
                            Dropdown button
                        </button>
                        <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                            <li><a class="dropdown-item" href="#">Action</a></li>
                            <li><a class="dropdown-item" href="#">Another action</a></li>
                            <li><a class="dropdown-item" href="#">Something else here</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <!-- Navbar Notifications offcanvas-->
            <div class="offcanvas offcanvas-end" tabindex="-1" id="offcanvasNotifications"
                aria-labelledby="offcanvasNotificationsLabel">
                <div class="offcanvas-header">
                    <h5 class="offcanvas-title" id="offcanvasNotificationsLabel">Notifications</h5>
                    <button type="button" class="btn-close text-reset" data-bs-dismiss="offcanvas" aria-label="Close"></button>
                </div>
                <div class="offcanvas-body">

                    <!-- Notification-->
                    <div class="d-flex justify-content-start align-items-start p-3 rounded bg-light mb-3">
                        <div class="position-relative mt-1 ">
                            <picture class="avatar avatar-sm">
                                <img src="./assets/images/profile-small-2.jpeg"
                                    alt="HTML Bootstrap Admin Template by Pixel Rocket">
                            </picture>
                            <span
                                class="dot bg-success avatar-dot border-light dot-sm"></span>
                        </div>
                        <div class="ms-4">
                            <p class="fw-bolder mb-1">John Jackson</p>
                            <p class="text-muted small mb-0">Just sent over regional sales. If you can let me know by the end...</p>
                            <span class="fs-xs fw-bolder text-muted text-uppercase">5 mins ago</span>
                        </div>
                    </div>
                    <!-- / Notification-->


                    <!-- View all Btn-->
                    <a href="#" class="btn btn-outline-secondary w-100 mt-4" role="button">View all notifications</a>
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
                        <a class="m-0" href="./index.html">
                            <div class="d-flex align-items-center justify-content-center">
                                <svg class="f-w-6 me-2 text-primary" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 398.39 353.81">
                                    <polygon points="228.38 33.94 0 262.32 0 0 119.61 0 119.61 43.01 101.9 60.73 86.02 76.61 86.02 33.6 33.6 33.6 33.6 181.2 214.46 0.34 390.66 0.34 242.09 148.91 218.73 124.76 309.55 33.94 228.38 33.94" fill="currentColor" />
                                    <polygon points="398.39 353.81 217.51 353.81 131.04 261.75 45.09 353.81 0 353.81 0 353.49 131.26 212.91 232.05 320.21 317.27 320.21 170.28 173.21 194.19 149.29 194.19 149.55 254.9 210.51 254.97 210.39 398.39 353.81" fill="currentColor" />
                                </svg>
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
                      <li><a class="dropdown-item d-flex align-items-center" href="/EditProfile"><i class="ri-user-line me-2"></i>Editar
perfil</a></li>
                      <li>
                          <hr class="dropdown-divider">
                      </li>
                      <li><a class="dropdown-item text-danger d-flex align-items-center" href="/logout"><i
                          class="ri-lock-line me-2"></i>Logout</a></li>
                        <!-- / Dashboard Menu Section-->



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

