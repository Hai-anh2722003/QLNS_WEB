<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormChucVu.aspx.cs" Inherits="FormChucVu" MasterPageFile="Site.master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="container-xxl flex-grow-1 container-p-y">
     <div class="col-12">
         <div class="card mb-4">
             <h5 class="card-header">Chức vụ </h5>
             <div class="card-body"><br />
                 <div class="row">
                      <div class="col-xl-1 col-md-6 col-sm-12 mb-4">
                    </div>
                     <div class="col-xl-2 col-md-6 col-sm-12 mb-4">
                        <label class="form-label"for="TypeaheadBasic">Mã chức vụ</label>
                    </div>
                    <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                        <asp:TextBox ID="txtMaChucDanh" Class="form-control typeahead tt-hint" runat="server" ReadOnly="True"></asp:TextBox>
                    </div>
                    <div class="col-xl-2 col-md-6 col-sm-12 mb-4">
                        <label class="form-label"for="TypeaheadBasic">Tên chức vụ</label>
                    </div>
                    <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                       <asp:TextBox ID="txtTenChucDanh" Class="form-control typeahead tt-hint" runat="server"></asp:TextBox>
                    </div>
                 </div>
                 <div class="row">
                     <div class="col-md-6 mb-4">
                        <asp:GridView ID="GV_ChucDanh" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GV_ChucDanh_SelectedIndexChanged" >
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Mã chức vụ" />
                                <asp:BoundField DataField="TenChucDanh" HeaderText="Tên chức vụ" />
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
                     <div class="col-md-6 mb-4">
                          <div class="pt-4">
                             <asp:LinkButton ID="btnThem" class="btn btn-primary me-sm-3 me-1" runat="server" Text="Thêm chức vụ" OnClick="btnThem_Click"><i class="fa fa-plus me-sm-2"></i> Thêm chức vụ</asp:LinkButton>
                              <asp:LinkButton ID="btnSua" class="btn btn-primary me-sm-3 me-1" runat="server" Text="Sửa chức vụ" OnClick="btnSua_Click"><i class="fa fa-edit me-sm-2"></i> Sửa chức vụ</asp:LinkButton>
                          </div>
                         <div class="pt-4">
                            <asp:LinkButton ID="Button5" class="btn btn-primary me-sm-3 me-1" runat="server" Text="Xóa chức vụ" OnClick="Button5_Click" ><i class="fa fa-trash me-sm-2"></i> Xóa chức vụ _</asp:LinkButton>
                            <asp:LinkButton ID="Button6" class="btn btn-primary me-sm-3 me-1" runat="server" Text="Làm mới" OnClick="Button6_Click"><i class="fa fa-arrows-rotate me-sm-2"></i>Làm mới ___</asp:LinkButton>
                        </div>
                      </div>
                     
                   </div>
               </div>
        </div>
    </div>
</div>
</asp:Content>

