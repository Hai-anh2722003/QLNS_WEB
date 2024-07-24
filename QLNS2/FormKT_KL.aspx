<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  CodeFile="FormKT_KL.aspx.cs" Inherits="FormKT_KL" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Layout wrapper -->
    <div class="layout-wrapper layout-content-navbar">
      <div class="layout-container">
          <!-- Content wrapper -->
          <div class="content-wrapper">
            <!-- Content -->
              <form id="form1">
            <div class="container-xxl flex-grow-1 container-p-y">

              <!-- Basic Layout & Basic with Icons -->
              <div class="row">
                <!-- Basic Layout -->
                <div class="col-xxl">
                  <div class="card mb-4">
                    <div class="card-header d-flex align-items-center justify-content-between">
                      <h5 class="mb-0">Quản lý khen thưởng</h5>
                    </div>
                    <div class="card-body"><br />
                      
                        <div class="row mb-3">
                          <label class="form-label" for="basic-default-name">Mã khen thưởng</label>
                          <div class="col-sm-12">
                            <asp:TextBox ID="makt" class="form-control" runat="server"></asp:TextBox>
                          </div>
                        </div>
                        <div class="row mb-3">
                          <label class="form-label" for="basic-default-company">Tiền khen thưởng</label>
                          <div class="col-sm-12">
                            <asp:TextBox ID="tienkt" class="form-control" runat="server"></asp:TextBox>
                          </div>
                        </div>
                        <div class="row mb-3">
                          <label class="form-label" for="basic-default-email">Lí do khen thưởng</label>
                          <div class="col-sm-12">
                            <div class="input-group input-group-merge">
                              <asp:TextBox ID="lidokt" class="form-control" runat="server"></asp:TextBox>
                            </div>
                          </div>
                        </div> 
                        <br />   
                        <div class="row justify-content-end">
                          <div class="col-sm-9">
                           <asp:LinkButton  ID="themkt" class="btn btn-primary" runat="server" Text="Thêm" OnClick="themkt_Click"><i class="fa fa-plus me-sm-2"></i> Thêm </asp:LinkButton>
                            <asp:LinkButton  ID="suakt" class="btn btn-primary" runat="server" Text="Sửa" OnClick="suakt_Click"><i class="fa fa-edit me-sm-2"></i> Sửa </asp:LinkButton>
                            <asp:LinkButton  ID="xoakt" class="btn btn-primary" runat="server" Text="Xóa" OnClick="xoakt_Click"><i class="fa fa-trash"></i> Xóa</asp:LinkButton>
                          </div>
                        </div>
                        <br />
                        <!-- Khen thưởng Table -->
                        <div class="row mb-3" style="height: 246px; color:#576B80 !important; text-align:center;">
                            <asp:GridView ID="bangkt" runat="server" AutoGenerateSelectButton="True" AutoGenerateColumns="False" DataKeyNames="Id" OnSelectedIndexChanged="bangkt_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" Width="100%" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Height="227px" >
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Mã khen thưởng" SortExpression="Id" />
                                    <asp:BoundField DataField="Tien" HeaderText="Tiền khen thưởng" SortExpression="Tien" />
                                    <asp:BoundField DataField="KhenThuong" HeaderText="Lí do khen thưởng " SortExpression="KhenThuong" />
                                </Columns>
                                <FooterStyle BackColor="#CCCC99" ForeColor="yellow" />
                                 <HeaderStyle BackColor="#F5F5F9" Font-Bold="True" ForeColor="#2F2F2F" Height="50px"  />
                                 <PagerStyle BackColor="White" ForeColor="green" HorizontalAlign="Right"  />
                                 <SelectedRowStyle BackColor="#E0E0ED" Font-Bold="True" ForeColor="black" />
                                 <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                 <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                 <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                 <SortedDescendingHeaderStyle BackColor="#242121" />
                            </asp:GridView>
                        </div>
                        <!-- Khen thưởng Table -->
                    </div>
                  </div>
                </div>
                <!-- Quản lý kỉ luật -->
                <div class="col-xxl">
                  <div class="card mb-4">
                    <div class="card-header d-flex align-items-center justify-content-between">
                      <h5 class="mb-0">Quản lý kỉ luật</h5>
                    </div>
                    <div class="card-body"><br />
                        <div class="row mb-3">
                          <label class="form-label" for="basic-icon-default-fullname">Mã kỉ luật</label>
                          <div class="col-sm-12">
                            <div class="input-group input-group-merge">
                              <asp:TextBox ID="makl" class="form-control" runat="server"></asp:TextBox>
                            </div>
                          </div>
                        </div>
                        <div class="row mb-3">
                          <label class="form-label" for="basic-icon-default-company">Tiền kỉ luật</label>
                          <div class="col-sm-12">
                            <div class="input-group input-group-merge">
                              <asp:TextBox ID="tienkl" class="form-control" runat="server"></asp:TextBox>
                            </div>
                          </div>
                        </div>
                        <div class="row mb-3">
                          <label class="form-label" for="basic-icon-default-email">Lí do kỉ luật</label>
                          <div class="col-sm-12">
                            <div class="input-group input-group-merge">
                              <asp:TextBox ID="lidokl" class="form-control" runat="server"></asp:TextBox>
                            </div>
                          </div>
                        </div><br />
                        <div class="row justify-content-end">
                          <div class="col-sm-9">
                            <asp:LinkButton  ID="themkl" class="btn btn-primary" runat="server" Text="Thêm" OnClick="themkl_Click"><i class="fa fa-plus me-sm-2"></i> Thêm </asp:LinkButton>
                            <asp:LinkButton  ID="suakl" class="btn btn-primary" runat="server" Text="Sửa" OnClick="suakl_Click"><i class="fa fa-edit me-sm-2"></i> Sửa </asp:LinkButton>
                            <asp:LinkButton  ID="xoakl" class="btn btn-primary" runat="server" Text="Xóa" OnClick="xoakl_Click"><i class="fa fa-trash"></i> Xóa</asp:LinkButton>
                          </div>
                        </div>
                          <br />
                        <!-- Kỉ luật Table -->
                        <div class="row mb-3" style="height: 246px; color:#576B80 !important; text-align:center;">
                            <asp:GridView ID="bangkl" runat="server" AutoGenerateSelectButton="True" AutoGenerateColumns="False" DataKeyNames="Id" OnSelectedIndexChanged="bangkl_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" Width="100%" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Height="227px" >
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Mã kỉ luật" SortExpression="Id" />
                                    <asp:BoundField DataField="Tien" HeaderText="Tiền kỉ luật" SortExpression="Tien" />
                                    <asp:BoundField DataField="KiLuat" HeaderText="Lí do kỉ luật " SortExpression="KiLuat" />
                                </Columns>
                                <FooterStyle BackColor="#CCCC99" ForeColor="yellow" />
                                <HeaderStyle BackColor="#F5F5F9" Font-Bold="True" ForeColor="#2F2F2F" Height="50px"  />
                                <PagerStyle BackColor="White" ForeColor="green" HorizontalAlign="Right"  />
                                <SelectedRowStyle BackColor="#E0E0ED" Font-Bold="True" ForeColor="black" />
                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                <SortedDescendingHeaderStyle BackColor="#242121" />
                            </asp:GridView>
                        </div>
                        <!-- Kỉ luật Table -->
                      
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </form>
            <!-- / Content -->
            <div class="content-backdrop fade"></div>
          </div>
          <!-- Content wrapper -->
        </div>
        <!-- / Layout page -->
      </div>

      <!-- Overlay -->
      <div class="layout-overlay layout-menu-toggle"></div>
    </div>
    <!-- / Layout wrapper -->
</asp:Content>