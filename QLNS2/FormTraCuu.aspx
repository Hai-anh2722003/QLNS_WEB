<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormTraCuu.aspx.cs" Inherits="FormTraCuu" MasterPageFile="Site.master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="container-xxl flex-grow-1 container-p-y">
     <div class="col-12">
         <div class="card mb-4">
             <h5 class="card-header">Tra cứu</h5>
             <div class="card-body"><br />
                 <div class="row">
                      <div class="col-xl-1 col-md-6 col-sm-12 mb-4">
                    </div>
                     <div class="col-xl-2 col-md-6 col-sm-12 mb-4">
                        <label class="form-label"for="TypeaheadBasic">Họ và tên</label>
                    </div>
                    <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                        <asp:TextBox ID="txtTenNhanVien" Class="form-control typeahead tt-hint" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xl-2 col-md-6 col-sm-12 mb-4">
                        <label class="form-label"for="TypeaheadBasic">Mã nhân viên</label>
                    </div>
                    <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                       <asp:TextBox ID="txtMaNhanVien" Class="form-control typeahead tt-hint" runat="server"></asp:TextBox>
                    </div>
                 </div>
                <div class="row">
                     <div class="col-xl-1 col-md-6 col-sm-12 mb-4">
                   </div>
                    <div class="col-xl-2 col-md-6 col-sm-12 mb-4">
                       <label class="form-label"for="TypeaheadBasic">CCCD</label>
                   </div>
                   <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                       <asp:TextBox ID="txtCCCD" Class="form-control typeahead tt-hint" runat="server"></asp:TextBox>
                   </div>
                   <div class="col-xl-2 col-md-6 col-sm-12 mb-4">
                       <label class="form-label"for="TypeaheadBasic">Chức vụ</label>
                   </div>
                   <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                      <asp:DropDownList ID="drlCV" Class="form-control typeahead tt-hint" runat="server"></asp:DropDownList>
                   </div>
                </div>
                  <div class="row">
                      <div class="col-xl-1 col-md-6 col-sm-12 mb-4">
                    </div>
                     <div class="col-xl-2 col-md-6 col-sm-12 mb-4">
                        <label class="form-label"for="TypeaheadBasic">Phòng ban</label>
                    </div>
                    <div class="col-xl-3 col-md-6 col-sm-12 mb-4">
                         <asp:DropDownList ID="drlPB" Class="form-control typeahead tt-hint" runat="server"></asp:DropDownList>
                    </div>
                   
                 </div>
                 <div class="row">
                     <div class="col-md-10 mb-4">
                        <asp:GridView ID="GV_TraCuu" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False" AutoGenerateSelectButton="True" >
                            <Columns>
                                <asp:BoundField DataField="MaNhanVien" HeaderText="Mã nhân viên" />
                                <asp:BoundField DataField="HoTen" HeaderText="Họ và tên" />
                                <asp:BoundField DataField="NgaySinh" HeaderText="Ngày sinh" />
                                <asp:BoundField DataField="Email" HeaderText="Email" />
                                <asp:BoundField DataField="CMND" HeaderText="CCD" />
                                <asp:BoundField DataField="TenCongTac" HeaderText="Phòng ban" />
                                <asp:BoundField DataField="TenChucDanh" HeaderText="Chức vụ" />
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
                     <div class="col-md-2 mb-4">
                          <div class="pt-4">
                              <asp:Button ID="btnTim" class="btn btn-primary me-sm-3 me-1" runat="server" Text="Tìm kiếm" OnClick="btnTim_Click"/>
                          </div>
                         <div class="pt-4">
                            <asp:Button ID="btnLamMoi" class="btn btn-primary me-sm-3 me-1" runat="server" Text="Làm mới" OnClick="btnLamMoi_Click"/>
                        </div>
                      </div>
                     
                   </div>
              </div>
        </div>
    </div>
</div>
</asp:Content>
