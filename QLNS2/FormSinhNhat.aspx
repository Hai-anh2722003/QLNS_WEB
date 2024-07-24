<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormSinhNhat.aspx.cs" Inherits="FormSinhNhat" MasterPageFile="Site.master"  %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="container-xxl flex-grow-1 container-p-y">
     <div class="col-12">
         <div class="card mb-4">
             <h5 class="card-header">Nhân viên sinh nhật trong tháng</h5>
             <div class="card-body"><br />
                 <div class="row">
                     <asp:GridView ID="DGVSinhNhat" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False" AutoGenerateSelectButton="True" >
                        <Columns>
                            <asp:BoundField DataField="IdUser" HeaderText="ID" />
                            <asp:BoundField DataField="MaNhanVien" HeaderText="Mã nhân viên" />
                            <asp:BoundField DataField="HoTen" HeaderText="Tên nhân viên" />
                            <asp:BoundField DataField="NgaySinh" HeaderText="Ngày sinh" />
                            <asp:BoundField DataField="DiaChi" HeaderText="Địa chỉ" />
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
            </div>
        </div>
    </div>
</div>
</asp:Content>
