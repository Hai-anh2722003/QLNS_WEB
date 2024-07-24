<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormBaoCaoThongKe.aspx.cs" Inherits="FormBaoCaoThongKe" MasterPageFile="Site.master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-xxl flex-grow-1 container-p-y">
        <h4 class="py-3 mb-4">
            <span class="text-muted fw-light"></span>Báo cáo thống kê
        </h4>

        <!-- Card tổng hợp -->
        <div class="row">
            <div class="col-sm-6 col-lg-3 mb-4">
                <div class="card card-border-shadow-primary h-100">
                    <div class="card-body">
                        <div class="d-flex align-items-center mb-2 pb-1">
                            <div class="avatar me-2">
                                <span class="avatar-initial rounded bg-label-primary"><i class="fa fa-users"></i></span>
                            </div>
                            <asp:Label ID="lbltongnhanvien" class="ms-1 mb-0" runat="server" Text="0"></asp:Label>
                        </div>
                        <p class="mb-1">Tổng nhân viên</p>
                        <p class="mb-0">
                            <small class="text-muted">trong công ty</small>
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-lg-3 mb-4">
                <div class="card card-border-shadow-warning h-100">
                    <div class="card-body">
                        <div class="d-flex align-items-center mb-2 pb-1">
                            <div class="avatar me-2">
                                <span class="avatar-initial rounded bg-label-warning"><i class='bx bx-error'></i></span>
                            </div>
                            <asp:Label ID="lblThuViec" class="ms-1 mb-0" runat="server" Text="0"></asp:Label>
                        </div>
                        <p class="mb-1">Nhân viên thử việc</p>
                        <p class="mb-0">
                            <small class="text-muted">số lượng</small>
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-lg-3 mb-4">
                <div class="card card-border-shadow-danger h-100">
                    <div class="card-body">
                        <div class="d-flex align-items-center mb-2 pb-1">
                            <div class="avatar me-2">
                                <span class="avatar-initial rounded bg-label-danger"><i class='fa fa-cake-candles'></i></span>
                            </div>
                            <asp:Label ID="lblSinhNhat" class="ms-1 mb-0" runat="server" Text="0"></asp:Label>
                        </div>
                        <p class="mb-1">Sinh nhật</p>
                        <p class="mb-0">
                            <small class="text-muted">nhân viên trong tháng</small>
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-lg-3 mb-4">
                <div class="card card-border-shadow-info h-100">
                    <div class="card-body">
                        <div class="d-flex align-items-center mb-2 pb-1">
                            <div class="avatar me-2">
                                <span class="avatar-initial rounded bg-label-info"><i class='fa fa-users-slash'></i></span>
                            </div>
                            <asp:Label ID="lblNghiHuu" class="ms-1 mb-0" runat="server" Text="0"></asp:Label>
                        </div>
                        <p class="mb-1">Nghỉ hưu</p>
                        <p class="mb-0">
                            <small class="text-muted">nhân viên trong công ty</small>
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <!--/ Card Border Shadow -->
        <div class="row">
            <!-- theo hợp đồng -->
            <div class="col-xxl-6 mb-4 order-5 order-xxl-0">
                <div class="card h-100">
                    <div class="card-header">
                        <div class="card-title mb-0">
                            <h5 class="m-0">Thống kê số lượng nhân sự theo hợp đồng lao động</h5>
                        </div>
                    </div>
                    <div class="card-body">
                       <canvas id="columnChart" ></canvas>
                    </div>
                </div>
            </div>
            <!--/ theo hợp đồng -->
            <!-- theo phòng ban-->
            <div class="col-lg-6 col-xxl-6 mb-4 order-3 order-xxl-1">
                <div class="card h-100">
                    <div class="card-header d-flex align-items-center justify-content-between">
                        <div class="card-title mb-0">
                            <h5 class="m-0 me-2">Cơ cấu nhân sự theo phòng ban</h5>
                        </div>
                    </div>
                    <div class="card-body">
                        <canvas id="pieChart"></canvas>
                    </div>
                </div>
            </div>
            <!--/ theo phòng ban -->
        </div>
</asp:Content>

