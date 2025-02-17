<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Web.TechsysLog._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main id="main">

        <!-- Content-->
        <section class="container-fluid">

            <!-- Breadcrumbs-->
            <nav class="mb-4 pb-2 border-bottom" aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="./index.html"><i class="ri-home-line align-bottom me-1"></i>Dashboard</a></li>
                </ol>
            </nav>
            <!-- / Breadcrumbs-->


            <!-- Bottom Row Widgets-->
            <div class="row g-12 mb-12">

                <!-- Projects Widget-->
                <div class="col-6">
    <div class="card mb-4 h-100">
        <div class="card-header justify-content-between align-items-center d-flex">
            <h6 class="card-title m-0">Entregues</h6>
        </div>
        <!--ENTREGUESSSSSSSSSSSSSSSSSSS -->
        <div class="card-body">
            <div class="table-responsive">
                <table class="table m-0 table-striped">
                    <thead>
                        <tr>
                            <th>Project</th>
                            <th>Status</th>
                            <th>Date</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td class="text-white">Move headquarters to London</td>
                            <td>
                                <div class="d-flex align-items-center">
                                    <span class="dot dot-xs bg-warning me-2"></span>In progress
                                </div>
                            </td>
                            <td>24th June, 2021</td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <nav>
                <ul class="pagination justify-content-end mt-3 mb-0">
                    <li class="page-item"><a class="page-link" href="#">Previous</a></li>
                    <li class="page-item active"><a class="page-link" href="#">1</a></li>
                    <li class="page-item"><a class="page-link" href="#">2</a></li>
                    <li class="page-item"><a class="page-link" href="#">3</a></li>
                    <li class="page-item"><a class="page-link" href="#">Next</a></li>
                </ul>
            </nav>
        </div>
    </div>
</div>
                <div class="col-6">
                    <div class="card mb-4 h-100">
                        <div class="card-header justify-content-between align-items-center d-flex">
                            <h6 class="card-title m-0">Entregues</h6>
                        </div>
                        <!--ENTREGUESSSSSSSSSSSSSSSSSSS -->
                        <div class="card-body">
                            <div class="table-responsive">
                                <table class="table m-0 table-striped">
                                    <thead>
                                        <tr>
                                            <th>Project</th>
                                            <th>Status</th>
                                            <th>Date</th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td class="text-white">Move headquarters to London</td>
                                            <td>
                                                <div class="d-flex align-items-center">
                                                    <span class="dot dot-xs bg-warning me-2"></span>In progress
                                                </div>
                                            </td>
                                            <td>24th June, 2021</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <nav>
                                <ul class="pagination justify-content-end mt-3 mb-0">
                                    <li class="page-item"><a class="page-link" href="#">Previous</a></li>
                                    <li class="page-item active"><a class="page-link" href="#">1</a></li>
                                    <li class="page-item"><a class="page-link" href="#">2</a></li>
                                    <li class="page-item"><a class="page-link" href="#">3</a></li>
                                    <li class="page-item"><a class="page-link" href="#">Next</a></li>
                                </ul>
                            </nav>
                        </div>
                    </div>
                </div>
                <!-- / Projects Widget-->

            </div>
            <!-- Bottom Row Widgets-->

            <!-- Footer -->
            <footer class="  footer">
                <p class="small text-muted m-0">All rights reserved | © 2021</p>
                <p class="small text-muted m-0">Template created by <a href="https://www.pixelrocket.store/">PixelRocket</a></p>
            </footer>


            <!-- Sidebar Menu Overlay-->
            <div class="menu-overlay-bg"></div>
            <!-- / Sidebar Menu Overlay-->

            <!-- Modal Imports-->
            <!-- Place your modal imports here-->

            <!-- Default Example Modal Import-->
            <!-- Modal -->
            <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            Here goes modal body content
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                            <button type="button" class="btn btn-primary">Save changes</button>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Offcanvas Imports-->
            <!-- Place your offcanvas imports here-->

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
                                <span class="fw-bold fs-3 text-white">Kavlan</span>
                            </div>
                        </a>
                    </div>
                    <!-- / Mobile Logo-->

                    <!-- User Details-->
                    <div class="border-bottom pt-3 pb-5 mb-6 d-flex flex-column align-items-center">
                        <div class="position-relative">
                            <picture class="avatar avatar-profile">
                                <img class="avatar-profile-img" src="~/content/assets/images/profile-small.jpeg"
                                    alt="HTML Bootstrap Admin Template by Pixel Rocket">
                            </picture>
                            <span class="dot bg-success avatar-dot"></span>
                        </div>
                        <p class="mb-0 mt-3 text-white">Robert Jones</p>
                        <small>robert.jones@outlook.com</small>
                        <div class="d-flex flex-wrap mt-2 justify-content-between align-items-center">
                            <div class="py-2 f-h-9 px-3 d-flex justify-content-center align-items-center bg-dark-opacity rounded p-2 small fw-bolder me-1">
                                <i class="ri-map-pin-line me-2"></i>London, UK
                            </div>

                            <!-- User profile dropdown-->
                            <div class="dropdown m-0">
                                <button class="border-0 rounded px-2 f-h-9 bg-dark-opacity p-0 text-body" type="button" id="profileDropdown"
                                    data-bs-toggle="dropdown" aria-expanded="false">
                                    <i class="ri-settings-2-line"></i>
                                </button>
                                <ul class="dropdown-menu" aria-labelledby="profileDropdown">
                                    <li><a class="dropdown-item d-flex align-items-center" href="#"><i class="ri-user-line me-2"></i>Edit
                                      profile</a></li>
                                    <li><a class="dropdown-item d-flex align-items-center" href="#"><i class="ri-settings-2-line me-2"></i>Edit
                                      settings</a></li>
                                    <li><a class="dropdown-item d-flex align-items-center" href="#"><i class="ri-mail-open-line me-2"></i>View
                                      messages</a></li>
                                    <li>
                                        <hr class="dropdown-divider">
                                    </li>
                                    <li><a class="dropdown-item text-danger d-flex align-items-center" href="#"><i
                                        class="ri-lock-line me-2"></i>Logout</a></li>
                                </ul>
                            </div>
                            <!-- / User profile dropdown-->
                        </div>
                    </div>
                    <!-- User Details-->

                    <ul class="list-unstyled mb-6 aside-menu">

                        <!-- Dashboard Menu Section-->
                        <li class="menu-section">Menu</li>
                        <li class="menu-item"><a class="d-flex align-items-center menu-link" href="/dashboard"><i
                            class="ri-home-4-line me-3"></i><span>Dashboard</span></a></li>
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
